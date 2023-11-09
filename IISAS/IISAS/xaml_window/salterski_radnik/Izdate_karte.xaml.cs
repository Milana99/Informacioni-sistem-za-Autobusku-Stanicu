using IISAS.Model;
using IISAS.Service;
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
    /// Interaction logic for Izdate_karte.xaml
    /// </summary>
    public partial class Izdate_karte : Window
    {
        Model.Korisnik korisnik;
        Service.KartaService kartaService;
        List<Model.Karta> karte;
        public Model.Karta kartaa;
        public Izdate_karte(Model.Korisnik korisnik)
        {
            InitializeComponent();
            this.korisnik = korisnik;
            lbStatus.Content = korisnik.tip_korisnika;
            lbUser.Content = korisnik.username;
            var kartaRepository = new Repository.KartaRepository(new ASContext());
            kartaService = new Service.KartaService(kartaRepository);
            dpDatum.SelectedDate = DateTime.Now;
            Load();
        }

        public void Load()
        {
            lvDataBinding.Items.Clear();
            karte = kartaService.GetAllOrderedBySalterskiRadnik();

            foreach (Model.Karta karta in karte)
            {
                
                    if (karta.rezervisana == 0)
                    {
                        DateTime dt1 = DateTime.Parse(karta.voznja.datum.ToString()).Add(TimeSpan.Parse(karta.voznja.pol_sat.ToString()));
                        DateTime dt2 = DateTime.Now;
                        TimeSpan ts = dt1 - dt2;
                        double totalTime = ts.TotalHours;

                        if (totalTime <= 0)
                        {
                            karta.vazeca = "Nevazeca";
                            kartaService.Update(karta);
                        }
                    if (karta.voznja.datum == DateTime.Now.ToShortDateString())
                    {
                        lvDataBinding.Items.Add(karta);
                    }
                }
            }

        }

        private void Korisnik_st_usluga_logout(object sender, RoutedEventArgs e)
        {
            var mn = new IISAS.MainWindow();
            mn.Show();
            this.Close();
        }

        private void IzdavanjeKarata(object sender, RoutedEventArgs e)
        {
            var ik = new IISAS.xaml_window.salterski_radnik.Izdavanje_karata(korisnik);
            ik.Show();
            this.Close();
        }

        private void RezervacijaKarte(object sender, RoutedEventArgs e)
        {
            var rk = new IISAS.xaml_window.salterski_radnik.Rezervacija_karata(korisnik);
            rk.Show();
            this.Close();
        }

        private void PregledRezervisanihKarata(object sender, RoutedEventArgs e)
        {
            var prk = new IISAS.xaml_window.salterski_radnik.Pregled_rezervisanih_karata(korisnik);
            prk.Show();
            this.Close();
        }

      

        private void Red_voznje(object sender, RoutedEventArgs e)
        {

        }

        private void Detaljnije(object sender, RoutedEventArgs e)
        {
            if (lvDataBinding.SelectedItems.Count > 0)
            {
                Model.Karta selectedKarta = (Model.Karta)lvDataBinding.SelectedItems[0];
                var det = new IISAS.xaml_window.salterski_radnik.Izdate_karte_detaljnije(this, selectedKarta);
                det.ShowDialog();

            }
            else
            {
                MessageBox.Show("Molim Vas selektujte vožnju za koju želite da vidite detalje!", "Raketa", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

      

        private void tbKrajnja_LostFocus(object sender, RoutedEventArgs e)
        {
            tbPretragaKrajnja.Foreground = new SolidColorBrush(Colors.Gray);
            if (tbPretragaKrajnja.Text == "")
            {
                tbPretragaKrajnja.Text = "Krajnja stanica...";
            }
        }

        private void tbKrajnja_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbPretragaKrajnja.Text == "Krajnja stanica...")
            {
                tbPretragaKrajnja.Clear();
            }
            tbPretragaKrajnja.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void tbKrajnja_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbPretragaKrajnja.Text != "Krajnja stanica...")
            {
                List<Model.Karta> karte = new List<Model.Karta>();
                
               if(rbPrevoznik.IsChecked == true && tbPretragaPrevoznik.Text != "Prevoznik...")
                {
                    karte = kartaService.filterByKrajnjaIPrevoznik(tbPretragaKrajnja.Text, tbPretragaPrevoznik.Text, dpDatum.Text);
                }
                else
                    karte = kartaService.filterByKrajnja(tbPretragaKrajnja.Text, dpDatum.Text);

                lvDataBinding.Items.Clear();
                foreach (Model.Karta karta in karte)
                {
                    if (karta.rezervisana == 0)
                    {
                        lvDataBinding.Items.Add(karta);
                    }

                }
            }
        }

        private void tbPrevoznik_LostFocus(object sender, RoutedEventArgs e)
        {
            tbPretragaPrevoznik.Foreground = new SolidColorBrush(Colors.Gray);
            if (tbPretragaPrevoznik.Text == "")
            {
                tbPretragaPrevoznik.Text = "Prevoznik...";
            }
        }

        private void tbPrevoznik_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbPretragaPrevoznik.Text == "Prevoznik...")
            {
                tbPretragaPrevoznik.Clear();
            }
            tbPretragaPrevoznik.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void tbPrevoznik_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbPretragaPrevoznik.Text != "Prevoznik...")
            {
                List<Model.Karta> karte = new List<Model.Karta>();

                if (rbKrajnjaStanica.IsChecked == true && tbPretragaKrajnja.Text != "Krajnja stanica...")
                {
                    karte = kartaService.filterByKrajnjaIPrevoznik(tbPretragaKrajnja.Text, tbPretragaPrevoznik.Text, dpDatum.Text);
                }
                else
                    karte = kartaService.filterByPrevoznik(tbPretragaPrevoznik.Text, dpDatum.Text);

                lvDataBinding.Items.Clear();
                foreach (Model.Karta karta in karte)
                {
                    if (karta.rezervisana == 0)
                    {
                        lvDataBinding.Items.Add(karta);
                    }

                }
            }
        }

        private void dpDatum_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            lvDataBinding.Items.Clear();
            karte = kartaService.GetAllOrderedBySalterskiRadnik();

            foreach (Model.Karta karta in karte)
            {

                if (karta.rezervisana == 0)
                {
                    
                    if (karta.voznja.datum == dpDatum.Text)
                    {
                        lvDataBinding.Items.Add(karta);
                    }
                }
            }
        }
    }
}
