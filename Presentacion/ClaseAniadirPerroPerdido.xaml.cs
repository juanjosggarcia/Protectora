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
        }
        private void RellenarTextoNombrePerdido(object sender, EventArgs e)
        {
            txtNombrePerroPerdido.Text = txtNombrePerroPerdido.Text == string.Empty ? "Nombre" : txtNombrePerroPerdido.Text;
            txtNombrePerroPerdido.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void LimpiarTextoSexoPerdido(object sender, EventArgs e)
        {
            txtSexoPerroPerdido.Text = txtSexoPerroPerdido.Text == "Sexo" ? string.Empty : txtSexoPerroPerdido.Text;
            txtSexoPerroPerdido.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void RellenarTextoSexoPerdido(object sender, EventArgs e)
        {
            txtSexoPerroPerdido.Text = txtSexoPerroPerdido.Text == string.Empty ? "Sexo" : txtSexoPerroPerdido.Text;
            txtSexoPerroPerdido.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void LimpiarTextoTamanioPerdido(object sender, EventArgs e)
        {
            txtTamanioPerroPerdido.Text = txtTamanioPerroPerdido.Text == "Tamaño" ? string.Empty : txtTamanioPerroPerdido.Text;
            txtTamanioPerroPerdido.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void RellenarTextoTamanioPerdido(object sender, EventArgs e)
        {
            txtTamanioPerroPerdido.Text = txtTamanioPerroPerdido.Text == string.Empty ? "Tamaño" : txtTamanioPerroPerdido.Text;
            txtTamanioPerroPerdido.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void LimpiarTextoDescripcionAdicional(object sender, EventArgs e)
        {
            txtDescripcionAdicionalPerroPerdido.Text = txtDescripcionAdicionalPerroPerdido.Text == "Descripción adicional" ? string.Empty : txtDescripcionAdicionalPerroPerdido.Text;
            txtDescripcionAdicionalPerroPerdido.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void RellenarTextoDescripcionAdicional(object sender, EventArgs e)
        {
            txtDescripcionAdicionalPerroPerdido.Text = txtDescripcionAdicionalPerroPerdido.Text == string.Empty ? "Descripción adicional" : txtDescripcionAdicionalPerroPerdido.Text;
            txtDescripcionAdicionalPerroPerdido.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void LimpiarTextoDescripcionPerdido(object sender, EventArgs e)
        {
            txtDescripcionPerroPerdido.Text = txtDescripcionPerroPerdido.Text == "Descripción del perro" ? string.Empty : txtDescripcionPerroPerdido.Text;
            txtDescripcionPerroPerdido.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void RellenarTextoDescripcionPerdido(object sender, EventArgs e)
        {
            txtDescripcionPerroPerdido.Text = txtDescripcionPerroPerdido.Text == string.Empty ? "Descripción del perro" : txtDescripcionPerroPerdido.Text;
            txtDescripcionPerroPerdido.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void LimpiarTextoZonaPerdido(object sender, EventArgs e)
        {
            txtZonaPerroPerdido.Text = txtZonaPerroPerdido.Text == "Zona de pérdida" ? string.Empty : txtZonaPerroPerdido.Text;
            txtZonaPerroPerdido.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void RellenarTextoZonaPerdido(object sender, EventArgs e)
        {
            txtZonaPerroPerdido.Text = txtZonaPerroPerdido.Text == string.Empty ? "Zona de pérdida" : txtZonaPerroPerdido.Text;
            txtZonaPerroPerdido.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void LimpiarTextoRazaPerdido(object sender, EventArgs e)
        {
            txtRazaPerroPerdido.Text = txtRazaPerroPerdido.Text == "Raza" ? string.Empty : txtRazaPerroPerdido.Text;
            txtRazaPerroPerdido.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void RellenarTextoRazaPerdido(object sender, EventArgs e)
        {
            txtRazaPerroPerdido.Text = txtRazaPerroPerdido.Text == string.Empty ? "Raza" : txtRazaPerroPerdido.Text;
            txtRazaPerroPerdido.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void LimpiarTextoImagenPerdido(object sender, EventArgs e)
        {
            txtImagenPerroNuevoPerdido.Text = txtImagenPerroNuevoPerdido.Text == "Imagen" ? string.Empty : txtImagenPerroNuevoPerdido.Text;
            txtImagenPerroNuevoPerdido.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void RellenarTextoImagenPerdido(object sender, EventArgs e)
        {
            txtImagenPerroNuevoPerdido.Text = txtImagenPerroNuevoPerdido.Text == string.Empty ? "Imagen" : txtImagenPerroNuevoPerdido.Text;
            txtImagenPerroNuevoPerdido.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void LimpiarNombreDuenio(object sender, EventArgs e)
        {
            txtNombreDuenio.Text = txtNombreDuenio.Text == "Nombre del dueño" ? string.Empty : txtNombreDuenio.Text;
            txtNombreDuenio.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void RellenarNombreDuenio(object sender, EventArgs e)
        {
            txtNombreDuenio.Text = txtNombreDuenio.Text == string.Empty ? "Nombre del dueño" : txtNombreDuenio.Text;
            txtNombreDuenio.Foreground = new SolidColorBrush(Colors.Gray);
        }
        private void LimpiarDniDuenio(object sender, EventArgs e)
        {
            txtDniDuenio.Text = txtDniDuenio.Text == "DNI" ? string.Empty : txtDniDuenio.Text;
            txtDniDuenio.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void RellenarDniDuenio(object sender, EventArgs e)
        {
            txtDniDuenio.Text = txtDniDuenio.Text == string.Empty ? "DNI" : txtDniDuenio.Text;
            txtDniDuenio.Foreground = new SolidColorBrush(Colors.Gray);
        }
        private void LimpiarCorreoDuenio(object sender, EventArgs e)
        {
            txtCorreoDuenio.Text = txtCorreoDuenio.Text == "Correo" ? string.Empty : txtCorreoDuenio.Text;
            txtCorreoDuenio.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void RellenarCorreoDuenio(object sender, EventArgs e)
        {
            txtCorreoDuenio.Text = txtCorreoDuenio.Text == string.Empty ? "Correo" : txtCorreoDuenio.Text;
            txtCorreoDuenio.Foreground = new SolidColorBrush(Colors.Gray);
        }
        private void LimpiarTelefonoDuenio(object sender, EventArgs e)
        {
            txtTelefonoDuenio.Text = txtTelefonoDuenio.Text == "Telefono" ? string.Empty : txtTelefonoDuenio.Text;
            txtTelefonoDuenio.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void RellenarTelefonoDuenio(object sender, EventArgs e)
        {
            txtTelefonoDuenio.Text = txtTelefonoDuenio.Text == string.Empty ? "Telefono" : txtTelefonoDuenio.Text;
            txtTelefonoDuenio.Foreground = new SolidColorBrush(Colors.Gray);

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

            //ventana.paneles[0].CrearPerro(perro);
            //pagPerro.CrearPerro(perro);
            //GestorAnimal.crearPerro(perro);
            //if ((bool)btnPadrinoRedondo.IsChecked)
            //{
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
    }
}
