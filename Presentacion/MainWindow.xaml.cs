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
        //private string usuario = "1234";
        //private string password = "1234";
        public MainWindow()
        {
            InitializeComponent();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            App.Current.Shutdown();
        }

        private void BtnIniciarSesion_Click(object sender, RoutedEventArgs e)
        {

            errorInicioSesion.Content = "";
            Usuario usuario = new Usuario(null, txtUsuario.Text.ToString(), txtContrasenia.Password.ToString(), null);
            usuario = GestorUsuario.obtenerUser(usuario);

            if (usuario != null)
            {

                ClaseVentanaPrincipal nw = new ClaseVentanaPrincipal(usuario);
                //string cosa = nw.paneles[0].putamierda;
                nw.Show();

                //this.Close();

                Hide();
                //Close();
            }
            else
            {
                // feedback al usuario
                txtUsuario.Text = "";
                txtContrasenia.Password = "";
                errorInicioSesion.Visibility = Visibility.Visible;
                
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

        private void LimpiarTexto(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Nombre de usuario" || txtUsuario.Text == "Username")
            {
                txtUsuario.Text = "";
                txtUsuario.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void MostrarAyuda(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                if (ComboBoxIdioma.SelectedIndex == 0)
                {
                    txtUsuario.Text = "Nombre de usuario";
                }
                else
                {
                    txtUsuario.Text = "Username";
                }
                txtUsuario.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }


        private void LimpiarTextoContrasenia(object sender, EventArgs e)
        {
            if (txtContrasenia.Password == "Contraseña")
            {
                txtContrasenia.Password = "";
                txtContrasenia.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void MostrarAyudaContrasenia(object sender, EventArgs e)
        {
            if (txtContrasenia.Password == "")
            {
                txtContrasenia.Password = "Contraseña";
                txtContrasenia.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void BtnOlvidarContraseña_Click(object sender, RoutedEventArgs e)
        {
            ClaseContraseniaOlvidada Oc = new ClaseContraseniaOlvidada(this);
            Oc.Show();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string idioma = "";
            int eleccion = ComboBoxIdioma.SelectedIndex;
            switch (eleccion)
            {
                case 0:
                    idioma = "es-ES";
                    txtUsuario.Text = "Nombre de usuario";
                    //errorInicioSesion.Visibility = Visibility.Hidden;


                    break;
                case 1:
                    idioma = "en-UK";
                    txtUsuario.Text = "Username";
                    //errorInicioSesion.Visibility = Visibility.Hidden;
                    break;
            }
            Resources.MergedDictionaries.Add(App.DefineIdioma(idioma));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClaseAcercaDe Ad = new ClaseAcercaDe(this);
            Ad.Show();
        }
    }

}
