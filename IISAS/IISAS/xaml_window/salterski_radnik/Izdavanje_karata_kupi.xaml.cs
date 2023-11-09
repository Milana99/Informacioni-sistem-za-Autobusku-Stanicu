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
    /// Interaction logic for Izdavanje_karata_kupi.xaml
    /// </summary>
    public partial class Izdavanje_karata_kupi : Window
    {
        public Model.Voznja voznja;
        public Izdavanje_karata ik;
        Model.Korisnik korisnik;
        public Izdavanje_karata_kupi(Model.Voznja voznja, Izdavanje_karata ik, Model.Korisnik korisnik)
        {
            InitializeComponent();
            this.voznja = voznja;
            this.ik = ik;
            this.korisnik = korisnik;
            Load();
        }

        public void Load()
        {
            cbTipKarte.Items.Add("Jednosmerna");
            cbTipKarte.Items.Add("Povratna");
            cbTipKarte.SelectedItem = cbTipKarte.Items[0];
            cbStatus.Items.Add("Standardan");
            cbStatus.Items.Add("Penzioner");
            cbStatus.Items.Add("Student");
            cbStatus.SelectedItem = cbStatus.Items[0];
        }

        private void Kupi(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var karta = new IISAS.xaml_window.salterski_radnik.Izdavanje_karata_karta(this, ik, korisnik);
            karta.ShowDialog();
        }

        private void Izadji(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tbUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            var asContext = new ASContext();
            var korisnikRepository = new Repository.KorisnikRepository(asContext);
            var korisnikService = new Service.KorisnikService(korisnikRepository);
            Korisnik korisnik = new Korisnik();
            korisnik = korisnikService.GetOne(tbKorisnickoIme.Text);

            if (korisnik!=null)
            { 
                    lbErrorKorisnickoIme.Content = "Korisničko ime postoji!";
            }
            else
            {
                lbErrorKorisnickoIme.Content = "Korisničko ime ne postoji!";

            }
        }
    }
}
