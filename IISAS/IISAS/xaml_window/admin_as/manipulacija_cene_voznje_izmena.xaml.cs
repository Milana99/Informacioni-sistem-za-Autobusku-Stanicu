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

namespace IISAS.xaml_window.admin_as
{
    /// <summary>
    /// Interaction logic for manipulacija_cene_voznje_izmena.xaml
    /// </summary>
    public partial class manipulacija_cene_voznje_izmena : Window
    {
        public Manipulacija_cene_voznje manipulacijaCene;
        public Model.Voznja voznja;
        public manipulacija_cene_voznje_izmena(Manipulacija_cene_voznje manipulacijaCene, Model.Voznja voznja)
        {

            InitializeComponent();
            this.manipulacijaCene = manipulacijaCene;
            this.voznja = voznja;
            tbCena.Text = voznja.cena.ToString();
        }

        private void tbCenaTextChanged(object sender, TextChangedEventArgs e)
        {

            var korisnikRepository = new Repository.KorisnikRepository(new ASContext());
            var korisnikService = new Service.KorisnikService(korisnikRepository);
            if (!Regex.IsMatch(tbCena.Text, @"^[1-9]\d*$"))
            {
                this.tbCena.Foreground = new SolidColorBrush(Colors.Red);
                lbErrorCena.Foreground = new SolidColorBrush(Colors.Red);
                lbErrorCena.Content = "Cena mora da bude ceo broj!";
            }

            else
            {
                this.tbCena.Foreground = new SolidColorBrush(Colors.Green);
                lbErrorCena.Foreground = new SolidColorBrush(Colors.Green);
                lbErrorCena.Content = "Cena je u redu!";
            }

        }

        private void Potvrdi(object sender, RoutedEventArgs e)
        {
            if(lbErrorCena.Content.ToString().Contains("u redu"))
            {
                var voznjaRepository = new Repository.VoznjaRepository(new ASContext());
                Service.VoznjaService voznjaService = new Service.VoznjaService(voznjaRepository);
                voznja.cena = int.Parse(tbCena.Text);
                voznjaService.Update(voznja);
                manipulacijaCene.LoadAll();
                MessageBox.Show("Uspešno ste izmenili cenu!", "Uspešno!", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
                MessageBox.Show("Molimo cenu unesite ispravno!", "Upozorenje!", MessageBoxButton.OK, MessageBoxImage.Warning);


        }

        private void Izadji(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
