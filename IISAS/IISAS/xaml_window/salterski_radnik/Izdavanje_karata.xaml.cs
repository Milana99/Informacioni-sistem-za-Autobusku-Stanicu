using IISAS.Model;
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

namespace IISAS.xaml_window.salterski_radnik
{
    /// <summary>
    /// Interaction logic for Izdavanje_karata.xaml
    /// </summary>
    public partial class Izdavanje_karata : Window
    {
        Model.Korisnik korisnik;
        Service.VoznjaService voznjaService;
        List<Model.Voznja> voznje;
        public Izdavanje_karata(Model.Korisnik korisnik)
        {
            InitializeComponent();

            this.korisnik = korisnik;
            var asContext = new ASContext();
            var voznjaRepository = new Repository.VoznjaRepository(asContext);
            voznjaService = new Service.VoznjaService(voznjaRepository);
            LoadAll();
            lbUser.Content = korisnik.username;
            lbStatus.Content = korisnik.tip_korisnika;
            dpDatum.DisplayDateStart = DateTime.Now;
            dpDatum.SelectedDate = DateTime.Now;
        }

        public void LoadAll()
        {
            lvDataBinding.Items.Clear();
            voznje = voznjaService.OrderedVoznja();

            foreach (Model.Voznja voznja in voznje)
            {
                if (voznja.datum == DateTime.Now.ToShortDateString())
                    lvDataBinding.Items.Add(voznja);

            }
            LoadStanice();

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int brojac = 0; 
            if ((Regex.IsMatch(tbVreme.Text, @"^([01]?[0-9]|2[0-3]):[0-5][0-9]$")) || (tbVreme.Text == ""))
            {
                voznje = voznjaService.SearchByParam(cbPocetnaStanica.Text, cbKrajnjaStanica.Text, tbVreme.Text, dpDatum.Text);
                lvDataBinding.Items.Clear();

                foreach (Model.Voznja voznja in voznje)
                {
                    lvDataBinding.Items.Add(voznja);
                    brojac++; 
                }
                if(brojac==0)
                    MessageBox.Show("Za datu pretragu ne postoje vožnje!", "Informacija!", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
                MessageBox.Show("Vreme Vam nije u dobrom formatu! Trebalo bi da bude npr. 14:30!", "Upozorenje!", MessageBoxButton.OK, MessageBoxImage.Warning);
            
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
                        var kk = new IISAS.xaml_window.salterski_radnik.Izdavanje_karata_kupi(selectedVoznja, this, korisnik);
                        kk.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Za izabranu voznju nema slobodnih karata!", "Upozorenje!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Neuspešna kupovina! Ne možete kupiti kartu čiji je datum istekao!", "Neuspešno!", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            else
                MessageBox.Show("Molim Vas selektujte vožnju za koju želite da kupite kartu!", "Upozorenje!", MessageBoxButton.OK, MessageBoxImage.Warning);

        }

        private void Korisnik_st_usluga_logout(object sender, RoutedEventArgs e)
        {
            var mw = new IISAS.MainWindow();
            mw.Show();
            this.Close();
        }

        private void PregledRezervisanihKarata(object sender, RoutedEventArgs e)
        {
            var prk = new IISAS.xaml_window.salterski_radnik.Pregled_rezervisanih_karata(korisnik);
            prk.Show();
            this.Close();
        }

        private void RezervacijaKarte(object sender, RoutedEventArgs e)
        {
            var rk = new IISAS.xaml_window.salterski_radnik.Rezervacija_karata(korisnik);
            rk.Show();
            this.Close();
        }

        private void Red_voznje(object sender, RoutedEventArgs e)
        {

        }
        private void PregledIzdatihKarata(object sender, RoutedEventArgs e)
        {
            var ik = new IISAS.xaml_window.salterski_radnik.Izdate_karte(korisnik);
            ik.Show();
            this.Close();
        }
    }
}
