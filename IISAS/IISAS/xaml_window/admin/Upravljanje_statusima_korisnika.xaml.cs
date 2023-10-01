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

namespace IISAS.xaml_window.admin
{
    /// <summary>
    /// Interaction logic for Upravljanje_statusima_korisnika.xaml
    /// </summary>
    public partial class Upravljanje_statusima_korisnika : Window
    {
        Service.KorisnikService korisnikService;
        List<Model.Korisnik> korisnici;
        Model.Korisnik korisnikk;
        public Upravljanje_statusima_korisnika(Model.Korisnik korisnikk)
        {
            InitializeComponent();
            this.korisnikk = korisnikk;
            lbTipKorisnika.Content = korisnikk.tip_korisnika;
            lbUser.Content = korisnikk.username;
           LoadAll();
        }

       public void LoadAll()
        {
            var korisnikRepository = new Repository.KorisnikRepository(new ASContext());
            korisnikService = new Service.KorisnikService(korisnikRepository);
            korisnici = korisnikService.GetAll();
            lvDataBinding.Items.Clear();
            foreach (Model.Korisnik korisnik in korisnici)
            {
                if (korisnik.tip_korisnika == "Korisnik")
                {
                    lvDataBinding.Items.Add(korisnik);
                }
            }
        }

        private void Korisnik_st_usluga_logout(object sender, RoutedEventArgs e)
        {
            var mw = new IISAS.MainWindow();
            mw.Show();
            this.Close();
        }

        private void Izmeni(object sender, RoutedEventArgs e)
        {
            if (lvDataBinding.SelectedItems.Count > 0)
            {
                Model.Korisnik korisnik = (Model.Korisnik)lvDataBinding.SelectedItems[0];
                var izmena = new IISAS.xaml_window.admin.Upravljanje_statusima_korisnika_izmena(korisnik, this);
                izmena.Show();
            }
            else
            {
                MessageBox.Show("Molim Vas selektujte korisnika čiji status želite da izmenite!", "Upozorenje!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }
        private void tbSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            tbPretraga.Foreground = new SolidColorBrush(Colors.Gray);
            if (tbPretraga.Text == "")
            {
                tbPretraga.Text = "Pretraga korisnika...";
            }
        }

        private void tbSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbPretraga.Text == "Pretraga korisnika...")
            {
                tbPretraga.Clear();
            }
            tbPretraga.Foreground = new SolidColorBrush(Colors.Black);
        }


        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var korisnikRepository = new Repository.KorisnikRepository(new ASContext());
            korisnikService = new Service.KorisnikService(korisnikRepository);
            if (tbPretraga.Text != "Pretraga korisnika...")
            {
                List<Model.Korisnik> korisnici = new List<Model.Korisnik>();
                if (rbIme.IsChecked == true)
                {
                    korisnici = korisnikService.FilterByName(tbPretraga.Text);
                }
                else if (rbKorisnickoIme.IsChecked == true)
                {
                    korisnici = korisnikService.FilterByUsername(tbPretraga.Text);
                }
                else if (rbPrezime.IsChecked == true)
                {
                    korisnici = korisnikService.FilterByPrezime(tbPretraga.Text);
                }
                else if (rbStatus.IsChecked == true)
                {
                    korisnici = korisnikService.FilterByStatus(tbPretraga.Text);
                }

                lvDataBinding.Items.Clear();
                foreach (Model.Korisnik korisnik in korisnici)
                {
                    if(korisnik.tip_korisnika == "Korisnik")
                    {
                        lvDataBinding.Items.Add(korisnik);
                    }
                        
                }
            }
        }
    }
}
