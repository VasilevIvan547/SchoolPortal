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
    /// Логика взаимодействия для RegistrationForTheCourse.xaml
    /// </summary>
    public partial class RegistrationForTheCourse : Page
    {
        CASEEntities db;
        Teachers user;
        public RegistrationForTheCourse(Teachers t)
        {
            InitializeComponent();
            user = t;
            db = new CASEEntities();
            db.Courses.Load();
            CourseInfo.ItemsSource = db.Courses.Local.ToBindingList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Courses course = (Courses)CourseInfo.SelectedItem;
            DateTime Start = DateTime.Today;
            DateTime End = Start.AddDays(3);
            Learning l = new Learning()
            {
                idTeacher = user.id,
                idCourse = course.id,
                StartDate = Start,
                EndDate = End
            };
            db.Learning.Add(l);
            db.SaveChangesAsync();
            MessageBox.Show("Вы успешно записались на курс");
        }
    }
}
