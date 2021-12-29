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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            errorInicioSesion.Content = "";
            //App.DefineIdioma("es");
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            App.Current.Shutdown();
        }

        private void BtnIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                errorInicioSesion.Content = "";
                Usuario usuario = new Usuario(null, txtUsuario.Text.ToString(), txtContrasenia.Password.ToString(), null);
                usuario = GestorUsuario.obtenerUser(usuario);

                if (usuario != null)
                {

                    ClaseVentanaPrincipal nw = new ClaseVentanaPrincipal(usuario);
                    nw.Show();

                    //this.Close();

                    Hide();
                    //Close();
                }
                else
                {
                    txtUsuario.Text = "";
                    txtContrasenia.Password = "";
                    if (ComboBoxIdioma.SelectedIndex == 0)
                    {
                        errorInicioSesion.Content = "Ha ingresado un nombre de usuario o contraseña inválidos";
                    }
                    else
                    {
                        errorInicioSesion.Content = "You have entered an invalid username or password";
                    }
                }
            }
            catch (System.Data.OleDb.OleDbException ex)
            {
                ELog.save(this, ex);
                string message = "No se puede tener acceder a la base de datos.\nAsegurese que se encuentra disponible";
                string caption = "Problema con la base de datos";
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons);
            }
            catch (InvalidOperationException ex)
            {
                ELog.save(this, ex);
                string message = "No se puede tener acceder a la base de datos.\nPor favor asegurese de tener instalada la ultima version del proveedor";
                string caption = "Problema con la base de datos";
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons);
            }
            catch (Exception ex)
            {
                ELog.save(this, ex);
                string message = "No se puede tener acceder a la base de datos.\nPor favor pongase en contanto con su administrador";
                string caption = "Problema con la base de datos";
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons);
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

                    break;
                case 1:
                    idioma = "en-UK";
                    txtUsuario.Text = "Username";
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
