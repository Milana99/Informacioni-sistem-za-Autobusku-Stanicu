using IISAS.Model;
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
    /// Interaction logic for Izdavanje_karata_karta.xaml
    /// </summary>
    public partial class Izdavanje_karata_karta : Window
    {
        Izdavanje_karata_kupi kupovina;
        Izdavanje_karata ik;
        Model.Korisnik korisnik;

        public Izdavanje_karata_karta(Izdavanje_karata_kupi kupovina, Izdavanje_karata ik, Model.Korisnik korisnik)
        {
            InitializeComponent();
            this.kupovina = kupovina;
            this.ik = ik;
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
            if (kupovina.cbStatus.SelectedItem.ToString() == "Penzioner")
            {
                popust *= kupovina.voznja.popustPenzioner;
            }
            if (kupovina.cbStatus.SelectedItem.ToString() == "Student")
            {
                popust *= kupovina.voznja.popustStudentska;
            }

            lbCena.Content = kupovina.voznja.cena * popust;

            lbStatusPutnika.Content = kupovina.cbStatus.SelectedItem.ToString();
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

        private void Kupi(object sender, RoutedEventArgs e)
        {
            var korisnikRepository = new Repository.KorisnikRepository(new ASContext());
            var korisnikService = new Service.KorisnikService(korisnikRepository);
            var kartaRepository = new Repository.KartaRepository(new ASContext());
            var kartaService = new Service.KartaService(kartaRepository);

            Model.Korisnik korisnikk = korisnikService.GetOne(kupovina.tbKorisnickoIme.Text.ToString());

            //Todo change this  to textbox.text
            var ime = "Jon";
            var prezime = "Doe";

            if (korisnikk == null)
            {
                Model.Karta karta = new Model.Karta(kupovina.voznja.id_voz, int.Parse(lbSediste.Content.ToString()),
                    int.Parse(lbCena.Content.ToString()), lbVrstaKarte.Content.ToString() + "-" + lbStatusPutnika.Content.ToString(), "Vazeca", korisnik.id_kor, 0, lbVremeKupovine.Content.ToString(), korisnik.username, ime, prezime);
                kartaService.CreateElement(karta);
            }
            else
            {
                Model.Karta karta = new Model.Karta(kupovina.voznja.id_voz, int.Parse(lbSediste.Content.ToString()),
                  int.Parse(lbCena.Content.ToString()), lbVrstaKarte.Content.ToString() + "-" + lbStatusPutnika.Content.ToString(), "Vazeca", korisnikk.id_kor, 0, lbVremeKupovine.Content.ToString(), korisnik.username, korisnikk.ime, korisnikk.prezime);
                kartaService.CreateElement(karta);
            }
 
            kupovina.voznja.brSlobodnih--;

            var voznjaRepository = new Repository.VoznjaRepository(new ASContext());
            var voznjaService = new Service.VoznjaService(voznjaRepository);

            voznjaService.Update(kupovina.voznja);
            ik.LoadAll();
            ik.dpDatum.SelectedDate = DateTime.Now;

            kupovina.Close();
            this.Close();
            MessageBox.Show("Uspešno ste kupili kartu!", "Raketa", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void Izadji(object sender, RoutedEventArgs e)
        {
            this.Close();
            kupovina.Show();
        }

        
    }
}
