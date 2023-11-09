using IISAS.Model;
using IISAS.Repository;
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

namespace IISAS.xaml_window.salterski_radnik
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
            lbStatus.Content = korisnik.tip_korisnika;
            var asContext = new ASContext();
            var kartaRepository = new Repository.KartaRepository(asContext);
            kartaService = new Service.KartaService(kartaRepository);
            Load();
        }

        public void Load()
        {

            lvDataBinding.Items.Clear();
            karte = kartaService.GetAllOrderedBySalterskiRadnik();

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
                        var asContext = new ASContext();
                        var voznjaRepository = new Repository.VoznjaRepository(asContext);
                        var voznjaService = new Service.VoznjaService(voznjaRepository);
                        voznjaService.AddBrojKarata(karta.voznja);
                    }
                }
            }

        }

        private void Red_voznje(object sender, RoutedEventArgs e)
        {

        }

        private void IzdavanjeKarata(object sender, RoutedEventArgs e)
        {
            var ik = new IISAS.xaml_window.salterski_radnik.Izdavanje_karata(korisnik);
            ik.Show();
            this.Close();
        }

        private void RezervacijaKarte(object sender, RoutedEventArgs e)
        {
            var rk = new IISAS.xaml_window.salterski_radnik.Rezervacija_karata(korisnik);
            rk.Show();
            this.Close();
        }

        private void PregledIzdatihKarata(object sender, RoutedEventArgs e)
        {
            var pik = new IISAS.xaml_window.salterski_radnik.Izdate_karte(korisnik);
            pik.Show();
            this.Close();
        }

        private void Korisnik_st_usluga_logout(object sender, RoutedEventArgs e)
        {
            var mw = new IISAS.MainWindow();
            mw.Show();
            this.Close();
        }

        private void Detaljnije(object sender, RoutedEventArgs e)
        {
            if (lvDataBinding.SelectedItems.Count > 0)
            {
                Model.Karta selectedKarta = (Model.Karta)lvDataBinding.SelectedItems[0];
                var det = new IISAS.xaml_window.salterski_radnik.Pregled_rezervisanih_karata_detaljnije(this, selectedKarta);
                det.ShowDialog();

            }
            else
            {
                MessageBox.Show("Molim Vas selektujte vožnju za koju želite da vidite detalje!", "Raketa", MessageBoxButton.OK, MessageBoxImage.Warning);
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
                     karte = kartaService.filterByDatumSR(tbPretraga.Text);
                 }
                 else if (rbIme.IsChecked == true)
                 {
                     karte = kartaService.filterByImeSR(tbPretraga.Text);
                 }
                 else if (rbPrezime.IsChecked == true)
                 {
                     karte = kartaService.filterByPrezimeSR(tbPretraga.Text);
                 }
                 else if (rbIdKarte.IsChecked == true)
                 {
                     karte = kartaService.filterByIdKarteSR(tbPretraga.Text);
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

        private void Otkazi(object sender, RoutedEventArgs e)
        {
            if (lvDataBinding.SelectedItems.Count > 0)
            {
                Model.Karta selectedKarta = (Model.Karta)lvDataBinding.SelectedItems[0];
                MessageBoxResult mr = MessageBox.Show("Da li ste sigurni da želite da otkažete kartu?", "Raketa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (mr == MessageBoxResult.Yes)
                {
                    kartaService.DeleteElement(selectedKarta.id_karte);
                    var asContext = new ASContext();
                    var voznjaRepository = new Repository.VoznjaRepository(asContext);
                    var voznjaService = new Service.VoznjaService(voznjaRepository);
                    voznjaService.AddBrojKarata(selectedKarta.voznja);
                    Load();
                    MessageBox.Show("Uspešno ste otkazali kartu!", "Raketa", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Molim Vas selektujte kartu koju želite da otkažete!", "Raketa", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Kupi(object sender, RoutedEventArgs e)
        {
            if (lvDataBinding.SelectedItems.Count > 0)
            {
                Model.Karta selectedKarta = (Model.Karta)lvDataBinding.SelectedItems[0];
                MessageBoxResult mr = MessageBox.Show("Da li ste sigurni da želite da kupite kartu?", "Raketa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (mr == MessageBoxResult.Yes)
                {
                    selectedKarta.rezervisana = 0;
                    kartaService.Update(selectedKarta);
                    Load();
                    MessageBox.Show("Uspešno ste kupili kartu!", "Raketa", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            else
            {
                MessageBox.Show("Molim Vas selektujte vožnju za koju želite da vidite detalje!", "Raketa", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
