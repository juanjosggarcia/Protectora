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
            
                if (txtUsuario.Text.Equals(usuario) && txtContrasenia.Password.Equals(password))
                {
                        
                    Presentacion.Menu nw = new Presentacion.Menu();
                    nw.Show();

                    this.Close();

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

        private void BtnOlvidarContraseña_Click(object sender, RoutedEventArgs e)
        {
            OlvidadaContrasenia Oc = new OlvidadaContrasenia();
            Oc.Show();
        }

        
    }

}
