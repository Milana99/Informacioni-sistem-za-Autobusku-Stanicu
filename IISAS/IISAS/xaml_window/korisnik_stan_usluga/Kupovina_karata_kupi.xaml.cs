using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for Kupovina_karata_kupi.xaml
    /// </summary>
    public partial class Kupovina_karata_kupi : Window
    {
        public Model.Voznja voznja;
        public Kupovina_karata_prava kkp;
        Model.Korisnik korisnik;
        public Kupovina_karata_kupi(Model.Voznja voznja, Kupovina_karata_prava kkp, Model.Korisnik korisnik)
        {
            InitializeComponent();
            this.voznja = voznja;
            this.kkp = kkp;
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

        private void Kupi(object sender, RoutedEventArgs e)
        {
            this.Hide();   
            var karta = new IISAS.xaml_window.korisnik_stan_usluga.Kupovina_karata_karta(this, kkp, korisnik);
            karta.ShowDialog(); 

        }
    }
}
