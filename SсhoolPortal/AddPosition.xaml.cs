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
    /// Логика взаимодействия для AddPosition.xaml
    /// </summary>
    public partial class AddPosition : Page
    {
        CASEEntities db;
        public AddPosition()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db = new CASEEntities();
            if(PosName.Text.Length == 0)
            {
                MessageBox.Show("Поле не может быть пустым");
                PosName.Focus();
                return;
            }
            Positions p = new Positions()
            {
                Position = PosName.Text
            };
            db.Positions.Add(p);
            db.SaveChangesAsync();
            PosName.Text = "";
            MessageBox.Show("Должность успешно добавлена");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AdminPage());
        }
    }
}
