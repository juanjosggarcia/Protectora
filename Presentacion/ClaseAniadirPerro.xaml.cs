using Microsoft.Win32;
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
            if (txtNombrePerro.Text == "Nombre")
            {
                txtNombrePerro.Text = "";
                txtNombrePerro.Foreground = new SolidColorBrush(Colors.Black);

            }

        }

        private void LimpiarTextoSexo(object sender, EventArgs e)
        {
            if (txtSexoPerro.Text == "Sexo")
            {
                txtSexoPerro.Text = "";
                txtSexoPerro.Foreground = new SolidColorBrush(Colors.Black);

            }
        }

        private void LimpiarTextoTamanio(object sender, EventArgs e)
        {
            if (txtTamanioPerro.Text == "Tamaño")
            {
                txtTamanioPerro.Text = "";
                txtTamanioPerro.Foreground = new SolidColorBrush(Colors.Black);

            }
        }

        private void LimpiarTextoPeso(object sender, EventArgs e)
        {
            if (txtPesoPerro.Text == "Peso")
            {
                txtPesoPerro.Text = "";
                txtPesoPerro.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void LimpiarTextoEdad(object sender, EventArgs e)
        {
            if (txtEdadPerro.Text == "Edad")
            {
                txtEdadPerro.Text = "";
                txtEdadPerro.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void LimpiarTextoEstado(object sender, EventArgs e)
        {
            if (txtEstadoPerro.Text == "Estado")
            {
                txtEstadoPerro.Text = "";
                txtEstadoPerro.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void LimpiarTextoDescripcion(object sender, EventArgs e)
        {
            if (txtDescripcionPerro.Text == "Descripción")
            {
                txtDescripcionPerro.Text = "";
                txtDescripcionPerro.Foreground = new SolidColorBrush(Colors.Black);
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
                Foto = txtImagenPerroNuevo.Text,
                Raza = txtRazaPerro.Text
            };

            //ventana.paneles[0].CrearPerro(perro);
            pagPerro.CrearPerro(perro);

            this.Close();
        }
    }

}
