using System.Windows;

namespace IISAS.xaml_window.admin_as
{
    /// <summary>
    /// Interaction logic for Upravljanje_terminima_izmeni.xaml
    /// </summary>
    public partial class Upravljanje_terminima_izmeni : Window
    {
        Model.Voznja voznja;
        public Upravljanje_terminima_izmeni(Model.Voznja voznja)
        {
            InitializeComponent();
            this.voznja = voznja;
            LoadAll();
        }
        private void LoadAll()
        {
            lbAutobus.Content = voznja.autobus.id_aut;
            lbDatum.Content = voznja.datum;
            lbDolazno.Content = voznja.dol_sat;
            lbKrajnja.Content = voznja.krajnja_stan.naz_stan;
            lbPocetna.Content = voznja.polazna_stan.naz_stan;
            lbPolaznoVreme.Content = voznja.pol_sat;
            lbPrevoznik.Content = voznja.autobus.autoprev.naziv_prev;
            lbPreko.Content = voznja.preko;
            lbPeron.Content = voznja.peron.naz_per;
            
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
