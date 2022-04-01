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
    /// Логика взаимодействия для Timetable.xaml
    /// </summary>
    public partial class TimetablePage : Page
    {
        CASEEntities db;
        public TimetablePage()
        {
            InitializeComponent();
            db = new CASEEntities();
            db.Class.Load();
            foreach (var a in db.Class.Local.ToBindingList())
                ClassNum.Items.Add(a.Class1);
            Monday.Items.Add("Понедельник");
            Tuesday.Items.Add("Вторник");
            Wednesday.Items.Add("Среда");
            Thursday.Items.Add("Четверг");
            Friday.Items.Add("Пятница");

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetLessonsDay(Monday, ClassNum.SelectedValue.ToString(), "Понедельник");
            GetLessonsDay(Tuesday, ClassNum.SelectedValue.ToString(), "Вторник");
            GetLessonsDay(Wednesday, ClassNum.SelectedValue.ToString(), "Среда");
            GetLessonsDay(Thursday, ClassNum.SelectedValue.ToString(), "Четверг");
            GetLessonsDay(Friday, ClassNum.SelectedValue.ToString(), "Пятница");
        }

        private void GetLessonsDay(ListBox lb, string classNumber, string day)
        {
            lb.Items.Clear();
            lb.Items.Add(day);
            db = new CASEEntities();
            db.Lessons.Where(u => u.Timetable.Class.Class1 == classNumber).Where(u => u.Timetable.DayOfWeek.Day == day).Load();
            List<Lessons> lessons = db.Lessons.Local.ToList();
            if(lessons.Count == 0)
            {
                lb.Items.Add("-");
                lb.Items.Add("-");
                lb.Items.Add("-");
                return;
            }
            foreach (var l in lessons)
            {
                lb.Items.Add(l.Subjects.Subject + " (" + l.Number + ")");
            }
        }
    }
}
