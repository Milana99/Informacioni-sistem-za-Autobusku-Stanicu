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

namespace IISAS.xaml_window.admin_as
{
    /// <summary>
    /// Interaction logic for Upravljanje_popustima.xaml
    /// </summary>
    public partial class Upravljanje_popustima : Window
    {
        Service.VoznjaService voznjaService;
        public List<Model.Voznja> voznje;
        Model.Korisnik korisnik;
        public Upravljanje_popustima(Model.Korisnik korisnik)
        {
            InitializeComponent();
            var asContext = new ASContext();
            var voznjaRepository = new Repository.VoznjaRepository(asContext);
            voznjaService = new Service.VoznjaService(voznjaRepository);
            this.korisnik = korisnik;
            lbUser.Content = korisnik.username;
            lbTipKorisnika.Content = korisnik.tip_korisnika;
            LoadAll();
        }
        public void LoadAll()
        {

            voznje = voznjaService.GetAllOrdered();

            lvDataBinding.Items.Clear();
            foreach (Model.Voznja voznja in voznje)
            {
                lvDataBinding.Items.Add(voznja);
            }

        }

        private void Voznje(object sender, RoutedEventArgs e)
        {
            var voznje = new IISAS.xaml_window.admin_as.Upravljanje_terminima(korisnik);
            voznje.Show();
            this.Close();
        }

        private void Cena(object sender, RoutedEventArgs e)
        {
            var cena = new IISAS.xaml_window.admin_as.Manipulacija_cene_voznje(korisnik);
            cena.Show();
            this.Close();
        }

        private void Korisnik_st_usluga_logout(object sender, RoutedEventArgs e)
        {
            var mw = new IISAS.MainWindow();
            mw.Show();
            this.Close();
        }

        private void tbSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            tbPretraga.Foreground = new SolidColorBrush(Colors.Gray);
            if (tbPretraga.Text == "")
            {
                tbPretraga.Text = "Pretraga voznje...";
            }
        }

        private void tbSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbPretraga.Text == "Pretraga voznje...")
            {
                tbPretraga.Clear();
            }
            tbPretraga.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbPretraga.Text != "Pretraga voznje...")
            {
                List<Model.Voznja> voznje = new List<Model.Voznja>();
                if (rbDatum.IsChecked == true)
                {
                    voznje = voznjaService.FilterByDatum(tbPretraga.Text);
                }
                else if (rbPolaznaStanica.IsChecked == true)
                {
                    voznje = voznjaService.FilterByPolazna(tbPretraga.Text);
                }
                else if (rbKrajnjaStanica.IsChecked == true)
                {
                    voznje = voznjaService.FilterByKrajnja(tbPretraga.Text);
                }
                else if (rbPrevoznik.IsChecked == true)
                {
                    voznje = voznjaService.FilterByPrevoznik(tbPretraga.Text);
                }

                lvDataBinding.Items.Clear();
                foreach (Model.Voznja voznja in voznje)
                {
                    lvDataBinding.Items.Add(voznja);
                }
            }
        }

        private void Detalji(object sender, RoutedEventArgs e)
        {
            if (lvDataBinding.SelectedItems.Count > 0)
            {
                Model.Voznja selectedVoznja = (Model.Voznja)lvDataBinding.SelectedItems[0];
                var detalji = new IISAS.xaml_window.admin_as.Upravljanje_popustima_detaljnije(this, selectedVoznja);
                detalji.ShowDialog();
            }
            else
            {
                MessageBox.Show("Molim Vas selektujte voznju za koju hocete da vidite detalje");
            }
            
        }

        private void Izmeni(object sender, RoutedEventArgs e)
        {
            if (lvDataBinding.SelectedItems.Count > 0)
            {
                Model.Voznja selectedVoznja = (Model.Voznja)lvDataBinding.SelectedItems[0];
                var izmeni = new IISAS.xaml_window.admin_as.Upravljanje_popustima_izmena(this, selectedVoznja);
                izmeni.ShowDialog();
            }
            else
            {
                MessageBox.Show("Molim Vas selektujte voznju za koju hocete da izmenite cenu");
            }
            
        }
    }
}
