using IISAS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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
    /// Interaction logic for Rezervacija_karata.xaml
    /// </summary>
    public partial class Rezervacija_karata : Window
    {
        Model.Korisnik korisnik;
        Service.VoznjaService voznjaService;
        List<Model.Voznja> voznje;
        public Rezervacija_karata(Model.Korisnik korisnik)
        {
            InitializeComponent();
            this.korisnik = korisnik;
            lbStatus.Content = korisnik.status_korisnika;
            lbUser.Content = korisnik.username;
            var voznjaRepository = new Repository.VoznjaRepository(new ASContext());
            voznjaService = new Service.VoznjaService(voznjaRepository);
            dpDatum.DisplayDateStart = DateTime.Now;
            dpDatum.SelectedDate = DateTime.Now;
            LoadAll();
        }

        public void LoadStanice()
        {
            cbKrajnjaStanica.Items.Clear();
            cbPocetnaStanica.Items.Clear();
            var stanicaRepository = new Repository.StanicaRepository(new ASContext());
            var stanicaService = new Service.StanicaService(stanicaRepository);
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
            voznje = voznjaService.GetAllRecent();

            foreach (Model.Voznja voznja in voznje)
            {
                if (voznja.datum == DateTime.Now.ToShortDateString())
                    lvDataBinding.Items.Add(voznja);

            }
            LoadStanice();

        }

        private void Red_voznje(object sender, RoutedEventArgs e)
        {
            var rv = new IISAS.xaml_window.korisnik_stan_usluga.Kupovina_karte(korisnik);
            rv.Show();
            this.Close();
        }

        private void Kupovina_karte(object sender, RoutedEventArgs e)
        {
            var kk = new IISAS.xaml_window.korisnik_stan_usluga.Kupovina_karata_prava(korisnik);
            kk.Show();
            this.Close();
        }

        private void PregledKarata(object sender, RoutedEventArgs e)
        {
            var pkk = new IISAS.xaml_window.korisnik_stan_usluga.Pregled_kupljenih_karata(korisnik);
            pkk.Show();
            this.Close();
        }

        private void Korisnik_st_usluga_logout(object sender, RoutedEventArgs e)
        {
            var mw = new IISAS.MainWindow();
            mw.Show();
            this.Close();
        }

        private void Rezervisi(object sender, RoutedEventArgs e)
        {
            if (lvDataBinding.SelectedItems.Count > 0)
            {
                Model.Voznja selectedVoznja = (Model.Voznja)lvDataBinding.SelectedItems[0];
                DateTime dt1 = DateTime.Parse(selectedVoznja.datum.ToString()).Add(TimeSpan.Parse(selectedVoznja.pol_sat.ToString()));
                DateTime dt2 = DateTime.Now;
                TimeSpan ts = dt1 - dt2;
                double totalTime = ts.TotalHours;

                if (totalTime > 48)
                {

                    if (selectedVoznja.brSlobodnih > 0)
                    {
                        var rk = new IISAS.xaml_window.korisnik_stan_usluga.Rezervacija_karata_rezervisi(selectedVoznja, this, korisnik);
                        rk.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Za izabranu vožnju nema slobodnih karata!", "Upozorenje!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Neuspešna rezervacija! Ne možete rezervisati kartu čiji je datum istekao ili je vožnja za manje od 48h!", "Neuspešno!", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            else
                MessageBox.Show("Molim Vas selektujte vožnju za koju želite da rezervišete kartu!", "Upozorenje!", MessageBoxButton.OK, MessageBoxImage.Warning);

        }

        private void Pretraga(object sender, RoutedEventArgs e)
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
                    MessageBox.Show("Za datu pretragu ne postoje vožnje!", "Informacija!", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
                MessageBox.Show("Vreme Vam nije u dobrom formatu! Trebalo bi da bude npr. 14:30!", "Upozorenje!", MessageBoxButton.OK, MessageBoxImage.Warning);

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
