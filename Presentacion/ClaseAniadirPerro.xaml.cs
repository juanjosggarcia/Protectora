using Microsoft.Win32;
using Protectora.Dominio;
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

namespace Protectora.Presentacion
{
    /// <summary>
    /// Lógica de interacción para BotonAniadir.xaml
    /// </summary>
    public partial class ClaseAniadirPerro: Window
    {
        PaginaPerro pagPerro;
        public ClaseAniadirPerro(PaginaPerro p)
        {
            InitializeComponent();
            pagPerro = p;
        }

        //no se si esto se puede hacer mejor pero por ahora se queda asi
        private void LimpiarTextoNombre(object sender, EventArgs e)
        {
            txtNombrePerro.Text = txtNombrePerro.Text == "Nombre" ? string.Empty : txtNombrePerro.Text;
            txtNombrePerro.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void RellenarTextoNombre(object sender, EventArgs e)
        {
            txtNombrePerro.Text = txtNombrePerro.Text == string.Empty ? "Nombre" : txtNombrePerro.Text;
            txtNombrePerro.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void LimpiarTextoSexo(object sender, EventArgs e)
        {
            txtSexoPerro.Text = txtSexoPerro.Text == "Sexo" ? string.Empty : txtSexoPerro.Text;
            txtSexoPerro.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void RellenarTextoSexo(object sender, EventArgs e)
        {
            txtSexoPerro.Text = txtSexoPerro.Text == string.Empty ? "Sexo" : txtSexoPerro.Text;
            txtSexoPerro.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void LimpiarTextoTamanio(object sender, EventArgs e)
        {
            txtTamanioPerro.Text = txtTamanioPerro.Text == "Tamaño" ? string.Empty : txtTamanioPerro.Text;
            txtTamanioPerro.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void RellenarTextoTamanio(object sender, EventArgs e)
        {
            txtTamanioPerro.Text = txtTamanioPerro.Text == string.Empty ? "Tamaño" : txtTamanioPerro.Text;
            txtTamanioPerro.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void LimpiarTextoPeso(object sender, EventArgs e)
        {
            txtPesoPerro.Text = txtPesoPerro.Text == "Peso" ? string.Empty : txtPesoPerro.Text;
            txtPesoPerro.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void RellenarTextoPeso(object sender, EventArgs e)
        {
            txtPesoPerro.Text = txtPesoPerro.Text == string.Empty ? "Peso" : txtPesoPerro.Text;
            txtPesoPerro.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void LimpiarTextoEdad(object sender, EventArgs e)
        {
            txtEdadPerro.Text = txtEdadPerro.Text == "Edad" ? string.Empty : txtEdadPerro.Text;
            txtEdadPerro.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void RellenarTextoEdad(object sender, EventArgs e)
        {
            txtEdadPerro.Text = txtEdadPerro.Text == string.Empty ? "Edad" : txtEdadPerro.Text;
            txtEdadPerro.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void LimpiarTextoEstado(object sender, EventArgs e)
        {
            txtEstadoPerro.Text = txtEstadoPerro.Text == "Estado" ? string.Empty : txtEstadoPerro.Text;
            txtEstadoPerro.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void RellenarTextoEstado(object sender, EventArgs e)
        {
            txtEstadoPerro.Text = txtEstadoPerro.Text == string.Empty ? "Estado" : txtEstadoPerro.Text;
            txtEstadoPerro.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void LimpiarTextoDescripcion(object sender, EventArgs e)
        {
            txtDescripcionPerro.Text = txtDescripcionPerro.Text == "Descripción" ? string.Empty : txtDescripcionPerro.Text;
            txtDescripcionPerro.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void RellenarTextoDescripcion(object sender, EventArgs e)
        {
            txtDescripcionPerro.Text = txtDescripcionPerro.Text == string.Empty ? "Descripción" : txtDescripcionPerro.Text;
            txtDescripcionPerro.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void LimpiarTextoRaza(object sender, EventArgs e)
        {
            txtRazaPerro.Text = txtRazaPerro.Text == "Raza" ? string.Empty : txtRazaPerro.Text;
            txtRazaPerro.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void RellenarTextoRaza(object sender, EventArgs e)
        {
            txtRazaPerro.Text = txtRazaPerro.Text == string.Empty ? "Raza" : txtRazaPerro.Text;
            txtRazaPerro.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void LimpiarTextoImagen(object sender, EventArgs e)
        {
            txtImagenPerroNuevo.Text = txtImagenPerroNuevo.Text == "Imagen" ? string.Empty : txtImagenPerroNuevo.Text;
            txtImagenPerroNuevo.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void RellenarTextoImagen(object sender, EventArgs e)
        {
            txtImagenPerroNuevo.Text = txtImagenPerroNuevo.Text == string.Empty ? "Imagen" : txtImagenPerroNuevo.Text;
            txtImagenPerroNuevo.Foreground = new SolidColorBrush(Colors.Gray);
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
                    txtImagenPerroNuevo.Text = op.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen " + ex.Message);
                }
            }
        }

        private void NuevoPerro_Click(object sender, RoutedEventArgs e)
        {
            Perro perro = new Perro
            {
                Nombre = txtNombrePerro.Text,
                Sexo = txtSexoPerro.Text,
                Tamanio = Int32.Parse(txtTamanioPerro.Text),
                Estado = txtEstadoPerro.Text,
                Peso = Int32.Parse(txtPesoPerro.Text),
                Edad = Int32.Parse(txtEdadPerro.Text),
                FechaEntrada = DateTime.Parse(dateEntradaPerro.Text),
                Descripcion = txtDescripcionPerro.Text,
                //Foto = txtImagenPerroNuevo.Text,
                Raza = txtRazaPerro.Text
            };
            string s = txtImagenPerroNuevo.Text;
            string[] subs = s.Split('\\');
            perro.Foto = subs[subs.Length-1];
            //perro.Foto = string.Join("", subs);


            //ventana.paneles[0].CrearPerro(perro);
            //pagPerro.CrearPerro(perro);
            GestorAnimal.crearPerro(perro);
            pagPerro.CargarPerros();

            this.Close();
        }
    }

}
