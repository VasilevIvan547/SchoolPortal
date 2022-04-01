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

namespace SсhoolPortal
{
    /// <summary>
    /// Логика взаимодействия для TeachersPage.xaml
    /// </summary>
    public partial class TeachersPage : Page
    {
        Teachers usr;
        CASEEntities db;
        public TeachersPage(Users usr)
        {
            
            InitializeComponent();
            db = new CASEEntities();
            db.Teachers.Where(u => u.Users.Login == usr.Login).Load();
            List<Teachers> teacher = db.Teachers.Local.ToList();
            this.usr = teacher[0];
            FIO.Text = teacher[0].Surname + " " + teacher[0].Name + " " + teacher[0].Middlename;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj = FrmMain;
            FrmMain.Navigate(new TimetablePage());
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj = FrmMain;
            FrmMain.Navigate(new MyCertificates(usr));
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj = FrmMain;
            FrmMain.Navigate(new RegistrationForTheCourse(usr));
        }
    }
}
