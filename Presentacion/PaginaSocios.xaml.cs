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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;
using TextBox = System.Windows.Controls.TextBox;

namespace Protectora.Presentacion
{
    /// <summary>
    /// Lógica de interacción para PaginaSocios.xaml
    /// </summary>
    public partial class PaginaSocios : Page
    {
        public List<Socio> listaSocio = new List<Socio>();
        public PaginaSocios()
        {
            InitializeComponent();
            CargarSocios();
        }

        private void ClickNuevoSocio(object sender, RoutedEventArgs e)
        {
            ClaseAniadirSocio nuevoSocio = new ClaseAniadirSocio(this);
            nuevoSocio.Show();

            //Algoperro();
            //Refresh();
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

        public void CargarSocios()
        {
            List<Socio> socios = GestorPersona.obtenerTodosSocios();
            //socios = GestorPersona.obtenerTodosSocios();
            ListViewSocios.Items.Clear();
            foreach (Socio socio in socios)
            {
                if (string.IsNullOrEmpty(socio.Foto))
                {
                    //perro.Foto = "C:\\Users\\laura\\source\\repos\\Protectora\\recursos\\default.png";
                    socio.Foto = "default.jpg";
                }
                listaSocio.Add(socio);
                ListViewSocios.Items.Add(socio);
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

                ////string str = @"C:\Users\juanj\vs2019-workspace\Protectora\recursos\Fotosbd\" + perro.Foto;
                string str = @"../fotosPersonas/" + socio.Foto;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(str, UriKind.Relative);
                //bitmap.UriSource = new Uri(@"../fotosPerros/bichon.jpg", UriKind.Relative);
                bitmap.EndInit();
                ProfileImage.Source = bitmap;


            }
            catch (Exception ex)
            {
                Console.Write(ex);
                //List<String> fila;
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

            btnEditSocio.Visibility = Visibility.Visible;
            btnDeleteSocio.Visibility = Visibility.Visible;
            btnAnteriorSocio.Visibility = Visibility.Visible;
            btnNextSocio.Visibility = Visibility.Visible;
            NuevoSocio.Visibility = Visibility.Visible;
            btnEditCancelarSocio.Visibility = Visibility.Hidden;
            btnEditConfirmarSocio.Visibility = Visibility.Hidden;
            ListViewSocios.IsEnabled = true;
        }


        private void BtnEditSocio_Click(object sender, RoutedEventArgs e)
        {
            TextBoxIdSocio.IsEnabled = true;
            TextBoxCorreoSocio.IsEnabled = true;
            TextBoxNombreSocio.IsEnabled = true;
            TextBoxDNISocio.IsEnabled = true;
            TextBoxTelefonoSocio.IsEnabled = true;
            TextBoxCuantiaSocio.IsEnabled = true;
            TextBoxDatosBanSocio.IsEnabled = true;
            TextBoxPagoSocio.IsEnabled = true;
            btnEditCancelarSocio.Visibility = Visibility.Visible;
            btnEditConfirmarSocio.Visibility = Visibility.Visible;
            btnEditSocio.Visibility = Visibility.Hidden;
            btnDeleteSocio.Visibility = Visibility.Hidden;
            btnAnteriorSocio.Visibility = Visibility.Hidden;
            btnNextSocio.Visibility = Visibility.Hidden;
            btnImagenSocio.Visibility = Visibility.Visible;
            NuevoSocio.Visibility = Visibility.Hidden;
            ListViewSocios.IsEnabled = false;

        }

        private void btnEditCancelarSocio_Click(object sender, RoutedEventArgs e)
        {
            Socio socio = (Socio)ListViewSocios.Items[ListViewSocios.SelectedIndex];
            SetSocio(socio);
            //TextBoxEdad.Foreground = Brushes.Black;
            //TextBoxPeso.Foreground = Brushes.Black;
            //TextBoxTamanio.Foreground = Brushes.Black;
            DesactivarTextBoxsSocios();
        }

        private void btnEditConfirmarSocio_Click(object sender, RoutedEventArgs e)
        {
            Socio socio = (Socio)ListViewSocios.Items[ListViewSocios.SelectedIndex];

            try
            {

                socio.NombreCompleto = TextBoxNombreSocio.Text;
                socio.Correo = TextBoxCorreoSocio.Text;
                socio.Telefono = Int32.Parse(TextBoxTelefonoSocio.Text);
                socio.CuantiaAyuda = Int32.Parse(TextBoxCuantiaSocio.Text);
                socio.DatosBancarios = TextBoxDatosBanSocio.Text;
                socio.Dni = TextBoxDNISocio.Text;
                socio.FormaPago = TextBoxPagoSocio.Text;

                GestorPersona.modificarSocio(socio);
                DesactivarTextBoxsSocios();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                ComprobarEntradaInt(TextBoxCuantiaSocio.Text, TextBoxCuantiaSocio);
                ComprobarEntradaInt(TextBoxTelefonoSocio.Text, TextBoxTelefonoSocio);

                //List<String> fila;
            }

            //Refresh();
        }

        private void ComprobarEntradaInt(string valorIntroducido, TextBox componenteEntrada)
        {
            int num;
            bool cosa = int.TryParse(valorIntroducido, out num);
            if (cosa == false)
            {
                componenteEntrada.Foreground = Brushes.Red;

            }

        }

        private void PulsarTelefono(object sender, RoutedEventArgs e)
        {
            TextBoxTelefonoSocio.Foreground = Brushes.Black;
        }

        private void PulsarCuantia(object sender, RoutedEventArgs e)
        {
            TextBoxCuantiaSocio.Foreground = Brushes.Black;
        }

        private void BtnDeletePerro_Click(object sender, RoutedEventArgs e)
        {
            int index = ListViewSocios.SelectedIndex;
            string message = "¿Estas seguro que quieres eliminar el socio seleccionado?";
            string caption = "Eliminación de socio";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            DialogResult result;

            // Displays the MessageBox.
            result = (DialogResult)MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Perro perro = (Perro)ListViewSocios.Items[ListViewSocios.SelectedIndex];

                //GestorAnimal.eliminarPerro(perro);
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
                //@"../fotosPerros/default.jpg"
                //string str = @"../fotosPerros/default.jpg";
                //BitmapImage bitmap = new BitmapImage();
                //bitmap.BeginInit();
                //bitmap.UriSource = new Uri(str, UriKind.Relative);
                //bitmap.EndInit();
                //ProfileImage.Source = bitmap;
            }
            //SetPerro(ListViewPerros.Items.IndexOf;



        }


    }
}
