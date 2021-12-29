using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;
using Protectora.Dominio;
using Path = System.IO.Path;

namespace Protectora.Presentacion
{
    public partial class ClaseAniadirVoluntario : Window
    {
        PaginaVoluntarios pagVoluntarios;

        public ClaseAniadirVoluntario(PaginaVoluntarios p)
        {
            InitializeComponent();
            pagVoluntarios = p;
        }
        private void NuevoVoluntario_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Voluntario voluntario = new Voluntario
                {
                    NombreCompleto = txtNombreVoluntario.Text,
                    Correo = txtCorreoVoluntario.Text,
                    Dni = txtDniVoluntario.Text,
                    Telefono = Int32.Parse(txtTelefonoVoluntario.Text),
                    Horario = txtHorarioVol.Text,
                    ZonaDisponibilidad = txtZonaDisVol.Text,
                };

                if (string.IsNullOrEmpty(txtImagenVoluntarioNuevo.Text) || txtImagenVoluntarioNuevo.Text == "Imagen")
                {
                    voluntario.Foto = "default.jpg";
                }
                else
                {
                    string[] sourcePath = extraerFName(txtImagenVoluntarioNuevo.Text);
                    string sourceDir = sourcePath[0];
                    string fName = sourcePath[1];
                    voluntario.Foto = fName;

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

                GestorPersona.crearVoluntario(voluntario);
                pagVoluntarios.CargarVoluntarios();

                this.Close();
            }
            catch (FormatException ex)
            {
                ComprobarEntradaInt(txtTelefonoVoluntario.Text, txtTelefonoVoluntario);
                errorDatos.Visibility = Visibility.Visible;

                Console.Write(ex);
            }
            catch (Exception ex)
            {
                ELog.save(this, ex);
            }
        }


        //////////////////////////////////////////////////////////////// EVENTOS AUXILIARES ////////////////////////////////////////////////////////////////

        private void LimpiarTextoNombre(object sender, EventArgs e)
        {
            txtNombreVoluntario.Text = txtNombreVoluntario.Text == "Nombre completo" ? string.Empty : txtNombreVoluntario.Text;
            txtNombreVoluntario.Foreground = new SolidColorBrush(Colors.Black);
            lblNombre.Visibility = Visibility.Visible;
        }
        private void RellenarTextoNombre(object sender, EventArgs e)
        {
            if (txtNombreVoluntario.Text == string.Empty)
            {
                txtNombreVoluntario.Text = "Nombre completo";
                lblNombre.Visibility = Visibility.Hidden;
                txtNombreVoluntario.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void LimpiarTextoCorreo(object sender, EventArgs e)
        {
            txtCorreoVoluntario.Text = txtCorreoVoluntario.Text == "Correo" ? string.Empty : txtCorreoVoluntario.Text;
            txtCorreoVoluntario.Foreground = new SolidColorBrush(Colors.Black);
            lblCorreo.Visibility = Visibility.Visible;
        }
        private void RellenarTextoCorreo(object sender, EventArgs e)
        {
            if (txtCorreoVoluntario.Text == string.Empty)
            {
                txtCorreoVoluntario.Text = "Correo";
                lblCorreo.Visibility = Visibility.Hidden;
                txtCorreoVoluntario.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void LimpiarTextoDNI(object sender, EventArgs e)
        {
            txtDniVoluntario.Text = txtDniVoluntario.Text == "DNI" ? string.Empty : txtDniVoluntario.Text;
            txtDniVoluntario.Foreground = new SolidColorBrush(Colors.Black);
            lblDni.Visibility = Visibility.Visible;
        }
        private void RellenarTextoDNI(object sender, EventArgs e)
        {
            if (txtDniVoluntario.Text == string.Empty)
            {
                txtDniVoluntario.Text = "DNI";
                lblDni.Visibility = Visibility.Hidden;
                txtDniVoluntario.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void LimpiarTextoTelefono(object sender, EventArgs e)
        {
            txtTelefonoVoluntario.Text = txtTelefonoVoluntario.Text == "Telefono" ? string.Empty : txtTelefonoVoluntario.Text;
            txtTelefonoVoluntario.Foreground = new SolidColorBrush(Colors.Black);
            lblTelefono.Visibility = Visibility.Visible;
        }
        private void RellenarTextoTelefono(object sender, EventArgs e)
        {
            if (txtTelefonoVoluntario.Text == string.Empty)
            {
                txtTelefonoVoluntario.Text = "Telefono";
                lblTelefono.Visibility = Visibility.Hidden;
                txtTelefonoVoluntario.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void LimpiarTextoHorario(object sender, EventArgs e)
        {
            txtHorarioVol.Text = txtHorarioVol.Text == "Horario del voluntario" ? string.Empty : txtHorarioVol.Text;
            txtHorarioVol.Foreground = new SolidColorBrush(Colors.Black);
            lblHorario.Visibility = Visibility.Visible;
        }
        private void RellenarTextoHorario(object sender, EventArgs e)
        {
            if (txtHorarioVol.Text == string.Empty)
            {
                txtHorarioVol.Text = "Horario del voluntario";
                lblHorario.Visibility = Visibility.Hidden;
                txtHorarioVol.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void LimpiarTextoZona(object sender, EventArgs e)
        {
            txtZonaDisVol.Text = txtZonaDisVol.Text == "Zona disponible" ? string.Empty : txtZonaDisVol.Text;
            txtZonaDisVol.Foreground = new SolidColorBrush(Colors.Black);
            lblZona.Visibility = Visibility.Visible;
        }
        private void RellenarTextoZona(object sender, EventArgs e)
        {
            if (txtZonaDisVol.Text == string.Empty)
            {
                txtZonaDisVol.Text = "Zona disponible";
                lblZona.Visibility = Visibility.Hidden;
                txtZonaDisVol.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void LimpiarTextoImagen(object sender, EventArgs e)
        {
            txtImagenVoluntarioNuevo.Text = txtImagenVoluntarioNuevo.Text == "Imagen" ? string.Empty : txtImagenVoluntarioNuevo.Text;
            txtImagenVoluntarioNuevo.Foreground = new SolidColorBrush(Colors.Black);
            lblImagen.Visibility = Visibility.Visible;
        }
        private void RellenarTextoImagen(object sender, EventArgs e)
        {
            if (txtImagenVoluntarioNuevo.Text == string.Empty)
            {
                txtImagenVoluntarioNuevo.Text = "Imagen";
                lblImagen.Visibility = Visibility.Hidden;
                txtImagenVoluntarioNuevo.Foreground = new SolidColorBrush(Colors.Gray);
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
                    txtImagenVoluntarioNuevo.Text = fd.FileName;
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

        private void ComprobarEntradaInt(string valorIntroducido, TextBox componenteEntrada)
        {
            int num;
            bool cosa = int.TryParse(valorIntroducido, out num);
            if (cosa == false)
            {
                componenteEntrada.Foreground = Brushes.Red;
                componenteEntrada.ToolTip = "El dato introducido debe de ser del tipo numerico";
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
