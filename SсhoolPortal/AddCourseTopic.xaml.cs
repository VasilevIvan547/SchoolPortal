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
    /// Логика взаимодействия для AddCourseTopic.xaml
    /// </summary>
    public partial class AddCourseTopic : Page
    {
        CASEEntities db;
        public AddCourseTopic()
        {
            InitializeComponent();
            db = new CASEEntities();
            db.Courses.Load();
            CourseInfo.ItemsSource = db.Courses.Local.ToBindingList();

            db.Topics.Load();
            TopicInfo.ItemsSource = db.Topics.Local.ToBindingList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if(TopicInfo.Text.Length == 0)
            {
                MessageBox.Show("Выберите тему!");
                TopicInfo.Focus();
                return;
            }
            if(CourseInfo.Text.Length == 0)
            {
                MessageBox.Show("Выберите курс");
                CourseInfo.Focus();
                return;
            }
            db = new CASEEntities();
            CourseTopic ct = new CourseTopic()
            {
                idTopic = ((Topics)TopicInfo.SelectedItem).id,
                idCourse = ((Courses)CourseInfo.SelectedItem).id
            };
            db.CourseTopic.Add(ct);
            db.SaveChangesAsync();
            MessageBox.Show("Тема успешно добавлена в курс");
            TopicInfo.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AdminPage());
        }
    }
}
