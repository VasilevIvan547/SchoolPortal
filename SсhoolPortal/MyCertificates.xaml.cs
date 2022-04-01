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
    /// Логика взаимодействия для MyCertificates.xaml
    /// </summary>
    public partial class MyCertificates : Page
    {
        CASEEntities db;
        public MyCertificates(Teachers usr)
        {
            InitializeComponent();
            db = new CASEEntities();
            db.Certificate.Where(u => u.Learning.idTeacher == usr.id).Load();
            Grid.ItemsSource = db.Certificate.Local.ToBindingList();


        }
    }
}
