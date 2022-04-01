using System;
using System.Collections.Generic;
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

namespace SсhoolPortal
{
    /// <summary>
    /// Логика взаимодействия для AddTheme.xaml
    /// </summary>
    public partial class AddTheme : Page
    {
        CASEEntities db;
        public AddTheme()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if(TopicName.Text.Length <= 1)
            {
                MessageBox.Show("Проверьте правильность ввода название темы");
                TopicName.Focus();
                return;
            }
            if (CountHours.Text.Length == 1)
            {
                MessageBox.Show("Проверьте правильность ввода название темы");
                CountHours.Focus();
                return;
            }
            db = new CASEEntities();
            Topics t = new Topics()
            {
                Hours = Convert.ToDouble(CountHours.Text),
                Name = TopicName.Text
            };
            db.Topics.Add(t);
            db.SaveChangesAsync();
            MessageBox.Show("Тема успешно добавлена!");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AdminPage());
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ",")
                   && (!CountHours.Text.Contains(".")
                   && CountHours.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }
    }
}
