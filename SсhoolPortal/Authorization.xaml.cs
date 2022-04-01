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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
            OdbConnectHelper.entobj = new CASEEntities();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var userObj = OdbConnectHelper.entobj.Users.FirstOrDefault(
                    x => x.Login == login.Text && x.Password == password.Password);
            if (userObj == null)
                MessageBox.Show("Неверный логин или пароль",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
            else
            {
                FrameApp.frmObj.Navigate(new TeachersPage(userObj));
                //FrameApp.frmObj.Navigate(new AddCertificate());
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AdminAuthorization());
        }
    }
}
