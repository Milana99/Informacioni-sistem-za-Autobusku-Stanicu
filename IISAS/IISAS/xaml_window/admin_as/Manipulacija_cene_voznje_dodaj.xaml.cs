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

namespace IISAS.xaml_window.admin_as
{
    /// <summary>
    /// Interaction logic for Manipulacija_cene_voznje_dodaj.xaml
    /// </summary>
    public partial class Manipulacija_cene_voznje_dodaj : Window
    {
        public Manipulacija_cene_voznje_dodaj()
        {
            InitializeComponent();
        }

        private void Potvrdi(object sender, RoutedEventArgs e)
        {

        }

        private void Izadji(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
