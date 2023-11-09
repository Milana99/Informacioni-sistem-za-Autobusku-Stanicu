using IISAS.Model;
using IISAS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Kupovina_karata_prava.xaml
    /// </summary>
    public partial class Kupovina_karata_prava : Window
    {
        Service.VoznjaService voznjaService;
        List<Model.Voznja> voznje;
        Model.Korisnik korisnik;
        public Kupovina_karata_prava(Model.Korisnik korisnik)
        {
            InitializeComponent();
            var voznjaRepository = new Repository.VoznjaRepository(new ASContext());
            voznjaService = new Service.VoznjaService(voznjaRepository);
           
            this.korisnik = korisnik;
            LoadAll();

            lbUser.Content = korisnik.username;
            lbStatus.Content = korisnik.status_korisnika;
            dpDatum.DisplayDateStart = DateTime.Now;
            dpDatum.SelectedDate = DateTime.Now;
        }
        public void LoadStanice()
        {
            cbKrajnjaStanica.Items.Clear();
            cbPocetnaStanica.Items.Clear();
            var stanicaRepository = new Repository.StanicaRepository(new ASContext());
            var stanicaService = new Service.StanicaService(stanicaRepository);
            var kartaRepository = new Repository.KartaRepository(new ASContext());
            var kartaService = new Service.KartaService(kartaRepository);

            List<Model.Karta> lastKarte = kartaService.GetRecentByKorisnik(korisnik);
            List<Model.Stanica> stanice = stanicaService.GetAll();

            foreach (Model.Stanica stanica in stanice)
            {
                cbKrajnjaStanica.Items.Add(stanica.naz_stan);
                cbPocetnaStanica.Items.Add(stanica.naz_stan);
            }
        }

        public void LoadAll()
        {
            lvDataBinding.Items.Clear();
            voznje = voznjaService.OrdereVoznja();
            var kartaRepository = new Repository.KartaRepository(new ASContext());
            var kartaService = new Service.KartaService(kartaRepository);

            //List<Model.Karta> lastKarte = kartaService.GetRecentByKorisnik(korisnik);
            List<Model.Voznja> recentVoznje = new List<Voznja>();
            //foreach(Model.Karta karta in lastKarte)
            //{
                recentVoznje.AddRange(voznjaService.FilterByStanicaRecent(voznje, "Sid AS", "Novi Sad AS"));
           // }

            recentVoznje = recentVoznje.Distinct().ToList();

            foreach (Model.Voznja voznja in recentVoznje)
            {
                if (voznja.datum == DateTime.Now.ToShortDateString())
                    lvDataBinding.Items.Add(voznja);
                
            }
            
            LoadStanice();

        }

        private void Kupi(object sender, RoutedEventArgs e)
        {
            
            if (lvDataBinding.SelectedItems.Count > 0)
            {
                Model.Voznja selectedVoznja = (Model.Voznja)lvDataBinding.SelectedItems[0];
                DateTime dt1 = DateTime.Parse(selectedVoznja.datum.ToString()).Add(TimeSpan.Parse(selectedVoznja.pol_sat.ToString()));
                DateTime dt2 = DateTime.Now;
                TimeSpan ts = dt1 - dt2;
                double totalTime = ts.TotalHours;

                if (totalTime >= 0)
                {
                    if (selectedVoznja.brSlobodnih > 0)
                    {
                        var kk = new IISAS.xaml_window.korisnik_stan_usluga.Kupovina_karata_kupi(selectedVoznja, this, korisnik);
                        kk.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Za izabranu voznju nema slobodnih karata!", "Raketa", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Neuspešna kupovina! Ne možete kupiti kartu čiji je datum istekao!", "Raketa", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            else
                MessageBox.Show("Molim Vas selektujte vožnju za koju želite da kupite kartu!", "Raketa", MessageBoxButton.OK, MessageBoxImage.Warning);
            

        }

        private void Korisnik_st_usluga_logout(object sender, RoutedEventArgs e)
        {
            var mw = new IISAS.MainWindow();
            mw.Show();
            this.Close();
        }

        private void Red_voznje(object sender, RoutedEventArgs e)
        {
            var rv = new IISAS.xaml_window.korisnik_stan_usluga.Kupovina_karte(korisnik);
            rv.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int brojac = 0; 
            if ((Regex.IsMatch(tbVreme.Text, @"^([01]?[0-9]|2[0-3]):[0-5][0-9]$")) || (tbVreme.Text == ""))
            {
                voznje = voznjaService.SearchByParam(cbPocetnaStanica.Text, cbKrajnjaStanica.Text, tbVreme.Text, dpDatum.Text);
                lvDataBinding.Items.Clear();

                if (cbPrevoznik.SelectedItem != null)
                {
                    voznje = voznjaService.SearchByPrevoznik(voznje, cbPrevoznik.Text);
                }

                voznje = voznjaService.FilterByTipPuta(cbAutoput.IsChecked.Value, cbSporedniPut.IsChecked.Value, voznje);


                foreach (Model.Voznja voznja in voznje)
                {
                    lvDataBinding.Items.Add(voznja);
                    brojac++;
                }
                if (brojac == 0)
                    MessageBox.Show("Za datu pretragu ne postoje vožnje!", "Raketa", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
                MessageBox.Show("Vreme Vam nije u dobrom formatu! Trebalo bi da bude npr. 14:30!", "Raketa", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void PregledKarata(object sender, RoutedEventArgs e)
        {
            var pkk = new IISAS.xaml_window.korisnik_stan_usluga.Pregled_kupljenih_karata(korisnik);
            pkk.Show();
            this.Close();
        }

        private void RezervacijaKarte(object sender, RoutedEventArgs e)
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

        private void KrajnjaStanicaChanged(object sender, SelectionChangedEventArgs e)
        {
            cbPrevoznik.Items.Clear();
            foreach (Voznja voznja in voznjaService.FilterByKrajnja(cbKrajnjaStanica.Text.ToString()))
            {
                if (!cbPrevoznik.Items.Contains(voznja.autobus.autoprev.naziv_prev))
                {
                    cbPrevoznik.Items.Add(voznja.autobus.autoprev.naziv_prev);
                }
            }
        }
    }
}
