﻿using IISAS.Model;
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
            cbStatus.Items.Add("Standardan");
            cbStatus.Items.Add("Penzioner");
            cbStatus.Items.Add("Student");
            cbStatus.SelectedItem = cbStatus.Items[0];
        }

        private void Rezervisi(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var karta = new IISAS.xaml_window.salterski_radnik.Rezervacija_karata_karta(this, rk, korisnik);
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
                tbIme.IsEnabled = false;
                tbPrezime.IsEnabled = false;
                tbIme.Text = korisnik.ime;
                tbPrezime.Text = korisnik.prezime;
            }
            else
            {
                lbErrorKorisnickoIme.Content = "Korisničko ime ne postoji!";
                tbIme.IsEnabled = true;
                tbPrezime.IsEnabled = true;
                tbIme.Text = "";
                tbPrezime.Text = "";
            }
        }
    }
}
