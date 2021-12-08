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

namespace Protectora.Presentacion
{
    /// <summary>
    /// Lógica de interacción para BotonAniadir.xaml
    /// </summary>
    public partial class BotonAniadir : Window
    {
        public BotonAniadir()
        {
            InitializeComponent();
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

        private void LimpiarTextoEntrada(object sender, EventArgs e)
        {
            if (txtEntradaPerro.Text == "Entrada")
            {
                txtEntradaPerro.Text = "";
                txtEntradaPerro.Foreground = new SolidColorBrush(Colors.Black);
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

        private void btnImagen_Click(object sender, RoutedEventArgs e)
        {
            var abrirDialog = new OpenFileDialog();
            abrirDialog.Filter = "Images|*.jpg;*.gif;*.bmp;*.png";
            if (abrirDialog.ShowDialog() == true)
            {
                try
                {
                    ControlUsuarioPerro controlPerro = new ControlUsuarioPerro();

                    var bitmap = new BitmapImage(new Uri(abrirDialog.FileName, UriKind.Absolute));
                    controlPerro.imgPerro.Source = bitmap;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen " + ex.Message);
                }
            }
        }

        private void nuevoPerro_Click(object sender, RoutedEventArgs e)
        {
            ControlUsuarioPerro controlPerro = new ControlUsuarioPerro();
            controlPerro.nombre = txtNombrePerro.Text;
            controlPerro.sexo = txtNombrePerro.Text;
            controlPerro.tamanio = txtNombrePerro.Text;
            controlPerro.estado = txtNombrePerro.Text;
            controlPerro.edad = txtNombrePerro.Text;
            controlPerro.peso = txtNombrePerro.Text;
            controlPerro.entrada = txtNombrePerro.Text;
            controlPerro.descripcion = txtNombrePerro.Text;

            //Perros.PanelDinamicoBotones.Children.Add(controlPerro()); NO SE COMO HACER ESTO
        }
    }
}
