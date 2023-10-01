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
    /// Interaction logic for Upravljanje_terminima_izmena.xaml
    /// </summary>
    public partial class Upravljanje_terminima_izmena : Window
    {
        Upravljanje_terminima upravljanje_Terminima;
        Model.Voznja voznja;
        public Upravljanje_terminima_izmena(Upravljanje_terminima upravljanje_Terminima, Model.Voznja voznja)
        {
            this.upravljanje_Terminima = upravljanje_Terminima;
            this.voznja = voznja;
            InitializeComponent();
            LoadAll();
            
        }
        public void LoadAll()
        {
            LoadPrevoznik();
            LoadStanice();
            LoadSelected();
        }

        public void LoadSelected()
        {
            cbPrevoznik.SelectedItem = voznja.autobus.autoprev.naziv_prev;
            cbAutobus.SelectedItem = voznja.autobus.id_aut;
            cbPocetna.SelectedItem = voznja.polazna_stan.naz_stan;
            cbKrajnja.SelectedItem = voznja.krajnja_stan.naz_stan;
            cbPeron.SelectedItem = voznja.peron.id_per;

            tbDolazno.Text = voznja.dol_sat;
            tbPolaznoVreme.Text = voznja.pol_sat;
            dpDatum.Text = voznja.datum;

            if(voznja.preko == "Autoput")
            {
                rbAutoput.IsChecked = true;

            }
            else
            {
                rbSela.IsChecked = true;
            }

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

        private void Izmeni(object sender, RoutedEventArgs e)
        {
            String preko = "";
            if (rbAutoput.IsChecked == true)
            {
                preko = "Autoput";
            }
            else
            {
                preko = "Sela";
            }

            var stanicaRepository = new Repository.StanicaRepository(new ASContext());
            var stanicaService = new Service.StanicaService(stanicaRepository);
            var autobusRepository = new Repository.AutobusRepository(new ASContext());
            var autobusService = new Service.AutobusService(autobusRepository);
            var peronRepository = new Repository.PeronRepository(new ASContext());
            var peronService = new Service.PeronService(peronRepository);
            var voznjaRepository = new Repository.VoznjaRepository(new ASContext());
            var voznjaService = new Service.VoznjaService(voznjaRepository);

            voznja.dol_sat = tbDolazno.Text;
            voznja.pol_sat = tbPolaznoVreme.Text;
            voznja.polazna_stan = stanicaService.GetOne(stanicaService.GetIdByName(cbPocetna.Text));
            voznja.krajnja_stan = stanicaService.GetOne(stanicaService.GetIdByName(cbKrajnja.Text));
            voznja.autobus = autobusService.GetOne(int.Parse(cbAutobus.Text));
            voznja.preko = preko;
            voznja.peron = peronService.GetOne(int.Parse(cbPeron.Text));
            voznja.datum = dpDatum.Text;

            voznjaService.Update(voznja);

            upravljanje_Terminima.LoadAll();
            this.Close();
        }

        private void Izadji(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbPocetna_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
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
