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
using System.Globalization;
using Protectora.Dominio;

namespace Protectora.Presentacion
{
    /// <summary>
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : Window, ICompartir
    {
        private Usuario usuarioActual;
        public Menu(Usuario usuarioActual)
        {
            this.usuarioActual = usuarioActual;
            InitializeComponent();
            lblFinalSesion.Content = usuarioActual.FechaUltimaConex.ToString();
        }
        public void pasarUltimaConexion(string texto)
        {
            lblFinalSesion.Content = texto;
        }

        public void pasarUsuario(Usuario user)
        {
            usuarioActual=user;
        }

        private void BtnPerro_Click(object sender, RoutedEventArgs e)
        {
         
            GestionPerro gestionPerroWin = new GestionPerro();
            gestionPerroWin.Show();
            this.Hide();
            //this.Close();

            
        }

        private void BtnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow loginWin = new MainWindow();

            DateTime localDate = DateTime.Now;

            pasarUltimaConexion(localDate.ToString());

            usuarioActual.FechaUltimaConex = localDate;
            GestorUsuario.addUltimaConexion(usuarioActual);

            Application.Current.MainWindow.Show();

            //loginWin.Show();

            this.Close();
        }


    }


}
