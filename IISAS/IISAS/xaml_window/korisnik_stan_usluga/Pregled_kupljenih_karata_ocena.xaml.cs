using IISAS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Pregled_kupljenih_karata_ocena.xaml
    /// </summary>
    public partial class Pregled_kupljenih_karata_ocena : Window
    {
        public Pregled_kupljenih_karata pkk;
        Model.Karta karta;
        public Pregled_kupljenih_karata_ocena(Pregled_kupljenih_karata pkk, Model.Karta karta)
        {
            InitializeComponent();
            this.pkk = pkk;
            this.karta = karta;
            if(karta.ocena != null)
            {
                tbOcena.Text= karta.ocena.ToString();
                tbOcena.IsEnabled = false;
            }
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
            lbStatusPutnika.Content = pkk.korisnik.status_korisnika;
            lbVremeDolaska.Content = karta.voznja.dol_sat;
            lbVremePolaska.Content = karta.voznja.pol_sat;
            lbVrstaKarte.Content = karta.vrsta_karte;
            lbDatumKupovine.Content = karta.datum;
        }

        private void Oceni(object sender, RoutedEventArgs e)
        {
            if(!Regex.IsMatch(tbOcena.Text, @"^[1-5]$"))
            {
                MessageBox.Show("Molim Vas unesite pravilno ocenu!", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                karta.OceniKartu(int.Parse(tbOcena.Text));
                pkk.Load();
                MessageBox.Show("Uspešno ste ocenili kartu!", "Uspešno", MessageBoxButton.OK, MessageBoxImage.Information);

                this.Close();
            }
            
        }

        private void Izadji(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tbOcena_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(tbOcena.Text, @"^[1-5]$"))
            {
                tbOcena.Foreground = new SolidColorBrush(Colors.Red);
                errorLbOcena.Foreground = new SolidColorBrush(Colors.Red);
                errorLbOcena.Content = "Ocena mora da bude od 1 do 5!!";
            }

            else
            {
                tbOcena.Foreground = new SolidColorBrush(Colors.Green);
                errorLbOcena.Foreground = new SolidColorBrush(Colors.Green);
                errorLbOcena.Content = "Ocena je u redu!";
            }
        }
    }
}
