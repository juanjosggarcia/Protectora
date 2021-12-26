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
        }
        private void RellenarTextoNombre(object sender, EventArgs e)
        {
            txtNombreSocio.Text = txtNombreSocio.Text == string.Empty ? "Nombre completo" : txtNombreSocio.Text;
            txtNombreSocio.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void LimpiarTextoCorreo(object sender, EventArgs e)
        {
            txtCorreoSocio.Text = txtCorreoSocio.Text == "Correo" ? string.Empty : txtCorreoSocio.Text;
            txtCorreoSocio.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void RellenarTextoCorreo(object sender, EventArgs e)
        {
            txtCorreoSocio.Text = txtCorreoSocio.Text == string.Empty ? "Correo" : txtCorreoSocio.Text;
            txtCorreoSocio.Foreground = new SolidColorBrush(Colors.Gray);
        }
        private void LimpiarTextoDNI(object sender, EventArgs e)
        {
            txtDniSocio.Text = txtDniSocio.Text == "DNI" ? string.Empty : txtDniSocio.Text;
            txtDniSocio.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void RellenarTextoDNI(object sender, EventArgs e)
        {
            txtDniSocio.Text = txtDniSocio.Text == string.Empty ? "DNI" : txtDniSocio.Text;
            txtDniSocio.Foreground = new SolidColorBrush(Colors.Gray);
        }
        private void LimpiarTextoTelefono(object sender, EventArgs e)
        {
            txtTelefonoSocio.Text = txtTelefonoSocio.Text == "Telefono" ? string.Empty : txtTelefonoSocio.Text;
            txtTelefonoSocio.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void RellenarTextoTelefono(object sender, EventArgs e)
        {
            txtTelefonoSocio.Text = txtTelefonoSocio.Text == string.Empty ? "Telefono" : txtTelefonoSocio.Text;
            txtTelefonoSocio.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void LimpiarTextoCuantia(object sender, EventArgs e)
        {
            txtCuantiaSocio.Text = txtCuantiaSocio.Text == "Cuantia de la ayuda" ? string.Empty : txtCuantiaSocio.Text;
            txtCuantiaSocio.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void RellenarTextoCuantia(object sender, EventArgs e)
        {
            txtCuantiaSocio.Text = txtCuantiaSocio.Text == string.Empty ? "Cuantia de la ayuda" : txtCuantiaSocio.Text;
            txtCuantiaSocio.Foreground = new SolidColorBrush(Colors.Gray);
        }
        private void LimpiarTextoDatosBan(object sender, EventArgs e)
        {
            txtDatosBanSocio.Text = txtDatosBanSocio.Text == "Datos bancarios" ? string.Empty : txtDatosBanSocio.Text;
            txtDatosBanSocio.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void RellenarTextoDatosBan(object sender, EventArgs e)
        {
            txtDatosBanSocio.Text = txtDatosBanSocio.Text == string.Empty ? "Datos bancarios" : txtDatosBanSocio.Text;
            txtDatosBanSocio.Foreground = new SolidColorBrush(Colors.Gray);
        }
        private void LimpiarTextoFormaPago(object sender, EventArgs e)
        {
            txtPagoSocio.Text = txtPagoSocio.Text == "Forma de pago" ? string.Empty : txtPagoSocio.Text;
            txtPagoSocio.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void RellenarTextoFormaPago(object sender, EventArgs e)
        {
            txtPagoSocio.Text = txtPagoSocio.Text == string.Empty ? "Forma de pago" : txtPagoSocio.Text;
            txtPagoSocio.Foreground = new SolidColorBrush(Colors.Gray);
        }
        private void LimpiarTextoImagen(object sender, EventArgs e)
        {
            txtPagoSocio.Text = txtPagoSocio.Text == "Forma de pago" ? string.Empty : txtPagoSocio.Text;
            txtPagoSocio.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void RellenarTextoImagen(object sender, EventArgs e)
        {
            txtPagoSocio.Text = txtPagoSocio.Text == string.Empty ? "Forma de pago" : txtPagoSocio.Text;
            txtPagoSocio.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void NuevoSocio_Click(object sender, RoutedEventArgs e)
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
            socio.Foto = "";
            //string s = txtImagenPerroNuevo.Text;
            //string[] subs = s.Split('\\');
            //perro.Foto = subs[subs.Length - 1];
            

            GestorPersona.crearSocio(socio);
            pagSocios.CargarSocios();

            this.Close();
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
                    txtImagenPerroNuevo.Text = fd.FileName;
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show("Error al cargar la imagen " + ex.Message);
                }
            }
        }
    }
}

