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
    /// Логика взаимодействия для AddClass.xaml
    /// </summary>
    public partial class AddClass : Page
    {
        CASEEntities db;
        public AddClass()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AdminPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            db = new CASEEntities();
            if (ClassNum.Text.Length == 4)
            {
                try
                {
                    Convert.ToInt32(ClassNum.Text);
                    Class c = new Class()
                    {
                        Class1 = ClassNum.Text
                    };
                    db.Class.Add(c);
                    db.SaveChangesAsync();
                    MessageBox.Show("Класс успешно добавлен!");
                }
                catch
                {
                    MessageBox.Show("Номер класса должно состоять из 4 цифр (Например : 1233)");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Номер класса должно состоять из 4 цифр (Например : 1233)");
            }
        }
    }
}
