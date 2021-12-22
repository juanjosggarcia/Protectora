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
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            App.Current.Shutdown();
        }

        private void BtnIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            
                if (txtUsuario.Text.Equals(usuario) && txtContrasenia.Password.Equals(password))
                {
                        
                    ClaseVentanaPrincipal nw = new ClaseVentanaPrincipal();
                    nw.Show();

                    this.Hide();

            }
                else
                {
                // feedback al usuario
                txtUsuario.Text = "";
                txtContrasenia.Password = "";
                errorInicioSesion.Content = "Usuario o contraseña incorrectos";
            }
            
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
            if (txtUsuario.Text == "Nombre de Usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void MostrarAyuda(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Nombre de Usuario";
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
            ClaseContraseniaOlvidada Oc = new ClaseContraseniaOlvidada();
            Oc.Show();
        }


    }

}
