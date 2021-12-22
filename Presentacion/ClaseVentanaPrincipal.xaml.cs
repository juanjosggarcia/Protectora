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

namespace Protectora.Presentacion
{
    /// <summary>
    /// Lógica de interacción para ClaseVentanaPrincipal.xaml
    /// </summary>
    public partial class ClaseVentanaPrincipal : Window
    {
        public Page[] paneles = new Page[] { new PaginaPerro(), new PaginaSocios(), new PaginaVoluntarios(), new PaginaAvisos() };
        public ClaseVentanaPrincipal()
        {
            InitializeComponent();
            MainFrame.Content = paneles[0];

        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            App.Current.Shutdown();
        }

        private void BtnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();

            this.Close();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            BtnCerrarSesion.Visibility = Visibility.Visible;

        }


        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
            BtnCerrarSesion.Visibility = Visibility.Collapsed;

        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainFrame.Content = paneles[((ListView)sender).SelectedIndex];

        }

        private void BotonListPerro_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = paneles[0];
        }

        private void BotonListSocio_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = paneles[1];
        }

        private void BotonListVoluntario_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = paneles[2];
        }

        private void BotonListAvisos_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = paneles[3];
        }
    }
}
