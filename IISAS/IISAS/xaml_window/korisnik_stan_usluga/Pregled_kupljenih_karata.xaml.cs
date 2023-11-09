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
using System.Xml.Linq;

namespace IISAS.xaml_window.korisnik_stan_usluga
{
    /// <summary>
    /// Interaction logic for Pregled_kupljenih_karata.xaml
    /// </summary>
    public partial class Pregled_kupljenih_karata : Window
    {
        Service.KartaService kartaService;
        List<Model.Karta> karte;
        public Model.Korisnik korisnik;
        public Model.Karta kartaa;
        public Pregled_kupljenih_karata(Model.Korisnik korisnik)
        {
            InitializeComponent();
            this.korisnik = korisnik;
            lbStatus.Content = korisnik.status_korisnika;
            lbUser.Content = korisnik.username;
            var asContext = new ASContext();
            var kartaRepository = new Repository.KartaRepository(asContext);
            kartaService = new Service.KartaService(kartaRepository);
            Load();
            
        }

        public void Load()
        {
            var asContext = new ASContext();
            var kartaRepository = new Repository.KartaRepository(asContext);
            kartaService = new Service.KartaService(kartaRepository);
            lvDataBinding.Items.Clear();
           
            karte = kartaService.getKarteByKorisnikVazecaOrdered(korisnik);

            rbVazeca.IsChecked = true;


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

        private void Obrisi(object sender, RoutedEventArgs e)
        {
            if (lvDataBinding.SelectedItems.Count > 0)
            {
                Model.Karta selectedKarta = (Model.Karta)lvDataBinding.SelectedItems[0];
                DateTime dt1 = DateTime.Parse(selectedKarta.voznja.datum.ToString()).Add(TimeSpan.Parse(selectedKarta.voznja.pol_sat.ToString()));
                DateTime dt2 = DateTime.Now;
                TimeSpan ts = dt1 - dt2;
                double totalTime = ts.TotalHours;

                if (totalTime > 24)
                {
                    MessageBoxResult mr = MessageBox.Show("Da li ste sigurni da želite da obrišete kartu?", "Potvrda", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (mr == MessageBoxResult.Yes)
                    {
                        kartaService.DeleteElement(selectedKarta.id_karte);
                        var asContext = new ASContext();
                        var voznjaRepository = new Repository.VoznjaRepository(asContext);
                        var voznjaService = new Service.VoznjaService(voznjaRepository);
                        voznjaService.AddBrojKarata(selectedKarta.voznja);
                        Load();
                        MessageBox.Show("Uspešno ste otkazali kartu!", "Uspešno!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Neuspešno brisanje! Ne možete obrisati kartu čiji je datum istekao ili je vožnja za manje od 24h!", "Neuspešno!", MessageBoxButton.OK, MessageBoxImage.Error);

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
                var det = new IISAS.xaml_window.korisnik_stan_usluga.Pregled_kupljenih_karata_detaljnije(this, selectedKarta);
           
                det.ShowDialog();

            }
            else
            {
                MessageBox.Show("Molim Vas selektujte vožnju za koju želite da vidite detalje!", "Upozorenje!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }

        private void Oceni(object sender, RoutedEventArgs e)
        {
            if (lvDataBinding.SelectedItems.Count > 0)
            {
                
                Model.Karta selectedKarta = (Model.Karta)lvDataBinding.SelectedItems[0];

                if(selectedKarta.vazeca == "Nevazeca")
                {
                    var det = new IISAS.xaml_window.korisnik_stan_usluga.Pregled_kupljenih_karata_ocena(this, selectedKarta);

                    det.ShowDialog();
                }
                else
                    MessageBox.Show("Ne možete oceniti kartu čija vožnja nije istekla!", "Upozorenje!", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
                MessageBox.Show("Molim Vas selektujte vožnju za koju želite da kupite kartu!", "Upozorenje!", MessageBoxButton.OK, MessageBoxImage.Warning);

           
        }

        private void Korisnik_st_usluga_logout(object sender, RoutedEventArgs e)
        {
            var mn = new IISAS.MainWindow();
            mn.Show();
            this.Close();
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
                if (rbVazeca.IsChecked == true)
                {
                    if (rbDatum.IsChecked == true)
                    {
                        karte = kartaService.filterByDatumVazecaUsername(tbPretraga.Text, korisnik);
                    }
                    else if (rbPolaznaStanica.IsChecked == true)
                    {
                        karte = kartaService.filterByPolaznaVazecaUsername(tbPretraga.Text, korisnik);
                    }
                    else if (rbKrajnjaStanica.IsChecked == true)
                    {
                        karte = kartaService.filterByKrajnjaVazecaUsername(tbPretraga.Text, korisnik);
                    }
                    else if (rbPrevoznik.IsChecked == true)
                    {
                        karte = kartaService.filterByPrevoznikVazecaUsername(tbPretraga.Text, korisnik);
                    }
                }
                else if (rbNevazeca.IsChecked == true)
                {
                    if (rbDatum.IsChecked == true)
                    {
                        karte = kartaService.filterByDatumVazecaUsername(tbPretraga.Text, korisnik);
                    }
                    else if (rbPolaznaStanica.IsChecked == true)
                    {
                        karte = kartaService.filterByPolaznaNevazecaUsername(tbPretraga.Text, korisnik);
                    }
                    else if (rbKrajnjaStanica.IsChecked == true)
                    {
                        karte = kartaService.filterByKrajnjaNevazecaUsername(tbPretraga.Text, korisnik);
                    }
                    else if (rbPrevoznik.IsChecked == true)
                    {
                        karte = kartaService.filterByPrevoznikNevazecaUsername(tbPretraga.Text, korisnik);
                    }
                }
                else
                {
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
                }

                lvDataBinding.Items.Clear();
                foreach (Model.Karta karta in karte)
                {
                    if(karta.rezervisana == 0)
                    {
                        lvDataBinding.Items.Add(karta);
                    }
                    
                }
            }
        }

        private void RezervacijaKarata(object sender, RoutedEventArgs e)
        {
            var rk = new IISAS.xaml_window.korisnik_stan_usluga.Rezervacija_karata(korisnik);
            rk.Show();
            this.Close();
        }

        private void PregledRezervisanihKarata(object sender, RoutedEventArgs e)
        {
            var prk = new IISAS.xaml_window.korisnik_stan_usluga.Pregled_rezervisanih_karata(korisnik);
            prk.Show();
            this.Close();
        }

        private void rbSve_Checked(object sender, RoutedEventArgs e)
        {
            lvDataBinding.Items.Clear();
            karte = kartaService.getKarteByKorisnikOrdered(korisnik);
            

            foreach (Model.Karta karta in karte)
            {

                if (karta.rezervisana == 0)
                {
                    DateTime dt1 = DateTime.Parse(karta.voznja.datum.ToString()).Add(TimeSpan.Parse(karta.voznja.pol_sat.ToString()));
                    DateTime dt2 = DateTime.Now;
                    TimeSpan ts = dt1 - dt2;
                    double totalTime = ts.TotalHours;

                    if (totalTime <= 0)
                    {
                        karta.vazeca = "Nevazeca";

                        kartaService.Update(karta);
                    }

                    lvDataBinding.Items.Add(karta);

                }
            }
        }

        private void rbVazeca_Checked(object sender, RoutedEventArgs e)
        {
            lvDataBinding.Items.Clear();
            karte = kartaService.getKarteByKorisnikVazecaOrdered(korisnik);


            foreach (Model.Karta karta in karte)
            {

                if (karta.rezervisana == 0)
                {
                    DateTime dt1 = DateTime.Parse(karta.voznja.datum.ToString()).Add(TimeSpan.Parse(karta.voznja.pol_sat.ToString()));
                    DateTime dt2 = DateTime.Now;
                    TimeSpan ts = dt1 - dt2;
                    double totalTime = ts.TotalHours;

                    if (totalTime <= 0)
                    {
                        karta.vazeca = "Nevazeca";

                        kartaService.Update(karta);
                    }

                    lvDataBinding.Items.Add(karta);

                }
            }
        }

        private void rbNevazeca_Checked(object sender, RoutedEventArgs e)
        {
            lvDataBinding.Items.Clear();
            karte = kartaService.getKarteByKorisnikNevazecaOrdered(korisnik);


            foreach (Model.Karta karta in karte)
            {

                if (karta.rezervisana == 0)
                {
                    lvDataBinding.Items.Add(karta);

                }
            }
        }
    }
}
