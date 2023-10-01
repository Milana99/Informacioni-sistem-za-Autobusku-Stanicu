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

namespace IISAS.xaml_window
{
    /// <summary>
    /// Interaction logic for Registracija.xaml
    /// </summary>
    public partial class Registracija : Window
    {
        public Registracija()
        {
            InitializeComponent();
        }

        private void tbTextChangedKorisnickoIme(object sender, TextChangedEventArgs e)
        {

            var asContext = new ASContext();
            var korisnikRepository = new Repository.KorisnikRepository(asContext);
            var korisnikService = new Service.KorisnikService(korisnikRepository);
            if (this.tbKorisnickoIme.Text != "Korisničko ime" & (korisnikService.FilterByUsernameCount(this.tbKorisnickoIme.Text) != 0 || this.tbKorisnickoIme.Text.Length < 5))
            {
                this.tbKorisnickoIme.Foreground = new SolidColorBrush(Colors.Red);
                lbErrorKorisnickoIme.Foreground = new SolidColorBrush(Colors.Red);
                if (this.tbKorisnickoIme.Text.Length < 5)
                    lbErrorKorisnickoIme.Content = "Korisničko ime mora imati najmanje 5 karaktera!";
                else
                    lbErrorKorisnickoIme.Content = "Korisničko ime već postoji!";

            }

            if (this.tbKorisnickoIme.Text != "Korisničko ime" & this.tbKorisnickoIme.Text.Length >= 5 & korisnikService.FilterByUsernameCount(tbKorisnickoIme.Text) == 0)
            {
                this.tbKorisnickoIme.Foreground = new SolidColorBrush(Colors.Green);
                lbErrorKorisnickoIme.Content = "Korisničko ime je u redu!";
                lbErrorKorisnickoIme.Foreground = new SolidColorBrush(Colors.Green);
            }

        }
        private void tbLostFocusKorisnickoIme(object sender, RoutedEventArgs e)
        {
            tbKorisnickoIme.Foreground = new SolidColorBrush(Colors.Gray);
            if (tbKorisnickoIme.Text == "")
            {
                tbKorisnickoIme.Text = "Korisničko ime";
            }
        }
        private void tbGotFocusKorisnickoIme(object sender, RoutedEventArgs e)
        {
            if (tbKorisnickoIme.Text == "Korisničko ime")
            {
                tbKorisnickoIme.Clear();
            }

            tbKorisnickoIme.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void tbTextChangedIme(object sender, TextChangedEventArgs e)
        {

        }
        private void tbLostFocusIme(object sender, RoutedEventArgs e)
        {
            tbIme.Foreground = new SolidColorBrush(Colors.Gray);
            if (tbIme.Text == "")
            {
                tbIme.Text = "Ime";
            }
        }
        private void tbGotFocusIme(object sender, RoutedEventArgs e)
        {
            if (tbIme.Text == "Ime")
            {
                tbIme.Clear();
            }

            tbIme.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void tbTextChangedPrezime(object sender, TextChangedEventArgs e)
        {

        }

        private void tbLostFocusPrezime(object sender, RoutedEventArgs e)
        {
            tbPrezime.Foreground = new SolidColorBrush(Colors.Gray);
            if (tbPrezime.Text == "")
            {
                tbPrezime.Text = "Prezime";
            }
        }
        private void tbGotFocusPrezime(object sender, RoutedEventArgs e)
        {
            if (tbPrezime.Text == "Prezime")
            {
                tbPrezime.Clear();
            }

            tbPrezime.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void tbTextChangedLozinka(object sender, TextChangedEventArgs e)
        {
            if (this.tbLozinka.Text != "Lozinka")
            {
                if (!Regex.IsMatch(tbLozinka.Text, @"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$"))
                {
                    this.tbLozinka.Foreground = new SolidColorBrush(Colors.Red);
                    lbErrorLozinka.Foreground = new SolidColorBrush(Colors.Red);
                    lbErrorLozinka.Content = "Najmanje 1 veliko slovo, 1 znak, 1 malo slovo, min dužine 8!";
                }
                else
                {
                    this.tbLozinka.Foreground = new SolidColorBrush(Colors.Green);
                    lbErrorLozinka.Foreground = new SolidColorBrush(Colors.Green);
                    lbErrorLozinka.Content = "Lozinka je u redu!";
                }
            }
        }

        private void tbLostFocusLozinka(object sender, RoutedEventArgs e)
        {
            tbLozinka.Foreground = new SolidColorBrush(Colors.Gray);
            if (tbLozinka.Text == "")
            {
                tbLozinka.Text = "Lozinka";
            }
        }
        private void tbGotFocusLozinka(object sender, RoutedEventArgs e)
        {
            if (tbLozinka.Text == "Lozinka")
            {
                tbLozinka.Clear();
            }

            tbLozinka.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void tbTextChangedPonovljenaLozinka(object sender, TextChangedEventArgs e)
        {
            if (this.tbPonovljenaLozinka.Text != "Ponovi Lozinku")
            {
                if (this.tbPonovljenaLozinka.Text != this.tbLozinka.Text)
                {
                    this.tbPonovljenaLozinka.Foreground = new SolidColorBrush(Colors.Red);
                    lbErrorPonovljenaLozinka.Foreground = new SolidColorBrush(Colors.Red);
                    lbErrorPonovljenaLozinka.Content = "Lozinke se ne poklapaju!";

                }
                else
                {
                    this.tbPonovljenaLozinka.Foreground = new SolidColorBrush(Colors.Green);
                    lbErrorPonovljenaLozinka.Foreground = new SolidColorBrush(Colors.Green);
                    lbErrorPonovljenaLozinka.Content = "Lozinke se poklapaju!";
                }
            }
        }

        private void tbLostFocusPonovljenaLozinka(object sender, RoutedEventArgs e)
        {
            tbPonovljenaLozinka.Foreground = new SolidColorBrush(Colors.Gray);
            if (tbPonovljenaLozinka.Text == "")
            {
                tbPonovljenaLozinka.Text = "Ponovi Lozinku";
            }
        }
        private void tbGotFocusPonovljenaLozinka(object sender, RoutedEventArgs e)
        {
            if (tbPonovljenaLozinka.Text == "Ponovi Lozinku")
            {
                tbPonovljenaLozinka.Clear();
            }

            tbPonovljenaLozinka.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void tbLostFocusEmail(object sender, RoutedEventArgs e)
        {
            tbEmail.Foreground = new SolidColorBrush(Colors.Gray);
            if (tbEmail.Text == "")
            {
                tbEmail.Text = "Email";
            }
        }

        private void tbGotFocusEmail(object sender, RoutedEventArgs e)
        {
            if (tbEmail.Text == "Email")
            {
                tbEmail.Clear();
            }

            tbEmail.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void tbTextChangedEmail(object sender, TextChangedEventArgs e)
        {
            if (this.tbEmail.Text != "Email")
            {
                if (!Regex.IsMatch(tbEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                {
                    this.tbEmail.Foreground = new SolidColorBrush(Colors.Red);
                    lbErrorEmail.Foreground = new SolidColorBrush(Colors.Red);
                    lbErrorEmail.Content = "Email mora biti u formatu pr. email@gmail.com";
                }
                else
                {
                    this.tbEmail.Foreground = new SolidColorBrush(Colors.Green);
                    lbErrorEmail.Foreground = new SolidColorBrush(Colors.Green);
                    lbErrorEmail.Content = "Email je u redu!";
                }
            }

        }

        private void Registracijaa(object sender, RoutedEventArgs e)
        {
            if (tbKorisnickoIme.Text == "Korisničko ime" || tbIme.Text == "Ime" || tbPrezime.Text == "Prezime" || tbEmail.Text == "Email" || tbLozinka.Text == "Lozinka" || tbPonovljenaLozinka.Text == "Ponovi Lozinku")
            {
                ValidationNotFilled();
            }
            else if (!lbErrorKorisnickoIme.Content.ToString().Contains("u redu") || !lbErrorEmail.Content.ToString().Contains("u redu")
                || !lbErrorLozinka.Content.ToString().Contains("u redu") || !lbErrorPonovljenaLozinka.Content.ToString().Equals("Lozinke se poklapaju!"))
                MessageBox.Show("Narušili ste ograničenje, molimo to ispravite!", "Upozorenje!", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                var asContext = new ASContext();
                var korisnikRepository = new Repository.KorisnikRepository(asContext);
                var korisnikService = new Service.KorisnikService(korisnikRepository);
                if (korisnikService.FilterByUsernameCount(tbKorisnickoIme.Text) == 0)
                {
                    Model.Korisnik korisnik = new Model.Korisnik(
                        tbIme.Text, tbPrezime.Text, "Korisnik", "Standardan", tbEmail.Text, tbKorisnickoIme.Text, tbLozinka.Text);

                    korisnikService.CreateElement(korisnik);
                    MessageBox.Show(korisnik.ime + " uspešno ste registrovali na nas sajt", "Uspešno!", MessageBoxButton.OK, MessageBoxImage.Information);
                    var mw = new IISAS.MainWindow();
                    mw.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Korisnik sa tim korisnickim imenom vec postoji!", "Upozorenje!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

        }

        private void Back(object sender, RoutedEventArgs e)
        {
            var mw = new IISAS.MainWindow();
            mw.Show();
            this.Close();
        }

        private void ValidationNotFilled()
        {

            MessageBox.Show("Molim Vas popunite sva polja kako biste se uspešno registrovali!", "Upozorenje!", MessageBoxButton.OK, MessageBoxImage.Warning);

            //Kada polje nije popunjeno 

            if (tbKorisnickoIme.Text == "Korisničko ime")
            {
                ChangeTextBoxWhenIsNotFilled(tbKorisnickoIme);
            }
            if (tbIme.Text == "Ime")
            {
                ChangeTextBoxWhenIsNotFilled(tbIme);
            }
            if (tbPrezime.Text == "Prezime")
            {
                ChangeTextBoxWhenIsNotFilled(tbPrezime);
            }
            if (tbEmail.Text == "Email")
            {
                ChangeTextBoxWhenIsNotFilled(tbEmail);
            }
            if (tbLozinka.Text == "Lozinka")
            {
                ChangeTextBoxWhenIsNotFilled(tbLozinka);
            }
            if (tbPonovljenaLozinka.Text == "Ponovi Lozinku")
            {
                ChangeTextBoxWhenIsNotFilled(tbPonovljenaLozinka);
            }

            //Kada je polje popunjeno 

            if (tbKorisnickoIme.Text != "Korisničko ime")
            {
                ChangeTextBoxWhenIsFilled(tbKorisnickoIme);
            }
            if (tbIme.Text != "Ime")
            {
                ChangeTextBoxWhenIsFilled(tbIme);
            }
            if (tbPrezime.Text != "Prezime")
            {
                ChangeTextBoxWhenIsFilled(tbPrezime);

            }
            if (tbEmail.Text != "Email")
            {
                ChangeTextBoxWhenIsFilled(tbEmail);

            }
            if (tbLozinka.Text != "Lozinka")
            {
                ChangeTextBoxWhenIsFilled(tbLozinka);
            }
            if (tbPonovljenaLozinka.Text != "Ponovi Lozinku")
            {
                ChangeTextBoxWhenIsFilled(tbPonovljenaLozinka);
            }
        }

        private void ChangeTextBoxWhenIsFilled(TextBox tb)
        {
            tb.Foreground = new SolidColorBrush(Colors.Gray);
            tb.BorderBrush = new SolidColorBrush(Colors.Gray);
            tb.BorderThickness = new Thickness(0, 0, 0, 2);
        }

        private void ChangeTextBoxWhenIsNotFilled(TextBox tb)
        {
            tb.Foreground = new SolidColorBrush(Colors.Red);
            tb.BorderBrush = new SolidColorBrush(Colors.Red);
            tb.BorderThickness = new Thickness(1, 1, 1, 1);
        }

    }
}
