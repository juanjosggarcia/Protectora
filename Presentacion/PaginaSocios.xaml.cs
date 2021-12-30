using Protectora.Dominio;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using MessageBox = System.Windows.MessageBox;
using Path = System.IO.Path;
using TextBox = System.Windows.Controls.TextBox;

namespace Protectora.Presentacion
{
    public partial class PaginaSocios : Page
    {
        //public List<Socio> listaSocio = new List<Socio>();
        public PaginaSocios()
        {
            InitializeComponent();
            CargarSocios();
        }
        private void ListaSocios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItems = ListViewSocios.SelectedItems;
            foreach (Socio socio in selectedItems)
            {
                SetSocio(socio);
                DesactivarTextBoxsSocios();
            }

            btnAnteriorSocio.IsEnabled = true;
            btnNextSocio.IsEnabled = true;
            btnEditSocio.IsEnabled = true;
            btnDeleteSocio.IsEnabled = true;
        }

        ///////////////////////////////////////////////////////////////// EVENTOS DE BOTON /////////////////////////////////////////////////////////////////

        private void ClickNuevoSocio(object sender, RoutedEventArgs e)
        {
            ClaseAniadirSocio nuevoSocio = new ClaseAniadirSocio(this);
            nuevoSocio.Show();
        }
        private void BtnDeleteSocio_Click(object sender, RoutedEventArgs e)
        {
            int index = ListViewSocios.SelectedIndex;
            string message = "¿Estas seguro que quieres eliminar el socio seleccionado?";
            string caption = "Eliminación de socio";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            DialogResult result;

            result = (DialogResult)MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    Socio socio = (Socio)ListViewSocios.Items[ListViewSocios.SelectedIndex];

                    GestorPersona.eliminarSocio(socio);
                    ListViewSocios.Items.RemoveAt(index);
                    TextBoxIdSocio.Text = "";
                    TextBoxIdSocio.Text = "";
                    TextBoxCorreoSocio.Text = "";
                    TextBoxNombreSocio.Text = "";
                    TextBoxDNISocio.Text = "";
                    TextBoxTelefonoSocio.Text = "";
                    TextBoxCuantiaSocio.Text = "";
                    TextBoxDatosBanSocio.Text = "";
                    TextBoxPagoSocio.Text = "";

                    //string str = obtenerPath() + @"/fotosPersonas/default.jpg";
                    ////string str = @"../fotosPersonas/default.jpg";
                    //BitmapImage bitmap = new BitmapImage();
                    //bitmap.BeginInit();
                    ////bitmap.UriSource = new Uri(str, UriKind.Relative);
                    //bitmap.UriSource = new Uri(str);
                    //bitmap.EndInit();
                    BitmapImage bmi = new BitmapImage(new Uri("pack://application:,,,/recursos/default.png"));
                    ProfileImageSocio.Source = bmi;

                }
                catch (Exception ex)
                {
                    ELog.save(this, ex);
                }
            }
        }
        private void BtnEditSocio_Click(object sender, RoutedEventArgs e)
        {
            ListViewSocios.IsEnabled = false;
            TextBoxIdSocio.IsEnabled = true;
            TextBoxCorreoSocio.IsEnabled = true;
            TextBoxNombreSocio.IsEnabled = true;
            TextBoxDNISocio.IsEnabled = true;
            TextBoxTelefonoSocio.IsEnabled = true;
            TextBoxCuantiaSocio.IsEnabled = true;
            TextBoxDatosBanSocio.IsEnabled = true;
            TextBoxPagoSocio.IsEnabled = true;
            btnImagenSocio.IsEnabled = true;

            btnEditCancelarSocio.Visibility = Visibility.Visible;
            btnEditConfirmarSocio.Visibility = Visibility.Visible;
            btnImagenSocio.Visibility = Visibility.Visible;
            btnEditSocio.Visibility = Visibility.Hidden;
            btnDeleteSocio.Visibility = Visibility.Hidden;
            btnAnteriorSocio.Visibility = Visibility.Hidden;
            btnNextSocio.Visibility = Visibility.Hidden;
            NuevoSocio.Visibility = Visibility.Hidden;

        }
        private void btnEditConfirmarSocio_Click(object sender, RoutedEventArgs e)
        {
            Socio socio = (Socio)ListViewSocios.Items[ListViewSocios.SelectedIndex];

            try
            {
                int index = ListViewSocios.SelectedIndex;
                socio.NombreCompleto = TextBoxNombreSocio.Text;
                socio.Correo = TextBoxCorreoSocio.Text;
                socio.Telefono = Int32.Parse(TextBoxTelefonoSocio.Text);
                socio.CuantiaAyuda = Int32.Parse(TextBoxCuantiaSocio.Text);
                socio.DatosBancarios = TextBoxDatosBanSocio.Text;
                socio.Dni = TextBoxDNISocio.Text;
                socio.FormaPago = TextBoxPagoSocio.Text;

                socio.Foto = Modulos.copiarImagen(ProfileImageSocio.Source.ToString(), "persona");

                GestorPersona.modificarSocio(socio);
                CargarSocios();
                DesactivarTextBoxsSocios();
                ListViewSocios.SelectedItem = ListViewSocios.Items[index];

            }
            catch (FormatException ex)
            {
                Console.Write(ex);
                ComprobarEntradaInt(TextBoxCuantiaSocio.Text, TextBoxCuantiaSocio, errorCuantia);
                ComprobarEntradaInt(TextBoxTelefonoSocio.Text, TextBoxTelefonoSocio, errorTelefono);
            }
            catch (Exception ex)
            {
                ELog.save(this, ex);
            }
        }
        private void btnEditCancelarSocio_Click(object sender, RoutedEventArgs e)
        {
            Socio socio = (Socio)ListViewSocios.Items[ListViewSocios.SelectedIndex];
            string message = "¿Estas seguro que quieres cacelar la edición? Se perderan todos los cambios no guardados";
            string caption = "Cancelar cambios";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            DialogResult result;

            result = (DialogResult)MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                SetSocio(socio);
                DesactivarTextBoxsSocios();
                ListViewSocios.SelectedItem = ListViewSocios.Items[ListViewSocios.SelectedIndex];
            }
        }
        private void btnBuscarSocio_Click(object sender, RoutedEventArgs e)
        {
            Socio socio = new Socio();

            if (!string.IsNullOrEmpty(TextBoxBuscarSocio.Text))
            {
                socio.NombreCompleto = TextBoxBuscarSocio.Text;
                List<Socio> socios = GestorPersona.obtenerSocio(socio);
                ListViewSocios.Items.Clear();
                if (socios != null)
                {
                    foreach (Socio soci in socios)
                    {
                        soci.Foto = "default.jpg";
                        ListViewSocios.Items.Add(soci);
                    }
                }
            }
            else
            {
                CargarSocios();
            }
        }

        private void btnMostrarTodosSocio_Click(object sender, RoutedEventArgs e)
        {
            CargarSocios();
        }
        private void BtnNextSocio_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewSocios.SelectedIndex != ListViewSocios.Items.Count - 1)
            {
                ListViewSocios.SelectedIndex++;
            }
        }
        private void BtnAnteriorSocio_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewSocios.SelectedIndex != 0)
            {
                ListViewSocios.SelectedIndex--;
            }
        }

        //////////////////////////////////////////////////////////////// EVENTOS AUXILIARES ////////////////////////////////////////////////////////////////

        private void BtnImagenSocio_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog
            {
                Title = "Select a picture",
                Filter = "Images|*.jpg;*.gif;*.bmp;*.png"
            };
            BitmapImage bitmap = new BitmapImage();
            op.ShowDialog();

            try
            {
                string str = op.FileName;
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(str);
                bitmap.EndInit();
                ProfileImageSocio.Source = bitmap;
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
        private void ComprobarEntradaInt(string valorIntroducido, TextBox componenteEntrada, Image entradaImagen)
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
        private void PulsarTelefono(object sender, RoutedEventArgs e)
        {
            TextBoxTelefonoSocio.Foreground = Brushes.Black;
            errorTelefono.Visibility = Visibility.Hidden;

        }
        private void PulsarCuantia(object sender, RoutedEventArgs e)
        {
            TextBoxCuantiaSocio.Foreground = Brushes.Black;
            errorCuantia.Visibility = Visibility.Hidden;

        }
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btnBuscarSocio_Click(sender, e);
            }
        }

        /////////////////////////////////////////////////////////////// FUNCIONES AUXILIARES ///////////////////////////////////////////////////////////////


        public void CargarSocios()
        {
            try
            {
                List<Socio> socios = GestorPersona.obtenerTodosSocios();
                ListViewSocios.Items.Clear();
                foreach (Socio socio in socios)
                {
                    if (string.IsNullOrEmpty(socio.Foto))
                    {
                        socio.Foto = "default.jpg";
                    }
                    ListViewSocios.Items.Add(socio);
                }
            }
            catch (Exception ex)
            {
                ELog.save(this, ex);
            }
        }
        public void SetSocio(Socio socio)
        {
            try
            {
                TextBoxIdSocio.Text = socio.Id.ToString();
                TextBoxCorreoSocio.Text = socio.Correo;
                TextBoxNombreSocio.Text = socio.NombreCompleto;
                TextBoxDNISocio.Text = socio.Dni;
                TextBoxTelefonoSocio.Text = socio.Telefono.ToString();
                TextBoxCuantiaSocio.Text = socio.CuantiaAyuda.ToString();
                TextBoxDatosBanSocio.Text = socio.DatosBancarios;
                TextBoxPagoSocio.Text = socio.FormaPago;

                string rutaPersonas = Path.Combine(Modulos.obtenerPath(), "imagenes\\fotosPersonas");

                string dirFoto = Path.Combine(rutaPersonas, socio.Foto);
                List<string> picList = Modulos.obtenerImagenesCarpeta(rutaPersonas);

                BitmapImage bitmap = new BitmapImage();

                if (!(picList.Contains(dirFoto)))
                {
                    bitmap = new BitmapImage(new Uri("pack://application:,,,/recursos/default.png"));
                }
                else
                {
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(dirFoto);
                    bitmap.EndInit();
                }
                ProfileImageSocio.Source = bitmap;

            }
            catch (Exception ex)
            {
                ELog.save(this, ex);
            }
        }
        private void DesactivarTextBoxsSocios()
        {
            TextBoxIdSocio.IsEnabled = false;
            TextBoxCorreoSocio.IsEnabled = false;
            TextBoxNombreSocio.IsEnabled = false;
            TextBoxDNISocio.IsEnabled = false;
            TextBoxTelefonoSocio.IsEnabled = false;
            TextBoxCuantiaSocio.IsEnabled = false;
            TextBoxDatosBanSocio.IsEnabled = false;
            TextBoxPagoSocio.IsEnabled = false;
            btnImagenSocio.IsEnabled = false;

            btnEditSocio.Visibility = Visibility.Visible;
            btnDeleteSocio.Visibility = Visibility.Visible;
            btnAnteriorSocio.Visibility = Visibility.Visible;
            btnNextSocio.Visibility = Visibility.Visible;
            NuevoSocio.Visibility = Visibility.Visible;
            btnEditCancelarSocio.Visibility = Visibility.Hidden;
            btnEditConfirmarSocio.Visibility = Visibility.Hidden;
            ListViewSocios.IsEnabled = true;
        }

    }
}
