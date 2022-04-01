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
    /// Логика взаимодействия для AddCertificate.xaml
    /// </summary>
    public partial class AddCertificate : Page
    {
        CASEEntities db;
        public AddCertificate()
        {
            InitializeComponent();
            db = new CASEEntities();
            db.Learning.Load();
            Learn.ItemsSource = db.Learning.Local.ToBindingList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Learning l = Learn.SelectedItem as Learning;
            Certificate c = new Certificate()
            {
                Learning = l,
                Date = Convert.ToDateTime(CertDate.Text),
                Issued = Issued.Text
            };
            db.Certificate.Add(c);
            db.SaveChangesAsync();
            MessageBox.Show("Сертификат успешно добавлен!");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AdminPage());
        }
    }
}
