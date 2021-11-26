using Protectora.Dominio;
using Protectora.Presentacion;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Protectora
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string usuario = "1234";
        private string password = "1234";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnIniciarSesion_Click(object sender, RoutedEventArgs e)
        {

            Usuario usuario = new Usuario();
            if (usuario.LeerUsuario(txtUsuario.Text.ToString(), txtContrasenia.Password.ToString()) != null)
            {
                Presentacion.Menu menu = new Presentacion.Menu();
                menu.Show();
                menu.pasaUltimaConexion(usuario.FechaUltimaConex.ToString());

                Close();
            }
            else
            {
                // feedback al usuario
                string message = "Usuario o contraseña invalido";
                string title = "Error autentificacion";
                MessageBox.Show(message, title);
            }

            /*
            if (GestorUsuario.autentificar(txtUsuario.Text.ToString(), txtContrasenia.Password.ToString()))
                {
                Presentacion.Menu menu = new Presentacion.Menu();
                menu.Show();
                menu.pasaUltimaConexion("ayer");

                this.Close();

            }

                else
                {
                // feedback al usuario
                txtUsuario.Text = "Combinación usuario-contraseña incorrecta";
                }
            */
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                BtnIniciarSesion_Click(sender, e);
            }
        }
    }

}
