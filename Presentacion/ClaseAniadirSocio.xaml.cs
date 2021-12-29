using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Protectora.Dominio;
using Microsoft.Win32;


namespace Protectora.Presentacion
{
    /// <summary>
    /// Lógica de interacción para ClaseAniadirSocio.xaml
    /// </summary>
    public partial class ClaseAniadirSocio : Window
    {
        PaginaSocios pagSocios;
        public ClaseAniadirSocio(PaginaSocios p)
        {
            InitializeComponent();
            pagSocios = p;
        }

        private void LimpiarTextoNombre(object sender, EventArgs e)
        {
            txtNombreSocio.Text = txtNombreSocio.Text == "Nombre completo" ? string.Empty : txtNombreSocio.Text;
            txtNombreSocio.Foreground = new SolidColorBrush(Colors.Black);
            lblNombre.Visibility = Visibility.Visible;

        }
        private void RellenarTextoNombre(object sender, EventArgs e)
        {
            if (txtNombreSocio.Text == string.Empty)
            {
                txtNombreSocio.Text = "Nombre completo";
                lblNombre.Visibility = Visibility.Hidden;
                txtNombreSocio.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void LimpiarTextoCorreo(object sender, EventArgs e)
        {
            txtCorreoSocio.Text = txtCorreoSocio.Text == "Correo" ? string.Empty : txtCorreoSocio.Text;
            txtCorreoSocio.Foreground = new SolidColorBrush(Colors.Black);
            lblCorreo.Visibility = Visibility.Visible;
        }
        private void RellenarTextoCorreo(object sender, EventArgs e)
        {
            if (txtCorreoSocio.Text == string.Empty)
            {
                txtCorreoSocio.Text = "Correo";
                lblCorreo.Visibility = Visibility.Hidden;
                txtCorreoSocio.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void LimpiarTextoDNI(object sender, EventArgs e)
        {
            txtDniSocio.Text = txtDniSocio.Text == "DNI" ? string.Empty : txtDniSocio.Text;
            txtDniSocio.Foreground = new SolidColorBrush(Colors.Black);
            lblDni.Visibility = Visibility.Visible;
        }
        private void RellenarTextoDNI(object sender, EventArgs e)
        {
            if (txtDniSocio.Text == string.Empty)
            {
                txtDniSocio.Text = "DNI";
                lblDni.Visibility = Visibility.Hidden;
                txtDniSocio.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void LimpiarTextoTelefono(object sender, EventArgs e)
        {
            txtTelefonoSocio.Text = txtTelefonoSocio.Text == "Telefono" ? string.Empty : txtTelefonoSocio.Text;
            txtTelefonoSocio.Foreground = new SolidColorBrush(Colors.Black);
            lblTelefono.Visibility = Visibility.Visible;
        }
        private void RellenarTextoTelefono(object sender, EventArgs e)
        {
            if (txtTelefonoSocio.Text == string.Empty)
            {
                txtTelefonoSocio.Text = "Telefono";
                lblTelefono.Visibility = Visibility.Hidden;
                txtTelefonoSocio.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void LimpiarTextoCuantia(object sender, EventArgs e)
        {
            txtCuantiaSocio.Text = txtCuantiaSocio.Text == "Cuantia de la ayuda" ? string.Empty : txtCuantiaSocio.Text;
            txtCuantiaSocio.Foreground = new SolidColorBrush(Colors.Black);
            lblCuantia.Visibility = Visibility.Visible;
        }
        private void RellenarTextoCuantia(object sender, EventArgs e)
        {
            if (txtCuantiaSocio.Text == string.Empty)
            {
                txtCuantiaSocio.Text = "Cuantia de la ayuda";
                lblCuantia.Visibility = Visibility.Hidden;
                txtCuantiaSocio.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void LimpiarTextoDatosBan(object sender, EventArgs e)
        {
            txtDatosBanSocio.Text = txtDatosBanSocio.Text == "Datos bancarios" ? string.Empty : txtDatosBanSocio.Text;
            txtDatosBanSocio.Foreground = new SolidColorBrush(Colors.Black);
            lblDatosBan.Visibility = Visibility.Visible;
        }
        private void RellenarTextoDatosBan(object sender, EventArgs e)
        {
            if (txtDatosBanSocio.Text == string.Empty)
            {
                txtDatosBanSocio.Text = "Datos bancarios";
                lblDatosBan.Visibility = Visibility.Hidden;
                txtDatosBanSocio.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void LimpiarTextoFormaPago(object sender, EventArgs e)
        {
            txtPagoSocio.Text = txtPagoSocio.Text == "Forma de pago" ? string.Empty : txtPagoSocio.Text;
            txtPagoSocio.Foreground = new SolidColorBrush(Colors.Black);
            lblFormaPago.Visibility = Visibility.Visible;
        }
        private void RellenarTextoFormaPago(object sender, EventArgs e)
        {
            if (txtPagoSocio.Text == string.Empty)
            {
                txtPagoSocio.Text = "Forma de pago";
                lblFormaPago.Visibility = Visibility.Hidden;
                txtPagoSocio.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void LimpiarTextoImagen(object sender, EventArgs e)
        {
            txtImagenSocioNuevo.Text = txtImagenSocioNuevo.Text == "Imagen" ? string.Empty : txtImagenSocioNuevo.Text;
            txtImagenSocioNuevo.Foreground = new SolidColorBrush(Colors.Black);
            lblImagen.Visibility = Visibility.Visible;
        }
        private void RellenarTextoImagen(object sender, EventArgs e)
        {
            if (txtImagenSocioNuevo.Text == string.Empty)
            {
                txtImagenSocioNuevo.Text = "Imagen";
                lblImagen.Visibility = Visibility.Hidden;
                txtImagenSocioNuevo.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void NuevoSocio_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Socio socio = new Socio
                {
                    NombreCompleto = txtNombreSocio.Text,
                    Correo = txtCorreoSocio.Text,
                    Dni = txtDniSocio.Text,
                    Telefono = Int32.Parse(txtTelefonoSocio.Text),
                    CuantiaAyuda = Int32.Parse(txtCuantiaSocio.Text),
                    DatosBancarios = txtDatosBanSocio.Text,
                    FormaPago = txtPagoSocio.Text

                };
                if (string.IsNullOrEmpty(txtImagenSocioNuevo.Text) || txtImagenSocioNuevo.Text == "Imagen")
                {
                    socio.Foto = "default.jpg";
                }
                else
                {
                    string s = txtImagenSocioNuevo.Text;
                    string[] subs = s.Split('\\');
                    socio.Foto = subs[subs.Length - 1];
                    //perro.Foto = string.Join("", subs);
                }
                //socio.Foto = "default.jpg";
                //string s = txtImagenPerroNuevo.Text;
                //string[] subs = s.Split('\\');
                //perro.Foto = subs[subs.Length - 1];


                GestorPersona.crearSocio(socio);
                pagSocios.CargarSocios();

                this.Close();
            }
            catch (FormatException ex)
            {
                Console.Write(ex);
                ComprobarEntradaInt(txtTelefonoSocio.Text, txtTelefonoSocio);
                ComprobarEntradaInt(txtCuantiaSocio.Text, txtCuantiaSocio);
                errorDatos.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                ELog.save(this, ex);
            }
        }

        private void BtnImagen_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog fd = new Microsoft.Win32.OpenFileDialog
            {
                Title = "Select a picture",
                Filter = "Images|*.jpg;*.gif;*.bmp;*.png"
            };
            if (fd.ShowDialog() == true)
            {
                try
                {
                    txtImagenSocioNuevo.Text = fd.FileName;
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show("Error al cargar la imagen " + ex.Message);
                }
            }
        }

        private void ComprobarEntradaInt(string valorIntroducido, System.Windows.Controls.TextBox componenteEntrada)
        {
            int num;
            bool cosa = int.TryParse(valorIntroducido, out num);
            if (cosa == false)
            {
                componenteEntrada.Foreground = Brushes.Red;
                componenteEntrada.ToolTip = "El dato introducido debe de ser del tipo numerico";
            }
        }
    }
}

