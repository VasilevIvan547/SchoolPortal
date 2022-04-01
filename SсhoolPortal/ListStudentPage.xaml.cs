using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Word = Microsoft.Office.Interop.Word;

namespace SсhoolPortal
{
    /// <summary>
    /// Логика взаимодействия для ListStudentPage.xaml
    /// </summary>
    public partial class ListStudentPage : Page
    {
        CASEEntities db;
        public ListStudentPage()
        {
            InitializeComponent();
            db = new CASEEntities();
            db.Students.Load();
            db.Class.Load();
            Grid.ItemsSource = db.Students.Local.ToBindingList();

            foreach (var a in db.Class.Local.ToBindingList())
                CLASSTB.Items.Add(a.Class1);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.SelectedItems.Count > 0)
            {
                Students[] rs = new Students[Grid.SelectedItems.Count];
                int b = 0;
                for (int c = 0; c < Grid.SelectedItems.Count; c++)
                {
                    rs[b] = Grid.SelectedItems[c] as Students;

                    b++;
                }
                var application = new Word.Application();
                Word.Document document = application.Documents.Add();
                Word.Paragraph paragraph = document.Paragraphs.Add();
                Word.Range userRange = paragraph.Range;
                userRange.Text = "ВЫПИСКА СТУДЕНТОВ";
                try
                {
                    userRange.set_Style("Цитата 2");
                }
                catch { }
                userRange.Font.Kerning = 24;
                userRange.Font.Bold = 800;
                userRange.Font.Color = Word.WdColor.wdColorBlack;
                userRange.InsertParagraphAfter();

                Word.Paragraph tableparagraph = document.Paragraphs.Add();
                Word.Range tableRange = tableparagraph.Range;
                Word.Table infoTable = document.Tables.Add(tableRange, rs.Length + 1, 6);
                infoTable.Borders.InsideLineStyle = infoTable.Borders.OutsideLineStyle
                        = Word.WdLineStyle.wdLineStyleSingle;
                infoTable.Range.Cells.VerticalAlignment
                        = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                Word.Range cellRange;
                cellRange = infoTable.Cell(1, 1).Range;
                cellRange.Text = "ФИО";
                cellRange = infoTable.Cell(1, 2).Range;
                cellRange.Text = "Пол";
                cellRange = infoTable.Cell(1, 3).Range;
                cellRange.Text = "Дата Рождения";
                cellRange = infoTable.Cell(1, 4).Range;
                cellRange.Text = "Класс";
                cellRange = infoTable.Cell(1, 5).Range;
                cellRange.Text = "Телефон";
                cellRange = infoTable.Cell(1, 6).Range;
                cellRange.Text = "Почта";
                infoTable.Rows[1].Range.Bold = 1;
                int i = 2;
                foreach (var a in rs)
                {
                    cellRange = infoTable.Cell(i, 1).Range;
                    cellRange.Text = a.FIO.ToString();
                    cellRange = infoTable.Cell(i, 2).Range;
                    cellRange.Text = a.Sex.Sex1.ToString();
                    cellRange = infoTable.Cell(i, 3).Range;
                    cellRange.Text = a.Birthday.ToString();
                    cellRange = infoTable.Cell(i, 4).Range;
                    cellRange.Text = a.Class.Class1.ToString();
                    cellRange = infoTable.Cell(i, 5).Range;
                    cellRange.Text = a.Phone == null ? "" : a.Phone.ToString();
                    cellRange = infoTable.Cell(i, 6).Range;
                    cellRange.Text = a.Email == null ? "" : a.Email.ToString();
                    i++;
                }
                tableRange.InsertParagraphAfter();

                application.Visible = true;
                document.SaveAs2(@"Student.docx");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AdminPage());
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            db = new CASEEntities();
            db.Students.Where(u => u.FIO.ToLower().Contains(FIOTB.Text.ToLower())).Load();
            Grid.ItemsSource = db.Students.Local.ToBindingList();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CLASSTB.SelectedValue.ToString() == "" && CLASSTB.SelectedValue == null)
            {
                return;
            }
            db = new CASEEntities();
            db.Students.Where(u => u.Class.Class1 == CLASSTB.SelectedValue.ToString()).Load();
            Grid.ItemsSource = db.Students.Local.ToBindingList();
        }
    }
}
