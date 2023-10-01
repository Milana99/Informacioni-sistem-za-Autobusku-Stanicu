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
    /// Interaction logic for RedVoznjeDetaljnije.xaml
    /// </summary>
    public partial class RedVoznjeDetaljnije : Window
    {
        xaml_window.korisnik_stan_usluga.Kupovina_karte rv;
        Model.Voznja voznja;
        public RedVoznjeDetaljnije(Model.Voznja voznja)
        {
            InitializeComponent();
            this.voznja = voznja;
            Load();
        }

        public void Load()
        {
            lbVremePolaska.Content = voznja.pol_sat;
            lbVremeDolaska.Content = voznja.dol_sat;
            lbDatum.Content = voznja.datum;
            lbKrajnjaStanica.Content = voznja.krajnja_stan.naz_stan;
            lbPocetnaStanica.Content = voznja.polazna_stan.naz_stan;
            lbPrevoznik.Content = voznja.autobus.autoprev.naziv_prev;
            lbPreko.Content = voznja.preko;
            lbPeron.Content = voznja.peron.naz_per;
            lbPreostalihKarata.Content = voznja.brSlobodnih;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }

        private void PregledSedista(object sender, RoutedEventArgs e)
        {
            var sed = new IISAS.xaml_window.korisnik_stan_usluga.RedVoznjeSedista();
            sed.Show();
        }
    }
}
