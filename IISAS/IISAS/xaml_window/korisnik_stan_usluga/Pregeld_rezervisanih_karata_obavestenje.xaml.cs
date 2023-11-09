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

namespace IISAS.xaml_window.korisnik_stan_usluga
{
    /// <summary>
    /// Interaction logic for Pregeld_rezervisanih_karata_obavestenje.xaml
    /// </summary>
    public partial class Pregeld_rezervisanih_karata_obavestenje : Window
    {
        public Pregled_rezervisanih_karata rezervisane;
        public Pregeld_rezervisanih_karata_obavestenje(Model.Korisnik korisnik, Pregled_rezervisanih_karata rezervisane)
        {
            InitializeComponent();
            var obavestenjeRepository = new Repository.ObavestenjeRepository(new ASContext());
            var obavestenjeService = new Service.ObavestenjeService(obavestenjeRepository);
            foreach (Obavestenje obavestenje in obavestenjeService.getAllByKorisnik(korisnik.username))
            {
                lvDataBinding.Items.Add(obavestenje);
                obavestenjeService.DeleteElement(obavestenje.id_obavestenja);
            }
            this.rezervisane = rezervisane;
        }

        private void Izadji(object sender, RoutedEventArgs e)
        {
            rezervisane.Load();
            this.Close();
        }
    }
}
