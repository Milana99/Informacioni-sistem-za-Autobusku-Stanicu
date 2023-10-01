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

namespace IISAS.xaml_window.korisnik_stan_usluga
{
    /// <summary>
    /// Interaction logic for Kupovina_karte.xaml
    /// </summary>
    public partial class Kupovina_karte : Window
    {
        public MainWindow mw;
        public xaml_window.korisnik_stan_usluga.RedVoznjeDetaljnije rv;
        Service.VoznjaService voznjaService;
        List<Model.Voznja> voznje;
        Model.Korisnik korisnik;
        public Kupovina_karte(Model.Korisnik korisnik)
        {
            
            InitializeComponent();
            var voznjaRepository = new Repository.VoznjaRepository(new ASContext());
            voznjaService = new Service.VoznjaService(voznjaRepository);
            LoadAll();
            this.korisnik = korisnik;
            lbUser.Content = korisnik.username;
            lbStatus.Content = korisnik.status_korisnika;
        }

        public void LoadStanice()
        {
            
            cbPocetnaStanica.Items.Clear();
            cbKrajnjaStanica.Items.Clear();
            var stanicaRepository = new Repository.StanicaRepository(new ASContext());
            var stanicaService = new Service.StanicaService(stanicaRepository);
            List<Model.Stanica> stanice = stanicaService.GetAll();
            foreach(Model.Stanica stanica in stanice)
            {
                cbKrajnjaStanica.Items.Add(stanica.naz_stan);
                cbPocetnaStanica.Items.Add(stanica.naz_stan);
            }
        }

        public void LoadAll()
        {
            lvDataBinding.Items.Clear();
            voznje = voznjaService.GetAll();

            foreach(Model.Voznja voznja in voznje)
            {
                if(voznja.datum == DateTime.Now.ToShortDateString())
                    lvDataBinding.Items.Add(voznja);
            }
            LoadStanice();

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Korisnik_st_usluga_logout(object sender, RoutedEventArgs e)
        {
            var mw = new IISAS.MainWindow();
            mw.Show();
            this.Close();
        }

        private void Detaljinije(object sender, RoutedEventArgs e)
        {
            Model.Voznja selectedVoznja = (Model.Voznja)lvDataBinding.SelectedItems[0];
            
            var rv = new IISAS.xaml_window.korisnik_stan_usluga.RedVoznjeDetaljnije(selectedVoznja);
            rv.Show();
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            var kk = new IISAS.xaml_window.korisnik_stan_usluga.Kupovina_karata_prava(korisnik);
            kk.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            voznje = voznjaService.SearchByParam(cbPocetnaStanica.Text, cbKrajnjaStanica.Text, tbVreme.Text, dpDatum.Text);
            lvDataBinding.Items.Clear();

            foreach (Model.Voznja voznja in voznje)
            {
                lvDataBinding.Items.Add(voznja);
            }
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
    }
}
