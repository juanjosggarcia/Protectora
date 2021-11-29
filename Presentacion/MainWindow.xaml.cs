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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            errorInicioSesion.Content = "";
            Usuario usuario = new Usuario(null, txtUsuario.Text.ToString(), txtContrasenia.Password.ToString(), null);
            usuario = GestorUsuario.obtenerUser(usuario);
            //usuario.LeerUsuario();

            if (usuario != null)
            {
                Presentacion.Menu menuWin = new Presentacion.Menu(usuario);
                menuWin.Show();
                //menuWin.pasarUltimaConexion(usuario.FechaUltimaConex.ToString());

                //Hide();
                Close();
            }
            else
            {
                // feedback al usuario
                txtUsuario.Text = "";
                txtContrasenia.Password = "";
                errorInicioSesion.Content = "Usuario o contraseña incorrectos";
            }
            /*
            else
            {
                // feedback al usuario con ventana emergente
                string message = "Usuario o contraseña invalido";
                string title = "Error autentificacion";
                MessageBox.Show(message, title);
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
