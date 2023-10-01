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
    /// Interaction logic for Upravljanje_terminima_dodaj.xaml
    /// </summary>
    public partial class Upravljanje_terminima_dodaj : Window
    {
        public Upravljanje_terminima upravljanjeTerminima;
        public Upravljanje_terminima_dodaj(Upravljanje_terminima upravljanjeTerminima)
        {
            this.upravljanjeTerminima = upravljanjeTerminima;
            
            InitializeComponent();
            LoadAll();
            LoadPrevoznik();
        }

        public void LoadAll()
        {
            LoadStanice();
        }
        public void LoadPrevoznik()
        {
            var autoprevoznikRepository = new Repository.AutoprevoznikRepository(new ASContext());
            var autoprevoznikService = new Service.AutoprevoznikService(autoprevoznikRepository);
            List<Model.Autoprevoznik> autoprevoznici = autoprevoznikService.GetAll();
            foreach (Model.Autoprevoznik prevoznik in autoprevoznici)
            {
                cbPrevoznik.Items.Add(prevoznik.naziv_prev);
            }
        }
        public void LoadStanice()
        {
            var stanicaRepository = new Repository.StanicaRepository(new ASContext());
            var stanicaService = new Service.StanicaService(stanicaRepository);
            List<Model.Stanica> stanice = stanicaService.GetAll();
            foreach (Model.Stanica stanica in stanice)
            {
                cbPocetna.Items.Add(stanica.naz_stan);
                cbKrajnja.Items.Add(stanica.naz_stan);
            }
        }

        private void Izadji(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Dodaj(object sender, RoutedEventArgs e)
        {
            var voznjaRepository = new Repository.VoznjaRepository(new ASContext());
            Service.VoznjaService voznjaService = new Service.VoznjaService(voznjaRepository);
            var stanicaRepository = new Repository.StanicaRepository(new ASContext());
            var stanicaService = new Service.StanicaService(stanicaRepository);
            var autobusRepository = new Repository.AutobusRepository(new ASContext());
            var autobusService = new Service.AutobusService(autobusRepository);

            int kapacitet = autobusService.GetOne(int.Parse(cbAutobus.Text)).kap_aut;
            String preko = "";
            if (rbAutoput.IsChecked == true)
            {
                preko = "Autoput";
            }
            else
            {
                preko = "Sela";
            }
            Model.Voznja voznja = new Model.Voznja(tbDolazno.Text, tbPolaznoVreme.Text,
                stanicaService.GetIdByName(cbPocetna.Text), stanicaService.GetIdByName(cbKrajnja.Text), int.Parse(cbAutobus.Text), preko,
                0, int.Parse(cbPeron.Text), dpDatum.Text, kapacitet);
            voznjaService.CreateElement(voznja);

            upravljanjeTerminima.LoadAll();
            this.Close();
        }

        private void cbPocetna_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try{
                cbPeron.Items.Clear();
                var peronRepository = new Repository.PeronRepository(new ASContext());
                var peronService = new Service.PeronService(peronRepository);
                List<Model.Peron> peroni = peronService.GetAllByStanica(cbPocetna.SelectedItem.ToString());
                foreach (Model.Peron peron in peroni)
                {
                    cbPeron.Items.Add(peron.id_per);
                }
              
            }
            catch
            {

            }
            
        }

        private void cbPrevoznik_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                cbAutobus.Items.Clear();
                var autobusRepository = new Repository.AutobusRepository(new ASContext());
                var autobusService = new Service.AutobusService(autobusRepository);
                List<Model.Autobus> autobusi = autobusService.getAllByPrevoznik(cbPrevoznik.SelectedItem.ToString());
                foreach (Model.Autobus autobus in autobusi)
                {
                    cbAutobus.Items.Add(autobus.id_aut);
                }
            }
            catch
            {

            }
        }
    }
}
