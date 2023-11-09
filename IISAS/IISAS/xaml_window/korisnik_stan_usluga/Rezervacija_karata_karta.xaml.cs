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
    /// Interaction logic for Rezervacija_karata_karta.xaml
    /// </summary>
    public partial class Rezervacija_karata_karta : Window
    {

        Rezervacija_karata_rezervisi rezervisi;
        Rezervacija_karata rk;
        Model.Korisnik korisnik;
        public Rezervacija_karata_karta(Rezervacija_karata_rezervisi rezervisi, Rezervacija_karata rk, Model.Korisnik korisnik)
        {
            InitializeComponent();
            this.rk = rk;
            this.korisnik = korisnik;
            this.rezervisi = rezervisi;
            Load();
        }


        public void Load()
        {
            float popust = 1;
            if (rezervisi.cbTipKarte.SelectedItem.ToString() == "Povratna")
            {
                popust *= (rezervisi.voznja.popustPovratna + 1);
            }
            if (korisnik.status_korisnika == "Penzioner")
            {
                popust *= rezervisi.voznja.popustPenzioner;
            }
            if (korisnik.status_korisnika == "Student")
            {
                popust *= rezervisi.voznja.popustStudentska;
            }

            lbCena.Content = rezervisi.voznja.cena * popust;

            lbStatusPutnika.Content = korisnik.status_korisnika;
            lbDatum.Content = rezervisi.voznja.datum;
            lbKrajnjaStanica.Content = rezervisi.voznja.krajnja_stan.naz_stan;
            lbPeron.Content = rezervisi.voznja.peron.naz_per;
            lbPocetnaStanica.Content = rezervisi.voznja.polazna_stan.naz_stan;
            lbPreko.Content = rezervisi.voznja.preko;
            lbPrevoznik.Content = rezervisi.voznja.autobus.autoprev.naziv_prev;
            lbSediste.Content = (rezervisi.voznja.autobus.kap_aut - rezervisi.voznja.brSlobodnih + 1);
            lbVremeDolaska.Content = rezervisi.voznja.dol_sat;
            lbVremePolaska.Content = rezervisi.voznja.pol_sat;
            lbVrstaKarte.Content = rezervisi.cbTipKarte.Text;
            lbVremeKupovine.Content = DateTime.Now.ToString();
        }

        private void Rezervisi(object sender, RoutedEventArgs e)
        {
            var kartaRepository = new Repository.KartaRepository(new ASContext());
            var kartaService = new Service.KartaService(kartaRepository);
            Model.Karta karta = new Model.Karta(rezervisi.voznja.id_voz, int.Parse(lbSediste.Content.ToString()),
                int.Parse(lbCena.Content.ToString()), lbVrstaKarte.Content.ToString() + "-" + lbStatusPutnika.Content.ToString(), "Vazeca", korisnik.id_kor, 1, lbVremeKupovine.Content.ToString(), "Korisnik", korisnik.ime, korisnik.prezime);

            kartaService.CreateElement(karta);
            rezervisi.voznja.brSlobodnih--;

            var voznjaRepository = new Repository.VoznjaRepository(new ASContext());
            var voznjaService = new Service.VoznjaService(voznjaRepository);
            voznjaService.Update(rezervisi.voznja);
            rk.LoadAll();
            rk.dpDatum.SelectedDate = DateTime.Now;
            rezervisi.Close();
            this.Close();
            MessageBox.Show("Uspešno ste rezervisali kartu!", "Uspešno!", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void Izadji(object sender, RoutedEventArgs e)
        {
            this.Close();
            rezervisi.Show();
        }
    }
}
