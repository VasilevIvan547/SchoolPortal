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
    /// Логика взаимодействия для ListTeacherPage.xaml
    /// </summary>
    public partial class ListTeacherPage : Page
    {
        CASEEntities db;
        public ListTeacherPage()
        {
            InitializeComponent();
            db = new CASEEntities();
            db.Teachers.Load();
            db.Positions.Load();
            Grid.ItemsSource = db.Teachers.Local.ToBindingList();

            foreach (var a in db.Positions.Local.ToBindingList())
                POSITIONTB.Items.Add(a.Position);
        }

        private void FIOTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            db = new CASEEntities();
            db.Teachers.Where(u => u.Surname.ToLower().Contains(FIOTB.Text.ToLower())).Load();
            Grid.ItemsSource = db.Teachers.Local.ToBindingList();
        }
        private void POSITIONTB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (POSITIONTB.SelectedValue.ToString() == "" && POSITIONTB.SelectedValue == null)
            {
                return;
            }
            db = new CASEEntities();
            db.Teachers.Where(u => u.Positions.Position == POSITIONTB.SelectedValue.ToString()).Load();
            Grid.ItemsSource = db.Teachers.Local.ToBindingList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.SelectedItems.Count > 0)
            {
                Teachers[] rs = new Teachers[Grid.SelectedItems.Count];
                int b = 0;
                for (int c = 0; c < Grid.SelectedItems.Count; c++)
                {
                    rs[b] = Grid.SelectedItems[c] as Teachers;

                    b++;
                }
                var application = new Word.Application();
                Word.Document document = application.Documents.Add();
                Word.Paragraph paragraph = document.Paragraphs.Add();
                Word.Range userRange = paragraph.Range;
                userRange.Text = "ВЫПИСКА СОТРУДНИКОВ";
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
                Word.Table infoTable = document.Tables.Add(tableRange, rs.Length + 1, 7);
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
                cellRange.Text = "Должность";
                cellRange = infoTable.Cell(1, 5).Range;
                cellRange.Text = "Класс";
                cellRange = infoTable.Cell(1, 6).Range;
                cellRange.Text = "Телефон";
                cellRange = infoTable.Cell(1, 7).Range;
                cellRange.Text = "Почта";
                infoTable.Rows[1].Range.Bold = 1;
                int i = 2;
                foreach (var a in rs)
                {
                    cellRange = infoTable.Cell(i, 1).Range;
                    cellRange.Text = a.Middlename == null? a.Surname.ToString() + " " + a.Name.ToString() : a.Surname.ToString() + " " + a.Name.ToString() + " " + a.Middlename.ToString();
                    cellRange = infoTable.Cell(i, 2).Range;
                    cellRange.Text = a.Sex.Sex1.ToString();
                    cellRange = infoTable.Cell(i, 3).Range;
                    cellRange.Text = a.Birthday.ToString();
                    cellRange = infoTable.Cell(i, 4).Range;
                    cellRange.Text = a.Positions.Position.ToString();
                    cellRange = infoTable.Cell(i, 5).Range;
                    cellRange.Text = a.Class1 == null? "" : a.Class1.ToString();
                    cellRange = infoTable.Cell(i, 6).Range;
                    cellRange.Text = a.Phone.ToString();
                    cellRange = infoTable.Cell(i, 7).Range;
                    cellRange.Text = a.Email == null ? "" : a.Email.ToString();
                    i++;
                }
                tableRange.InsertParagraphAfter();

                application.Visible = true;
                document.SaveAs2(@"Teacher.docx");
            }
            }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AdminPage());
        }
    }
}
