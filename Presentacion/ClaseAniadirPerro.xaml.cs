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
            lblNombre.Visibility = Visibility.Visible;
        }
        private void RellenarTextoNombre(object sender, EventArgs e)
        {
            if (txtNombrePerro.Text == string.Empty){
                txtNombrePerro.Text = "Nombre";
                lblNombre.Visibility = Visibility.Hidden;
                txtNombrePerro.Foreground = new SolidColorBrush(Colors.Gray);
            }

        }

        private void LimpiarTextoSexo(object sender, EventArgs e)
        {
            txtSexoPerro.Text = txtSexoPerro.Text == "Sexo" ? string.Empty : txtSexoPerro.Text;
            txtSexoPerro.Foreground = new SolidColorBrush(Colors.Black);
            lblSexo.Visibility = Visibility.Visible;

        }
        private void RellenarTextoSexo(object sender, EventArgs e)
        {
            if (txtSexoPerro.Text == string.Empty)
            {
                txtSexoPerro.Text = "Sexo";
                lblSexo.Visibility = Visibility.Hidden;
                txtSexoPerro.Foreground = new SolidColorBrush(Colors.Gray);
            }

        }

        private void LimpiarTextoTamanio(object sender, EventArgs e)
        {
            txtTamanioPerro.Text = txtTamanioPerro.Text == "Tamaño" ? string.Empty : txtTamanioPerro.Text;
            txtTamanioPerro.Foreground = new SolidColorBrush(Colors.Black);
            lblTamanio.Visibility = Visibility.Visible;

        }
        private void RellenarTextoTamanio(object sender, EventArgs e)
        {
            if (txtTamanioPerro.Text == string.Empty)
            {
                txtTamanioPerro.Text = "Tamaño";
                lblTamanio.Visibility = Visibility.Hidden;
                txtTamanioPerro.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void LimpiarTextoPeso(object sender, EventArgs e)
        {
            txtPesoPerro.Text = txtPesoPerro.Text == "Peso" ? string.Empty : txtPesoPerro.Text;
            txtPesoPerro.Foreground = new SolidColorBrush(Colors.Black);
            lblPeso.Visibility = Visibility.Visible;

        }
        private void RellenarTextoPeso(object sender, EventArgs e)
        {
            if (txtPesoPerro.Text == string.Empty)
            {
                txtPesoPerro.Text = "Peso";
                lblPeso.Visibility = Visibility.Hidden;
                txtPesoPerro.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void LimpiarTextoEdad(object sender, EventArgs e)
        {
            txtEdadPerro.Text = txtEdadPerro.Text == "Edad" ? string.Empty : txtEdadPerro.Text;
            txtEdadPerro.Foreground = new SolidColorBrush(Colors.Black);
            lblEdad.Visibility = Visibility.Visible;

        }
        private void RellenarTextoEdad(object sender, EventArgs e)
        {
            if (txtEdadPerro.Text == string.Empty)
            {
                txtEdadPerro.Text = "Edad";
                lblEdad.Visibility = Visibility.Hidden;
                txtEdadPerro.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void LimpiarTextoEstado(object sender, EventArgs e)
        {
            txtEstadoPerro.Text = txtEstadoPerro.Text == "Estado" ? string.Empty : txtEstadoPerro.Text;
            txtEstadoPerro.Foreground = new SolidColorBrush(Colors.Black);
            lblEstado.Visibility = Visibility.Visible;

        }
        private void RellenarTextoEstado(object sender, EventArgs e)
        {
            if (txtEstadoPerro.Text == string.Empty)
            {
                txtEstadoPerro.Text = "Estado";
                lblEstado.Visibility = Visibility.Hidden;
                txtEstadoPerro.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void LimpiarTextoDescripcion(object sender, EventArgs e)
        {
            txtDescripcionPerro.Text = txtDescripcionPerro.Text == "Descripción" ? string.Empty : txtDescripcionPerro.Text;
            txtDescripcionPerro.Foreground = new SolidColorBrush(Colors.Black);
            lblDescripcion.Visibility = Visibility.Visible;

        }
        private void RellenarTextoDescripcion(object sender, EventArgs e)
        {
            if (txtDescripcionPerro.Text == string.Empty)
            {
                txtDescripcionPerro.Text = "Descripción";
                lblDescripcion.Visibility = Visibility.Hidden;
                txtDescripcionPerro.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void LimpiarTextoRaza(object sender, EventArgs e)
        {
            txtRazaPerro.Text = txtRazaPerro.Text == "Raza" ? string.Empty : txtRazaPerro.Text;
            txtRazaPerro.Foreground = new SolidColorBrush(Colors.Black);
            lblRaza.Visibility = Visibility.Visible;

        }
        private void RellenarTextoRaza(object sender, EventArgs e)
        {
            if (txtRazaPerro.Text == string.Empty)
            {
                txtRazaPerro.Text = "Raza";
                lblRaza.Visibility = Visibility.Hidden;
                txtRazaPerro.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void LimpiarTextoImagen(object sender, EventArgs e)
        {
            txtImagenPerroNuevo.Text = txtImagenPerroNuevo.Text == "Imagen" ? string.Empty : txtImagenPerroNuevo.Text;
            txtImagenPerroNuevo.Foreground = new SolidColorBrush(Colors.Black);
            lblImagen.Visibility = Visibility.Visible;

        }
        private void RellenarTextoImagen(object sender, EventArgs e)
        {
            if (txtImagenPerroNuevo.Text == string.Empty)
            {
                txtRazaPerro.Text = "Imagen";
                lblImagen.Visibility = Visibility.Hidden;
                txtImagenPerroNuevo.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void LimpiarNombrePadrino(object sender, EventArgs e)
        {
            txtNombrePadrino.Text = txtNombrePadrino.Text == "Nombre del padrino" ? string.Empty : txtNombrePadrino.Text;
            txtNombrePadrino.Foreground = new SolidColorBrush(Colors.Black);
            lblNombrePadrino.Visibility = Visibility.Visible;

        }
        private void RellenarNombrePadrino(object sender, EventArgs e)
        {
            if (txtNombrePadrino.Text == string.Empty)
            {
                txtNombrePadrino.Text = "Nombre del padrino";
                lblNombrePadrino.Visibility = Visibility.Hidden;
                txtNombrePadrino.Foreground = new SolidColorBrush(Colors.Gray);
            }

        }
        private void LimpiarDniPadrino(object sender, EventArgs e)
        {
            txtDniPadrino.Text = txtDniPadrino.Text == "DNI" ? string.Empty : txtDniPadrino.Text;
            txtDniPadrino.Foreground = new SolidColorBrush(Colors.Black);
            lblDniPadrino.Visibility = Visibility.Visible;

        }
        private void RellenarDniPadrino(object sender, EventArgs e)
        {
            if (txtDniPadrino.Text == string.Empty)
            {
                txtDniPadrino.Text = "DNI";
                lblDniPadrino.Visibility = Visibility.Hidden;
                txtDniPadrino.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void LimpiarCorreoPadrino(object sender, EventArgs e)
        {
            txtCorreoPadrino.Text = txtCorreoPadrino.Text == "Correo" ? string.Empty : txtCorreoPadrino.Text;
            txtCorreoPadrino.Foreground = new SolidColorBrush(Colors.Black);
            lblCorreoPadrino.Visibility = Visibility.Visible;

        }
        private void RellenarCorreoPadrino(object sender, EventArgs e)
        {
            if (txtCorreoPadrino.Text == string.Empty)
            {
                txtCorreoPadrino.Text = "Correo";
                lblCorreoPadrino.Visibility = Visibility.Hidden;
                txtCorreoPadrino.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void LimpiarTelefonoPadrino(object sender, EventArgs e)
        {
            txtTelefonoPadrino.Text = txtTelefonoPadrino.Text == "Telefono" ? string.Empty : txtTelefonoPadrino.Text;
            txtTelefonoPadrino.Foreground = new SolidColorBrush(Colors.Black);
            lblTelefonoPadrino.Visibility = Visibility.Visible;

        }
        private void RellenarTelefonoPadrino(object sender, EventArgs e)
        {
            if (txtTelefonoPadrino.Text == string.Empty)
            {
                txtTelefonoPadrino.Text = "Telefono";
                lblTelefonoPadrino.Visibility = Visibility.Hidden;
                txtTelefonoPadrino.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void LimpiarDatosPadrino(object sender, EventArgs e)
        {
            txtDatosPadrino.Text = txtDatosPadrino.Text == "Datos bancarios" ? string.Empty : txtDatosPadrino.Text;
            txtDatosPadrino.Foreground = new SolidColorBrush(Colors.Black);
            lblDatosBanPadrino.Visibility = Visibility.Visible;

        }
        private void RellenarDatosPadrino(object sender, EventArgs e)
        {
            if (txtDatosPadrino.Text == string.Empty)
            {
                txtDatosPadrino.Text = "Datos bancarios";
                lblDatosBanPadrino.Visibility = Visibility.Hidden;
                txtDatosPadrino.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void LimpiarImportePadrino(object sender, EventArgs e)
        {
            txtImportePadrino.Text = txtImportePadrino.Text == "Importe mensual" ? string.Empty : txtImportePadrino.Text;
            txtImportePadrino.Foreground = new SolidColorBrush(Colors.Black);
            lblImportePadrino.Visibility = Visibility.Visible;

        }
        private void RellenarImportePadrino(object sender, EventArgs e)
        {
            if (txtImportePadrino.Text == string.Empty)
            {
                txtImportePadrino.Text = "Importe mensual";
                lblImportePadrino.Visibility = Visibility.Hidden;
                txtImportePadrino.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void LimpiarFormaPagoPadrino(object sender, EventArgs e)
        {
            txtFormaPagoPadrino.Text = txtFormaPagoPadrino.Text == "Forma de pago" ? string.Empty : txtFormaPagoPadrino.Text;
            txtFormaPagoPadrino.Foreground = new SolidColorBrush(Colors.Black);
            lblFormaPagoPadrino.Visibility = Visibility.Visible;

        }
        private void RellenarFormaPagoPadrino(object sender, EventArgs e)
        {
            if (txtFormaPagoPadrino.Text == string.Empty)
            {
                txtFormaPagoPadrino.Text = "Forma de pago";
                lblFormaPagoPadrino.Visibility = Visibility.Hidden;
                txtFormaPagoPadrino.Foreground = new SolidColorBrush(Colors.Gray);
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
            try
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
                if (string.IsNullOrEmpty(txtImagenPerroNuevo.Text) || txtImagenPerroNuevo.Text == "Imagen")
                {
                    perro.Foto = "default.jpg";
                }
                else
                {
                    string s = txtImagenPerroNuevo.Text;
                    string[] subs = s.Split('\\');
                    perro.Foto = subs[subs.Length - 1];
                    //perro.Foto = string.Join("", subs);
                }

                //ventana.paneles[0].CrearPerro(perro);
                //pagPerro.CrearPerro(perro);
                //GestorAnimal.crearPerro(perro);
                if ((bool)btnPadrinoRedondo.IsChecked)
                {
                    Padrino padrino = new Padrino();
                    padrino.NombreCompleto = txtNombrePadrino.Text;
                    padrino.Dni = txtDniPadrino.Text;
                    padrino.Correo = txtCorreoPadrino.Text;
                    padrino.Telefono = Int32.Parse(txtTelefonoPadrino.Text);
                    padrino.DatosBancarios = txtDatosPadrino.Text;
                    padrino.ImporteMensual = Int32.Parse(txtImportePadrino.Text);
                    padrino.FormaPago = txtFormaPagoPadrino.Text;
                    padrino.FechaEntrada = DateTime.Parse(dateComienzoPadrino.Text);
                    int idPadrino = GestorPersona.addPadrino(padrino, perro);
                    perro.Apadrinado = idPadrino;

                }

                GestorAnimal.crearPerro(perro);
                pagPerro.CargarPerros();
                this.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                ComprobarEntradaInt(txtTamanioPerro.Text, txtTamanioPerro);
                ComprobarEntradaInt(txtPesoPerro.Text, txtPesoPerro);
                ComprobarEntradaInt(txtEdadPerro.Text, txtEdadPerro);
                ComprobarEntradaFecha(dateEntradaPerro.Text, dateEntradaPerro);

                ComprobarEntradaInt(txtTelefonoPadrino.Text, txtTelefonoPadrino);
                ComprobarEntradaInt(txtImportePadrino.Text, txtImportePadrino);
                ComprobarEntradaFecha(dateComienzoPadrino.Text, dateComienzoPadrino);

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

        private void PulsarFechaComienzo(object sender, RoutedEventArgs e)
        {
            dateComienzoPadrino.Foreground = Brushes.Black;
            lblFechaPadrino.Visibility = Visibility.Visible;

        }

        private void PulsarFechaEntrada(object sender, RoutedEventArgs e)
        {
            dateEntradaPerro.Foreground = Brushes.Black;
            lblFechaEntrada.Visibility = Visibility.Visible;
        }

        private void LimpiarTextoFecha(object sender, RoutedEventArgs e)
        {
            if (dateEntradaPerro.Text == string.Empty)
            {
                dateEntradaPerro.Foreground = Brushes.Gray;
                lblFechaEntrada.Visibility = Visibility.Hidden;
            }
        }

        private void LimpiarTextoFechaComienzo(object sender, RoutedEventArgs e)
        {
            if (dateComienzoPadrino.Text == string.Empty)
            {
                dateComienzoPadrino.Foreground = Brushes.Gray;
                lblFechaPadrino.Visibility = Visibility.Hidden;
            }
        }


    }

}
