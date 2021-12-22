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
        Dominio.Perro perroActual;
        List<Dominio.Perro> ListaPerros;
        PaginaPerro desde;
        public ClaseAniadirPerro(PaginaPerro p)
        {
            InitializeComponent();
            desde = p;
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

        private void btnImagen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "Images|*.jpg;*.gif;*.bmp;*.png";
            if (op.ShowDialog() == true)
            {
                try
                {
                    //ControlUsuarioPerro controlPerro = new ControlUsuarioPerro();

                    //var bitmap = new BitmapImage(new Uri(op.FileName, UriKind.Absolute));
                    //controlPerro.imgPerro.Source = bitmap;
                    txtImagenPerroNuevo.Text = op.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen " + ex.Message);
                }
            }
        }

        private void nuevoPerro_Click(object sender, RoutedEventArgs e)
        {
            //GestionPerro ventana = Application.Current.Windows.OfType<GestionPerro>().FirstOrDefault();
            //PaginaPerro main = new PaginaPerro();

            Dominio.Perro perro = new Dominio.Perro();
            perro.Nombre = txtNombrePerro.Text;
            perro.Sexo = txtSexoPerro.Text;
            perro.Tamanio = Int32.Parse(txtTamanioPerro.Text);
            perro.Estado = txtEstadoPerro.Text;
            perro.Peso = Int32.Parse(txtPesoPerro.Text);
            perro.Edad = Int32.Parse(txtEdadPerro.Text);
            perro.Entrada = DateTime.Parse(dateEntradaPerro.Text);
            perro.Descripcion = txtDescripcionPerro.Text;

            //main.SetPerro(perro);
            //main.Algoperro();

            //ventana.paneles[0].CrearPerro(perro);
            desde.CrearPerro(perro);

            this.Close();
        }
    }

}
