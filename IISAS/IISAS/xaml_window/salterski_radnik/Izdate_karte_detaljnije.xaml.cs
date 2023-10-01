using IISAS.xaml_window.korisnik_stan_usluga;
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

namespace IISAS.xaml_window.salterski_radnik
{
    /// <summary>
    /// Interaction logic for Izdate_karte_detaljnije.xaml
    /// </summary>
    public partial class Izdate_karte_detaljnije : Window
    {
        public Izdate_karte ik;
        Model.Karta karta;
        public Izdate_karte_detaljnije(Izdate_karte ik, Model.Karta karta)
        {
            InitializeComponent();
            this.ik = ik;
            this.karta = karta;
            LoadAll();
        }

        public void LoadAll()
        {
            lbCena.Content = karta.cena;
            lbDatum.Content = karta.voznja.datum;
            lbKrajnjaStanica.Content = karta.voznja.krajnja_stan.naz_stan;
            lbPeron.Content = karta.voznja.peron.naz_per;
            lbPocetnaStanica.Content = karta.voznja.polazna_stan.naz_stan;
            lbPreko.Content = karta.voznja.preko;
            lbPrevoznik.Content = karta.voznja.autobus.autoprev.naziv_prev;
            lbSediste.Content = karta.broj_sedista;
            lbStatusKarte.Content = karta.vazeca;
            lbVremeDolaska.Content = karta.voznja.dol_sat;
            lbVremePolaska.Content = karta.voznja.pol_sat;
            lbVrstaKarte.Content = karta.vrsta_karte;
            lbDatumKupovine.Content = karta.datum;
        }

        private void Izadji(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
