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
            
                if (Usuario.Text.Equals(usuario) && Contrasenia.Password.Equals(password))
                {
                        
                    Presentacion.Window1 nw = new Window1();
                    nw.Show();

                    this.Close();

            }
                else
                {
                    // feedback al usuario
                    Usuario.Text = "Combinación usuario-contraseña incorrecta";
                }
            
        }
    }

}
