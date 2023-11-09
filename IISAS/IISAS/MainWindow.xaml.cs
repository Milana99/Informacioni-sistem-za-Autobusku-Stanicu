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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IISAS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Service.VoznjaService voznjaService;
        Model.Korisnik korisnik;
        List<Model.Voznja> voznje;

        xaml_window.korisnik_stan_usluga.Kupovina_karte red_voznje_window; 
        public MainWindow()
        {
            InitializeComponent();

            var asContext = new ASContext();
            var voznjaRepository = new Repository.VoznjaRepository(asContext);
            voznjaService = new Service.VoznjaService(voznjaRepository);
            LoadAll();
        }
        public void LoadStanice()
        {
            cbPocetnaStanica.Items.Clear();
            cbKrajnjaStanica.Items.Clear();
            var asContext = new ASContext();
            var stanicaRepository = new Repository.StanicaRepository(asContext);
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
            voznje = voznjaService.GetAll();

            LoadStanice();

        }

        private void Korisnik_stanicnih_usluga(object sender, RoutedEventArgs e)
        {
            var redVoznje = new IISAS.xaml_window.korisnik_stan_usluga.Kupovina_karte(null);
            redVoznje.Show();
            this.Close();
        }

        private void Admin_AS(object sender, RoutedEventArgs e)
        {
            var aas = new IISAS.xaml_window.admin_as.Upravljanje_terminima(korisnik);
            aas.Show();
            this.Close();
        }


        private void Prijava(object sender, RoutedEventArgs e)
        {
            var prijava = new IISAS.xaml_window.Login();
            prijava.Show();
            this.Close();
        }

        /*private void Admin(object sender, RoutedEventArgs e)
        {
            var admin = new IISAS.xaml_window.admin.Upravljanje_statusima_korisnika(korisnik);
            admin.Show();
            this.Close();
        }
        */
        private void Detaljinije(object sender, RoutedEventArgs e)
        {
            Model.Voznja selectedVoznja = (Model.Voznja)lvDataBinding.SelectedItems[0];
            var detaljnije = new IISAS.xaml_window.obican_korisnik.Red_voznje_detaljnije(selectedVoznja);
            detaljnije.Show();

        }

        private void UvidUPerone(object sender, RoutedEventArgs e)
        {
            var peron = new IISAS.xaml_window.obican_korisnik.Uvid_u_perone();
            peron.Show();
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
            voznje = voznjaService.SearchByParam(cbPocetnaStanica.Text, cbKrajnjaStanica.Text, tbVreme.Text, dpDatum.Text);
            lvDataBinding.Items.Clear();

            foreach (Model.Voznja voznja in voznje)
            {
                lvDataBinding.Items.Add(voznja);
            }
        }
    }
}
