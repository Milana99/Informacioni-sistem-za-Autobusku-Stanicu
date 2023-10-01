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
    /// Interaction logic for Upravljanje_terminima.xaml
    /// </summary>
    public partial class Upravljanje_terminima : Window
    {
        Service.VoznjaService voznjaService;
        List<Model.Voznja> voznje;
        Model.Korisnik korisnik;
        public Upravljanje_terminima(Model.Korisnik korisnik)
        {
            InitializeComponent();
            var voznjaRepository = new Repository.VoznjaRepository(new ASContext());
            voznjaService = new Service.VoznjaService(voznjaRepository);
            this.korisnik = korisnik;
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
            voznje = voznjaService.GetAll();

            foreach (Model.Voznja voznja in voznje)
            {
                lvDataBinding.Items.Add(voznja);
            }
            LoadStanice();

        }

        private void Korisnik_st_usluga_logout(object sender, RoutedEventArgs e)
        {
            var mw = new IISAS.MainWindow();
            mw.Show();
            this.Close();
        }

        private void Dodaj(object sender, RoutedEventArgs e)
        {
            var dodaj = new IISAS.xaml_window.admin_as.Upravljanje_terminima_dodaj(this);
            dodaj.Show();
        }

        private void Detaljnije(object sender, RoutedEventArgs e)
        {
            if(lvDataBinding.SelectedItems.Count > 0)
            {
                Model.Voznja selectedVoznja = (Model.Voznja)lvDataBinding.SelectedItems[0];
                var detalji = new IISAS.xaml_window.admin_as.Upravljanje_terminima_izmeni(selectedVoznja);
                detalji.Show();
            }
            else
            {
                MessageBox.Show("Molim Vas selektujte voznju za koju hocete da vidite detalje");
            }
            

        }

        private void Izmeni(object sender, RoutedEventArgs e)
        {
            if (lvDataBinding.SelectedItems.Count > 0)
            {
                Model.Voznja selectedVoznja = (Model.Voznja)lvDataBinding.SelectedItems[0];
                var izmeni = new IISAS.xaml_window.admin_as.Upravljanje_terminima_izmena(this, selectedVoznja);
                izmeni.Show();
            }
            else
            {
                MessageBox.Show("Molim Vas selektujte voznju koju hocete da izmenite");
            }
            
        }

        private void Obrisi(object sender, RoutedEventArgs e)
        {
            if (lvDataBinding.SelectedItems.Count > 0)
            {
                Model.Voznja selectedVoznja = (Model.Voznja)lvDataBinding.SelectedItems[0];
                voznjaService.DeleteElement(selectedVoznja.id_voz);
                LoadAll();
            }
            else
            {
                MessageBox.Show("Molim Vas selektujte voznju koju hocete da obrisete");
            }
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

        private void Popusti(object sender, RoutedEventArgs e)
        {
            var popust = new IISAS.xaml_window.admin_as.Upravljanje_popustima(korisnik);
            popust.Show();
            this.Close();
        }

        private void Cena(object sender, RoutedEventArgs e)
        {
            var cena = new IISAS.xaml_window.admin_as.Manipulacija_cene_voznje(korisnik);
            cena.Show();
            this.Close();
        }
    }
}
