using IISAS.Model;
using IISAS.Service;
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

namespace IISAS.xaml_window.korisnik_stan_usluga
{
    /// <summary>
    /// Interaction logic for Pregled_rezervisanih_karata.xaml
    /// </summary>
    public partial class Pregled_rezervisanih_karata : Window
    {
        public Model.Korisnik korisnik;
        Service.KartaService kartaService;
        List<Model.Karta> karte;
        public Pregled_rezervisanih_karata(Model.Korisnik korisnik)
        {
            InitializeComponent();
            this.korisnik = korisnik;
            lbUser.Content = korisnik.username;
            lbStatus.Content = korisnik.status_korisnika;
            var kartaRepository = new Repository.KartaRepository(new ASContext());
            kartaService = new Service.KartaService(kartaRepository);
            Load();
        }

        public void Load()
        {

            lvDataBinding.Items.Clear();
            karte = kartaService.getKarteByKorisnikOrdered(korisnik);

            foreach (Model.Karta karta in karte)
            {
                if (karta.rezervisana == 1)
                {
                    DateTime dt1 = DateTime.Parse(karta.voznja.datum.ToString()).Add(TimeSpan.Parse(karta.voznja.pol_sat.ToString()));
                    DateTime dt2 = DateTime.Now;
                    TimeSpan ts = dt1 - dt2;
                    double totalTime = ts.TotalHours;
                    if (totalTime > 24)
                    {
                        lvDataBinding.Items.Add(karta);
                    }
                    else
                    {
                        kartaService.DeleteElement(karta.id_karte);
                        var voznjaRepository = new Repository.VoznjaRepository(new ASContext());
                        var voznjaService = new Service.VoznjaService(voznjaRepository);
                        voznjaService.AddBrojKarata(karta.voznja);
                    }

                }
            }

        }

        private void RedVoznje(object sender, RoutedEventArgs e)
        {
            var rv = new IISAS.xaml_window.korisnik_stan_usluga.Kupovina_karte(korisnik);
            rv.Show();
            this.Close();
        }

        private void KupovinaKarte(object sender, RoutedEventArgs e)
        {
            var kk = new IISAS.xaml_window.korisnik_stan_usluga.Kupovina_karata_prava(korisnik);
            kk.Show();
            this.Close();
        }

        private void Pregled_kupljenih_karata(object sender, RoutedEventArgs e)
        {
            var pkk = new IISAS.xaml_window.korisnik_stan_usluga.Pregled_kupljenih_karata(korisnik);
            pkk.Show();
            this.Close();
        }

        private void RezervacijaKarata(object sender, RoutedEventArgs e)
        {
            var rk = new IISAS.xaml_window.korisnik_stan_usluga.Rezervacija_karata(korisnik);
            rk.Show();
            this.Close();
        }

        private void Otkazi(object sender, RoutedEventArgs e)
        {
            if (lvDataBinding.SelectedItems.Count > 0)
            {
                Model.Karta selectedKarta = (Model.Karta)lvDataBinding.SelectedItems[0];
                MessageBoxResult mr = MessageBox.Show("Da li ste sigurni da želite da otkažete kartu?", "Potvrda", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (mr == MessageBoxResult.Yes)
                {
                    kartaService.DeleteElement(selectedKarta.id_karte);
                    var voznjaRepository = new Repository.VoznjaRepository(new ASContext());
                    var voznjaService = new Service.VoznjaService(voznjaRepository);
                    voznjaService.AddBrojKarata(selectedKarta.voznja);
                    Load();
                    MessageBox.Show("Uspešno ste otkazali kartu!", "Uspešno!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Molim Vas selektujte kartu koju želite da otkažete!", "Upozorenje!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Detaljnije(object sender, RoutedEventArgs e)
        {
            if (lvDataBinding.SelectedItems.Count > 0)
            {
                Model.Karta selectedKarta = (Model.Karta)lvDataBinding.SelectedItems[0];
                var det = new IISAS.xaml_window.korisnik_stan_usluga.Pregled_rezervisanih_karata_detaljnije(this, selectedKarta);
                det.ShowDialog();

            }
            else
            {
                MessageBox.Show("Molim Vas selektujte vožnju za koju želite da vidite detalje!", "Upozorenje!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Korisnik_st_usluga_logout(object sender, RoutedEventArgs e)
        {
            var mn = new IISAS.MainWindow();
            mn.Show();
            this.Close();
        }

        private void Kupi(object sender, RoutedEventArgs e)
        {
            if (lvDataBinding.SelectedItems.Count > 0)
            {
                Model.Karta selectedKarta = (Model.Karta)lvDataBinding.SelectedItems[0];
                MessageBoxResult mr = MessageBox.Show("Da li ste sigurni da želite da kupite kartu?", "Potvrda", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (mr == MessageBoxResult.Yes)
                {
                    var kartaRepository = new Repository.KartaRepository(new ASContext());
                    var kartaService = new Service.KartaService(kartaRepository);
                    selectedKarta.rezervisana = 0;
                    kartaService.Update(selectedKarta);
                    Load();
                    MessageBox.Show("Uspešno ste kupili kartu!", "Uspešno!", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            else
            {
                MessageBox.Show("Molim Vas selektujte vožnju za koju želite da vidite detalje!", "Upozorenje!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void tbSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            tbPretraga.Foreground = new SolidColorBrush(Colors.Gray);
            if (tbPretraga.Text == "")
            {
                tbPretraga.Text = "Pretraga karata...";
            }
        }

        private void tbSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbPretraga.Text == "Pretraga karata...")
            {
                tbPretraga.Clear();
            }
            tbPretraga.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbPretraga.Text != "Pretraga karata...")
            {
                List<Model.Karta> karte = new List<Model.Karta>();
                if (rbDatum.IsChecked == true)
                {
                    karte = kartaService.filterByDatumUsername(tbPretraga.Text, korisnik);
                }
                else if (rbPolaznaStanica.IsChecked == true)
                {
                    karte = kartaService.filterByPolaznaUsername(tbPretraga.Text, korisnik);
                }
                else if (rbKrajnjaStanica.IsChecked == true)
                {
                    karte = kartaService.filterByKrajnjaUsername(tbPretraga.Text, korisnik);
                }
                else if (rbPrevoznik.IsChecked == true)
                {
                    karte = kartaService.filterByPrevoznikUsername(tbPretraga.Text, korisnik);
                }

                lvDataBinding.Items.Clear();
                foreach (Model.Karta karta in karte)
                {
                    if (karta.rezervisana == 1)
                    {
                        lvDataBinding.Items.Add(karta);
                    }

                }
            }
        }
    }
}
