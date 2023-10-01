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
    /// Interaction logic for Rezervacija_karata_rezervisi.xaml
    /// </summary>
    public partial class Rezervacija_karata_rezervisi : Window
    {
        public Model.Voznja voznja;
        public Rezervacija_karata rk;
        Model.Korisnik korisnik;
        public Rezervacija_karata_rezervisi(Model.Voznja voznja, Rezervacija_karata rk, Model.Korisnik korisnik)
        {
            InitializeComponent();
            this.voznja = voznja;
            this.rk = rk;
            this.korisnik = korisnik;
            Load();

        }

        public void Load()
        {
            cbTipKarte.Items.Add("Jednosmerna");
            cbTipKarte.Items.Add("Povratna");
            cbTipKarte.SelectedItem = cbTipKarte.Items[0];
            lbStatus.Content = korisnik.status_korisnika;
        }

        private void Izadji(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Rezervisi(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var karta = new IISAS.xaml_window.korisnik_stan_usluga.Rezervacija_karata_karta(this, rk, korisnik);
            karta.ShowDialog();
        }
    }
}
