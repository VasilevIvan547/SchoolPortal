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
    /// Логика взаимодействия для AddCourse.xaml
    /// </summary>
    public partial class AddCourse : Page
    {
        CASEEntities db;
        public AddCourse()
        {
            InitializeComponent();
            db = new CASEEntities();
            db.Teachers.Load();
            TeacherList.ItemsSource = db.Teachers.Local.ToBindingList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Teachers t = (Teachers)TeacherList.SelectedItem;
            if (t != null && NameCourse.Text != "")
            {
                Courses c = new Courses()
                {
                    Name = NameCourse.Text,
                    Teachers = t
                };
                db.Courses.Add(c);
                db.SaveChangesAsync();
                MessageBox.Show("Курс успешно добавлен!");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AdminPage());
        }
    }
}
