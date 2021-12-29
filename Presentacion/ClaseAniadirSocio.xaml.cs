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
using System.IO;
using Path = System.IO.Path;
using MessageBox = System.Windows.MessageBox;

namespace Protectora.Presentacion
{
    public partial class ClaseAniadirSocio : Window
    {
        PaginaSocios pagSocios;
        public ClaseAniadirSocio(PaginaSocios p)
        {
            InitializeComponent();
            pagSocios = p;
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
                    string[] sourcePath = extraerFName(txtImagenSocioNuevo.Text);
                    string sourceDir = sourcePath[0];
                    string fName = sourcePath[1];
                    socio.Foto = fName;

                    string rutaPersonas = obtenerPath() + "/fotosPersonas";
                    string[] picListTXT = Directory.GetFiles(rutaPersonas, "*.jpg");
                    string[] picListPNG = Directory.GetFiles(rutaPersonas, "*.png");
                    string[] picListGIF = Directory.GetFiles(rutaPersonas, "*.gif");
                    string[] picListBMP = Directory.GetFiles(rutaPersonas, "*.bmp");
                    string[] picList1 = picListTXT.Concat(picListPNG).ToArray();
                    string[] picList2 = picList1.Concat(picListGIF).ToArray();
                    string[] picList = picList2.Concat(picListBMP).ToArray();

                    if (!(picList.Contains(rutaPersonas + "\\" + fName)))
                    {
                        copiarImagen(sourceDir, fName);
                    }
                }
                GestorPersona.crearSocio(socio);
                pagSocios.CargarSocios();

                this.Close();
            }
            catch (FormatException ex)
            {
                Console.Write(ex);
                ComprobarEntradaInt(txtTelefonoSocio.Text, txtTelefonoSocio, errorTelefono);
                ComprobarEntradaInt(txtCuantiaSocio.Text, txtCuantiaSocio, errorCuantia);
                errorDatos.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                ELog.save(this, ex);
            }
        }

        //////////////////////////////////////////////////////////////// EVENTOS AUXILIARES ////////////////////////////////////////////////////////////////

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
            errorTelefono.Visibility = Visibility.Hidden;

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
            errorCuantia.Visibility = Visibility.Hidden;

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
                catch (UriFormatException ex)
                {
                    Console.WriteLine(ex);
                }
                catch (NotSupportedException ex)
                {
                    Console.WriteLine(ex);
                    MessageBox.Show("EL formato de imagen elegido no esta soportado");
                }
                catch (Exception ex)
                {
                    ELog.save(this, ex);
                }
            }
        }
        private void ComprobarEntradaInt(string valorIntroducido, System.Windows.Controls.TextBox componenteEntrada, Image entradaImagen)
        {
            int num;
            bool cosa = int.TryParse(valorIntroducido, out num);
            if (cosa == false)
            {
                componenteEntrada.Foreground = Brushes.Red;
                componenteEntrada.ToolTip = "El dato introducido debe de ser del tipo numerico";
                entradaImagen.Visibility = Visibility.Visible;

            }
        }

        /////////////////////////////////////////////////////////////// FUNCIONES AUXILIARES ///////////////////////////////////////////////////////////////

        private string obtenerPath()
        {
            string pathExe = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            string pathApp1 = pathExe.Substring(8);
            string proc = "/Protectora/";
            int posBin = pathApp1.IndexOf(proc);
            string pathApp = pathApp1.Remove(posBin + proc.Length - 1);
            return pathApp;
        }

        private string[] extraerFName(string sourcePath)
        {
            string[] subs = sourcePath.Split('\\');
            if (subs.Length == 1)
            {
                subs = sourcePath.Split('/');
            }
            string fName = subs[subs.Length - 1];
            string sourceDir1 = sourcePath.Substring(0, (sourcePath.Length - fName.Length - 1));
            string sourceDir;
            if (sourceDir1.Contains("file///"))
            {
                sourceDir = sourcePath.Substring(8);
            }
            else
            {
                sourceDir = sourceDir1;
            }
            string[] datos = { sourceDir, fName };
            return datos;
        }
        private string copiarImagen(string sourceDir, string fName)
        {

            string pathApp = obtenerPath();

            string backupDir = pathApp + "/fotosPersonas";

            string[] picListTXT = Directory.GetFiles(backupDir, "*.jpg");
            string[] picListPNG = Directory.GetFiles(backupDir, "*.png");
            string[] picListGIF = Directory.GetFiles(backupDir, "*.gif");
            string[] picListBMP = Directory.GetFiles(backupDir, "*.bmp");
            string[] picList1 = picListTXT.Concat(picListPNG).ToArray();
            string[] picList2 = picList1.Concat(picListGIF).ToArray();
            string[] picList = picList2.Concat(picListBMP).ToArray();

            if (!(picList.Contains(backupDir + "\\" + fName)))
            {
                try
                {
                    File.Copy(Path.Combine(sourceDir, fName), Path.Combine(backupDir, fName), true);
                }
                catch (DirectoryNotFoundException ex)
                {
                    ELog.save(this, ex);
                }
            }
            return fName;
        }
    }
}

