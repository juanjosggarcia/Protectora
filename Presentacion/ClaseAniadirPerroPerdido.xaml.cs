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
using System.Windows.Shapes;
using Microsoft.Win32;
using Protectora.Dominio;

namespace Protectora.Presentacion
{
    /// <summary>
    /// Lógica de interacción para ClaseAniadirPerroPerdido.xaml
    /// </summary>
    public partial class ClaseAniadirPerroPerdido : Window
    {
        PaginaAvisos pagAviso;
        public ClaseAniadirPerroPerdido(PaginaAvisos p)
        {
            InitializeComponent();
            pagAviso = p;
        }

        private void LimpiarTextoNombrePerdido(object sender, EventArgs e)
        {
            txtNombrePerroPerdido.Text = txtNombrePerroPerdido.Text == "Nombre" ? string.Empty : txtNombrePerroPerdido.Text;
            txtNombrePerroPerdido.Foreground = new SolidColorBrush(Colors.Black);
            lblNombre.Visibility = Visibility.Visible;

        }
        private void RellenarTextoNombrePerdido(object sender, EventArgs e)
        {
            if (txtNombrePerroPerdido.Text == string.Empty)
            {
                txtNombrePerroPerdido.Text = "Nombre";
                lblNombre.Visibility = Visibility.Hidden;
                txtNombrePerroPerdido.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void LimpiarTextoSexoPerdido(object sender, EventArgs e)
        {
            txtSexoPerroPerdido.Text = txtSexoPerroPerdido.Text == "Sexo" ? string.Empty : txtSexoPerroPerdido.Text;
            txtSexoPerroPerdido.Foreground = new SolidColorBrush(Colors.Black);
            lblSexo.Visibility = Visibility.Visible;

        }
        private void RellenarTextoSexoPerdido(object sender, EventArgs e)
        {
            if (txtSexoPerroPerdido.Text == string.Empty)
            {
                txtSexoPerroPerdido.Text = "Sexo";
                lblSexo.Visibility = Visibility.Hidden;
                txtSexoPerroPerdido.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void LimpiarTextoTamanioPerdido(object sender, EventArgs e)
        {
            txtTamanioPerroPerdido.Text = txtTamanioPerroPerdido.Text == "Tamaño" ? string.Empty : txtTamanioPerroPerdido.Text;
            txtTamanioPerroPerdido.Foreground = new SolidColorBrush(Colors.Black);
            lblTamanio.Visibility = Visibility.Visible;

        }
        private void RellenarTextoTamanioPerdido(object sender, EventArgs e)
        {
            if (txtTamanioPerroPerdido.Text == string.Empty)
            {
                txtTamanioPerroPerdido.Text = "Tamaño";
                lblTamanio.Visibility = Visibility.Hidden;
                txtTamanioPerroPerdido.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void LimpiarTextoDescripcionAdicional(object sender, EventArgs e)
        {
            txtDescripcionAdicionalPerroPerdido.Text = txtDescripcionAdicionalPerroPerdido.Text == "Descripción adicional" ? string.Empty : txtDescripcionAdicionalPerroPerdido.Text;
            txtDescripcionAdicionalPerroPerdido.Foreground = new SolidColorBrush(Colors.Black);
            lblDescripcionAdicional.Visibility = Visibility.Visible;

        }
        private void RellenarTextoDescripcionAdicional(object sender, EventArgs e)
        {
            if (txtDescripcionAdicionalPerroPerdido.Text == string.Empty)
            {
                txtDescripcionAdicionalPerroPerdido.Text = "Descripción adicional";
                lblDescripcionAdicional.Visibility = Visibility.Hidden;
                txtDescripcionAdicionalPerroPerdido.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void LimpiarTextoDescripcionPerdido(object sender, EventArgs e)
        {
            txtDescripcionPerroPerdido.Text = txtDescripcionPerroPerdido.Text == "Descripción del perro" ? string.Empty : txtDescripcionPerroPerdido.Text;
            txtDescripcionPerroPerdido.Foreground = new SolidColorBrush(Colors.Black);
            lblDescripcion.Visibility = Visibility.Visible;

        }
        private void RellenarTextoDescripcionPerdido(object sender, EventArgs e)
        {
            if (txtDescripcionPerroPerdido.Text == string.Empty)
            {
                txtDescripcionPerroPerdido.Text = "Descripción del perro";
                lblDescripcion.Visibility = Visibility.Hidden;
                txtDescripcionPerroPerdido.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void LimpiarTextoZonaPerdido(object sender, EventArgs e)
        {
            txtZonaPerroPerdido.Text = txtZonaPerroPerdido.Text == "Zona de pérdida" ? string.Empty : txtZonaPerroPerdido.Text;
            txtZonaPerroPerdido.Foreground = new SolidColorBrush(Colors.Black);
            lblZona.Visibility = Visibility.Visible;

        }
        private void RellenarTextoZonaPerdido(object sender, EventArgs e)
        {
            if (txtZonaPerroPerdido.Text == string.Empty)
            {
                txtZonaPerroPerdido.Text = "Zona de perdida";
                lblZona.Visibility = Visibility.Hidden;
                txtZonaPerroPerdido.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void LimpiarTextoRazaPerdido(object sender, EventArgs e)
        {
            txtRazaPerroPerdido.Text = txtRazaPerroPerdido.Text == "Raza" ? string.Empty : txtRazaPerroPerdido.Text;
            txtRazaPerroPerdido.Foreground = new SolidColorBrush(Colors.Black);
            lblRaza.Visibility = Visibility.Visible;

        }
        private void RellenarTextoRazaPerdido(object sender, EventArgs e)
        {
            if (txtRazaPerroPerdido.Text == string.Empty)
            {
                txtRazaPerroPerdido.Text = "Raza";
                lblRaza.Visibility = Visibility.Hidden;
                txtRazaPerroPerdido.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void LimpiarTextoImagenPerdido(object sender, EventArgs e)
        {
            txtImagenPerroNuevoPerdido.Text = txtImagenPerroNuevoPerdido.Text == "Imagen" ? string.Empty : txtImagenPerroNuevoPerdido.Text;
            txtImagenPerroNuevoPerdido.Foreground = new SolidColorBrush(Colors.Black);
            lblImagen.Visibility = Visibility.Visible;

        }
        private void RellenarTextoImagenPerdido(object sender, EventArgs e)
        {
            if (txtImagenPerroNuevoPerdido.Text == string.Empty)
            {
                txtImagenPerroNuevoPerdido.Text = "Imagen";
                lblImagen.Visibility = Visibility.Hidden;
                txtImagenPerroNuevoPerdido.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void LimpiarNombreDuenio(object sender, EventArgs e)
        {
            txtNombreDuenio.Text = txtNombreDuenio.Text == "Nombre del dueño" ? string.Empty : txtNombreDuenio.Text;
            txtNombreDuenio.Foreground = new SolidColorBrush(Colors.Black);
            lblNombreDuenio.Visibility = Visibility.Visible;

        }
        private void RellenarNombreDuenio(object sender, EventArgs e)
        {
            if (txtNombreDuenio.Text == string.Empty)
            {
                txtNombreDuenio.Text = "Nombre del dueño";
                lblNombreDuenio.Visibility = Visibility.Hidden;
                txtNombreDuenio.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void LimpiarDniDuenio(object sender, EventArgs e)
        {
            txtDniDuenio.Text = txtDniDuenio.Text == "DNI" ? string.Empty : txtDniDuenio.Text;
            txtDniDuenio.Foreground = new SolidColorBrush(Colors.Black);
            lblDni.Visibility = Visibility.Visible;

        }
        private void RellenarDniDuenio(object sender, EventArgs e)
        {
            if (txtDniDuenio.Text == string.Empty)
            {
                txtDniDuenio.Text = "DNI";
                lblDni.Visibility = Visibility.Hidden;
                txtDniDuenio.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void LimpiarCorreoDuenio(object sender, EventArgs e)
        {
            txtCorreoDuenio.Text = txtCorreoDuenio.Text == "Correo" ? string.Empty : txtCorreoDuenio.Text;
            txtCorreoDuenio.Foreground = new SolidColorBrush(Colors.Black);
            lblCorreo.Visibility = Visibility.Visible;

        }
        private void RellenarCorreoDuenio(object sender, EventArgs e)
        {
            if (txtCorreoDuenio.Text == string.Empty)
            {
                txtCorreoDuenio.Text = "Correo";
                lblCorreo.Visibility = Visibility.Hidden;
                txtCorreoDuenio.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void LimpiarTelefonoDuenio(object sender, EventArgs e)
        {
            txtTelefonoDuenio.Text = txtTelefonoDuenio.Text == "Telefono" ? string.Empty : txtTelefonoDuenio.Text;
            txtTelefonoDuenio.Foreground = new SolidColorBrush(Colors.Black);
            lblTelefono.Visibility = Visibility.Visible;

        }
        private void RellenarTelefonoDuenio(object sender, EventArgs e)
        {
            if (txtTelefonoDuenio.Text == string.Empty)
            {
                txtTelefonoDuenio.Text = "Telefono";
                lblTelefono.Visibility = Visibility.Hidden;
                txtTelefonoDuenio.Foreground = new SolidColorBrush(Colors.Gray);
            }

        }

        private void BtnImagen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog
            {
                Title = "Select a picture",
                Filter = "Images|*.jpg;*.gif;*.bmp;*.png"
            };
            if (op.ShowDialog() == true)
            {
                try
                {
                    txtImagenPerroNuevoPerdido.Text = op.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen " + ex.Message);
                }
            }
        }

        private void NuevoAviso_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Aviso aviso = new Aviso
                {
                    Nombre = txtNombrePerroPerdido.Text,
                    Sexo = txtSexoPerroPerdido.Text,
                    Tamanio = Int32.Parse(txtTamanioPerroPerdido.Text),
                    Raza = txtRazaPerroPerdido.Text,
                    FechaPerdida = DateTime.Parse(dateFechaPerroPerdido.Text),
                    ZonaPerdida = txtZonaPerroPerdido.Text,
                    DescripcionAnimal = txtDescripcionPerroPerdido.Text,
                    DescripcionAdicional = txtDescripcionAdicionalPerroPerdido.Text,
                };
                if (string.IsNullOrEmpty(txtImagenPerroNuevoPerdido.Text) || txtImagenPerroNuevoPerdido.Text == "Imagen")
                {
                    aviso.Foto = "default.jpg";
                }
                else
                {
                    string s = txtImagenPerroNuevoPerdido.Text;
                    string[] subs = s.Split('\\');
                    aviso.Foto = subs[subs.Length - 1];
                }

                Persona persona = new Persona();
                persona.NombreCompleto = txtNombreDuenio.Text;
                persona = GestorPersona.obtenerPersonaName(persona);
                if (persona == null)
                {
                    persona = new Persona
                    {
                        NombreCompleto = txtNombreDuenio.Text,
                        Dni = txtDniDuenio.Text,
                        Correo = txtCorreoDuenio.Text,
                        Telefono = Int32.Parse(txtTelefonoDuenio.Text)
                    };
                    persona.Id = GestorPersona.addPersona(persona);
                }

                aviso.IdDuenio = (int)persona.Id;
                GestorAnimal.crearAviso(aviso);
                pagAviso.CargarPerrosPerdidos();
                this.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                ComprobarEntradaInt(txtTamanioPerroPerdido.Text, txtTamanioPerroPerdido);
                ComprobarEntradaFecha(dateFechaPerroPerdido.Text, dateFechaPerroPerdido);
                ComprobarEntradaInt(txtTelefonoDuenio.Text, txtTelefonoDuenio);
                errorDatos.Visibility = Visibility.Visible;


                //List<String> fila;
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


        private void ComprobarEntradaFecha(string valorIntroducido, DatePicker componenteEntrada)
        {
            DateTime num;
            bool cosa = DateTime.TryParse(valorIntroducido, out num);
            if (cosa == false)
            {
                componenteEntrada.Foreground = Brushes.Red;
                componenteEntrada.ToolTip = "El dato introducido debe de ser del tipo fecha";

            }

        }

        private void PulsarFecha(object sender, RoutedEventArgs e)
        {
            dateFechaPerroPerdido.Foreground = Brushes.Black;
            lblFechaEntrada.Visibility = Visibility.Visible;

        }

        private void LimpiarFecha(object sender, RoutedEventArgs e)
        {
            if (dateFechaPerroPerdido.Text == string.Empty)
            {
                dateFechaPerroPerdido.Foreground = Brushes.Gray;
                lblFechaEntrada.Visibility = Visibility.Hidden;
            }
        }
        
    }
}
