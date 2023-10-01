using IISAS.Model;
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
using System.Windows.Shapes;

namespace IISAS.xaml_window.obican_korisnik
{
    /// <summary>
    /// Interaction logic for Uvid_u_perone.xaml
    /// </summary>
    public partial class Uvid_u_perone : Window
    {
        public Uvid_u_perone()
        {
            InitializeComponent();
        }

        private void Prijava(object sender, RoutedEventArgs e)
        {
            var prijava = new IISAS.xaml_window.Login();
            prijava.Show();
            this.Close();
        }

        private void RedVoznje(object sender, RoutedEventArgs e)
        {
            var red_voznje = new IISAS.MainWindow();
            red_voznje.Show();
            this.Close();
        }

        private void Registracija(object sender, RoutedEventArgs e)
        {
            var reg = new IISAS.xaml_window.Registracija();
            reg.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var peronRepository = new Repository.PeronRepository(new ASContext());
            var peronService = new Service.PeronService(peronRepository);
            List<Model.Voznja> voznje = peronService.GetByDatumVreme(dpDatum.Text, tbVreme.Text);

            lvDataBinding.Items.Clear();
            foreach(Model.Voznja voznja in voznje)
            {
                lvDataBinding.Items.Add(voznja);
            }
        }
    }
}
