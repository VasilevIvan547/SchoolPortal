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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddClass());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddPosition());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddTheme());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddCourseTopic());
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new TimetableNew());
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new ListTeacherPage());
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new ListStudentPage());
        }
    }
}
