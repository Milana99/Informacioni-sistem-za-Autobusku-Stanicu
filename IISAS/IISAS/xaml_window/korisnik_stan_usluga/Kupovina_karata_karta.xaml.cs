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
    /// Interaction logic for Kupovina_karata_karta.xaml
    /// </summary>
    public partial class Kupovina_karata_karta : Window
    {
        Kupovina_karata_kupi kupovina;
        Kupovina_karata_prava kkp;
        Model.Korisnik korisnik;

        public Kupovina_karata_karta(Kupovina_karata_kupi kupovina, Kupovina_karata_prava kkp, Model.Korisnik korisnik)
        {
            this.kupovina = kupovina;
            InitializeComponent();
            this.kkp = kkp;
            this.korisnik = korisnik;
            Load();
        }

        public void Load()
        {
            float popust = 1;
            if (kupovina.cbTipKarte.SelectedItem.ToString() == "Povratna")
            {
                popust *= (kupovina.voznja.popustPovratna + 1);
            }
            if (korisnik.status_korisnika == "Penzioner")
            {
                popust *= kupovina.voznja.popustPenzioner;
            }
            if (korisnik.status_korisnika == "Student")
            {
                popust *= kupovina.voznja.popustStudentska;
            }

            lbCena.Content = kupovina.voznja.cena * popust;

            lbStatusPutnika.Content = korisnik.status_korisnika;
            lbDatum.Content = kupovina.voznja.datum;
            lbKrajnjaStanica.Content = kupovina.voznja.krajnja_stan.naz_stan;
            lbPeron.Content = kupovina.voznja.peron.naz_per;
            lbPocetnaStanica.Content = kupovina.voznja.polazna_stan.naz_stan;
            lbPreko.Content = kupovina.voznja.preko;
            lbPrevoznik.Content = kupovina.voznja.autobus.autoprev.naziv_prev;
            lbSediste.Content = (kupovina.voznja.autobus.kap_aut - kupovina.voznja.brSlobodnih + 1);
            lbVremeDolaska.Content = kupovina.voznja.dol_sat;
            lbVremePolaska.Content = kupovina.voznja.pol_sat;
            lbVrstaKarte.Content = kupovina.cbTipKarte.Text;
            lbVremeKupovine.Content = DateTime.Now.ToString();
        }



        private void Izadji(object sender, RoutedEventArgs e)
        {
            this.Close();
            kupovina.Show();

        }

        private void Kupi(object sender, RoutedEventArgs e)
        {
            var kartaRepository = new Repository.KartaRepository(new ASContext());
            var kartaService = new Service.KartaService(kartaRepository);
            Model.Karta karta = new Model.Karta(kupovina.voznja.id_voz, int.Parse(lbSediste.Content.ToString()),
                int.Parse(lbCena.Content.ToString()), lbVrstaKarte.Content.ToString() + "-" + lbStatusPutnika.Content.ToString(), "Vazeca", korisnik.id_kor, 0, lbVremeKupovine.Content.ToString(), "Korisnik");

            kartaService.CreateElement(karta);
            kupovina.voznja.brSlobodnih--;

            var voznjaRepository = new Repository.VoznjaRepository(new ASContext());
            var voznjaService = new Service.VoznjaService(voznjaRepository);
            voznjaService.Update(kupovina.voznja);
            kkp.LoadAll();
            kkp.dpDatum.SelectedDate = DateTime.Now;
            kupovina.Close();
            this.Close();
            MessageBox.Show("Uspešno ste kupili kartu!", "Uspešno!", MessageBoxButton.OK, MessageBoxImage.Information);


        }
    }
}
