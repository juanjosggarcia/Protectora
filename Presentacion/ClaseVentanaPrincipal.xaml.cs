using Protectora.Dominio;
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
    public partial class ClaseVentanaPrincipal : Window
    {
        private Usuario user;
        public Page[] paneles = new Page[] { new PaginaPerro(), new PaginaSocios(), new PaginaVoluntarios(), new PaginaAvisos() };
        public ClaseVentanaPrincipal(Usuario user)
        {
            this.user = user;
            InitializeComponent();
            MainFrame.Content = paneles[0];

            DateTime userSesion = (DateTime)user.FechaUltimaConex;
            lblFinalFechaSesion.Content = userSesion.ToString("dd-MM-yyyy HH:mm");

        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            App.Current.Shutdown();
        }

        private void BtnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {

            DateTime localDate = DateTime.Now;

            lblFinalFechaSesion.Content = localDate.ToString();

            user.FechaUltimaConex = localDate;
            GestorUsuario.addUltimaConexion(user);

            Application.Current.MainWindow.Show();

            this.Hide();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }


        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainFrame.Content = paneles[((ListView)sender).SelectedIndex];
        }

        private void BotonListPerro_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = paneles[0];
            Titulo.Content = "Gestion de perros";
        }

        private void BotonListSocio_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = paneles[1];
            Titulo.Content = "Gestion de socios";
        }

        private void BotonListVoluntario_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = paneles[2];
            Titulo.Content = "Gestion de voluntarios";
        }

        private void BotonListAvisos_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = paneles[3];
            Titulo.Content = "Gestion de avisos";
        }
    }
}
