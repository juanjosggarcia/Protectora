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

namespace Protectora.Presentacion
{
    /// <summary>
    /// Lógica de interacción para PaginaAvisos.xaml
    /// </summary>
    public partial class PaginaAvisos : Page
    {
        public PaginaAvisos()
        {
            InitializeComponent();
            CargarPerrosPerdidos();
        }

        private void BtnDuenio_Click(object sender, RoutedEventArgs e)
        {
            Perro perro = (Perro)ListViewPerrosPerdidos.Items[ListViewPerrosPerdidos.SelectedIndex];
            ClaseDuenio winDuenio = new ClaseDuenio(this, perro);
            winDuenio.Show();

        }

        private void ClickNuevoPerroPerdido(object sender, RoutedEventArgs e)
        {
            ClaseAniadirPerroPerdido nuevoPerroPerdido = new ClaseAniadirPerroPerdido(this);
            nuevoPerroPerdido.Show();

        }

        private void ListaPerrosPerdidos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItems = ListViewPerrosPerdidos.SelectedItems;
            foreach (Perro perro in selectedItems)
            {
                SetPerroPerdido(perro);
                DesactivarTextBoxsPerdido();

            }

            btnAnteriorPerroPerdido.IsEnabled = true;
            btnNextPerroPerdido.IsEnabled = true;
            btnEditPerroPerdido.IsEnabled = true;
            btnDeletePerroPerdido.IsEnabled = true;
        }
        public void SetPerroPerdido(Perro perro)
        {
            //try
            //{
            //    TextBoxId.Text = perro.Id.ToString();
            //    TextBoxSexo.Text = perro.Sexo;
            //    TextBoxNombre.Text = perro.Nombre;
            //    TextBoxTamanio.Text = perro.Tamanio.ToString();
            //    TextBoxEstado.Text = perro.Estado;
            //    TextBoxPeso.Text = perro.Peso.ToString();
            //    TextBoxEdad.Text = perro.Edad.ToString();
            //    TextBoxEntrada.Text = perro.FechaEntrada.ToString("dd-MM-yyyy");
            //    TextBoxDescripcion.Text = perro.Descripcion;
            //    TextBoxRaza.Text = perro.Raza;
            //    //string str = @"C:\Users\juanj\vs2019-workspace\Protectora\recursos\Fotosbd\" + perro.Foto;
            //    string str = @"../fotosPerros/" + perro.Foto;
            //    BitmapImage bitmap = new BitmapImage();
            //    bitmap.BeginInit();
            //    bitmap.UriSource = new Uri(str, UriKind.Relative);
            //    //bitmap.UriSource = new Uri(@"../fotosPerros/bichon.jpg", UriKind.Relative);
            //    bitmap.EndInit();
            //    ProfileImagePerroPerdido.Source = bitmap;


            //}
            //catch (Exception ex)
            //{
            //    Console.Write(ex);
            //    //List<String> fila;
            //}
        }

        public void CargarPerrosPerdidos()
        {

        }

        private void BtnNextPerroPerdido_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewPerrosPerdidos.SelectedIndex != ListViewPerrosPerdidos.Items.Count - 1)
            {
                ListViewPerrosPerdidos.SelectedIndex++;
            }
        }

        private void BtnAnteriorPerroPerdido_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewPerrosPerdidos.SelectedIndex != 0)
            {
                ListViewPerrosPerdidos.SelectedIndex--;
            }
        }

        private void BtnEditPerroPerdido_Click(object sender, RoutedEventArgs e)
        {
            TextBoxIdPerroPer.IsEnabled = true;
            TextBoxSexoPerdido.IsEnabled = true;
            TextBoxNombrePerdido.IsEnabled = true;
            TextBoxTamanioPerdido.IsEnabled = true;
            TextBoxRazaPerdido.IsEnabled = true;
            TextBoxZonaPerdida.IsEnabled = true;
            TextBoxFechaPerdida.IsEnabled = true;
            TextBoxDescripcionPerdida.IsEnabled = true;
            TextBoxDescripcionAdicional.IsEnabled = true;

            btnImagenPerroPerdido.IsEnabled = true;
            BtnDuenio.IsEnabled = true;
            btnEditCancelarPerroPerdido.Visibility = Visibility.Visible;
            btnEditConfirmarPerroPerdido.Visibility = Visibility.Visible;
            btnEditPerroPerdido.Visibility = Visibility.Hidden;
            btnDeletePerroPerdido.Visibility = Visibility.Hidden;
            btnAnteriorPerroPerdido.Visibility = Visibility.Hidden;
            btnNextPerroPerdido.Visibility = Visibility.Hidden;
            btnImagenPerroPerdido.Visibility = Visibility.Visible;
            NuevoPerroPerdido.Visibility = Visibility.Hidden;
            ListViewPerrosPerdidos.IsEnabled = false;
        }

        private void BtnDeletePerroPerdido_Click(object sender, RoutedEventArgs e)
        {
            int index = ListViewPerrosPerdidos.SelectedIndex;
            string message = "¿Estas seguro que quieres eliminar el perro seleccionado?";
            string caption = "Eliminación de perro";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            DialogResult result;

            // Displays the MessageBox.
            result = (DialogResult)System.Windows.MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                // Closes the parent form.
                //System.Windows.Forms.ListViewItem item = (System.Windows.Forms.ListViewItem)ListViewPerros.Items[ListViewPerros.SelectedIndex];
                Perro perro = (Perro)ListViewPerrosPerdidos.Items[ListViewPerrosPerdidos.SelectedIndex];

                //int idperro = item.SubItems[0].Text;
                //int cosa= ListViewPerros.ListViewSubItem();

                //Perro perro = new Perro();
                //string idper = TextBoxId.Text;
                //int idperro = Int32.Parse(TextBoxId.Text);

                //perro.Id = idperro;
                //GestorAnimal.eliminarPerro(perro);
                TextBoxIdPerroPer.Text = "";
                TextBoxSexoPerdido.Text = "";
                TextBoxNombrePerdido.Text = "";
                TextBoxTamanioPerdido.Text = "";
                TextBoxRazaPerdido.Text = "";
                TextBoxZonaPerdida.Text = "";
                TextBoxFechaPerdida.Text = "";
                TextBoxDescripcionPerdida.Text = "";
                TextBoxDescripcionAdicional.Text = "";
                //@"../fotosPerros/default.jpg"
                string str = @"../fotosPerros/default.jpg";
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(str, UriKind.Relative);
                bitmap.EndInit();
                ProfileImagePerroPerdido.Source = bitmap;
            }
            //SetPerro(ListViewPerros.Items.IndexOf;


        }
        private void BtnImagenPerroPerdido_Click(object sender, RoutedEventArgs e)
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
                ProfileImagePerroPerdido.Source = bitmap;

            }
            catch (Exception ex)
            {
                if (ex.Message != "URI no válido: URI está vacío.")
                {
                    System.Windows.MessageBox.Show("Error al cargar la imagen " + ex.Message);
                }
            }

        }
        private void btnEditCancelarPerroPerdido_Click(object sender, RoutedEventArgs e)
        {
            Perro perro = (Perro)ListViewPerrosPerdidos.Items[ListViewPerrosPerdidos.SelectedIndex];
            SetPerroPerdido(perro);
            DesactivarTextBoxsPerdido();
        }
        private void btnEditConfirmarPerroPerdido_Click(object sender, RoutedEventArgs e)
        {
            Perro perro = (Perro)ListViewPerrosPerdidos.Items[ListViewPerrosPerdidos.SelectedIndex];

            try
            {
                //perro.Sexo = TextBoxSexo.Text;
                //perro.Nombre = TextBoxNombre.Text;
                //perro.Tamanio = Int32.Parse(TextBoxTamanio.Text);
                //perro.Estado = TextBoxEstado.Text;
                //perro.Peso = Int32.Parse(TextBoxPeso.Text);
                //perro.Edad = Int32.Parse(TextBoxEdad.Text);
                //perro.FechaEntrada = DateTime.Parse(TextBoxEntrada.Text);
                //perro.Descripcion = TextBoxDescripcion.Text;
                //perro.Raza = TextBoxRaza.Text;

                string s = ProfileImagePerroPerdido.Source.ToString();
                string[] subs = s.Split('/');
                perro.Foto = subs[subs.Length - 1];

                //GestorAnimal.modificarPerro(perro);
                DesactivarTextBoxsPerdido();
            }
            catch (Exception ex)
            {
                Console.Write(ex);

                //List<String> fila;
            }

        }
        private void DesactivarTextBoxsPerdido()
        {
            TextBoxIdPerroPer.IsEnabled = false;
            TextBoxSexoPerdido.IsEnabled = false;
            TextBoxNombrePerdido.IsEnabled = false;
            TextBoxTamanioPerdido.IsEnabled = false;
            TextBoxRazaPerdido.IsEnabled = false;
            TextBoxZonaPerdida.IsEnabled = false;
            TextBoxFechaPerdida.IsEnabled = false;
            TextBoxDescripcionPerdida.IsEnabled = false;
            TextBoxDescripcionAdicional.IsEnabled = false;

            btnImagenPerroPerdido.IsEnabled = false;
            BtnDuenio.IsEnabled = true;
            
            btnEditPerroPerdido.Visibility = Visibility.Visible;
            btnDeletePerroPerdido.Visibility = Visibility.Visible;
            btnAnteriorPerroPerdido.Visibility = Visibility.Visible;
            btnNextPerroPerdido.Visibility = Visibility.Visible;
            NuevoPerroPerdido.Visibility = Visibility.Visible;
            btnEditCancelarPerroPerdido.Visibility = Visibility.Hidden;
            btnEditConfirmarPerroPerdido.Visibility = Visibility.Hidden;
            ListViewPerrosPerdidos.IsEnabled = true;
        }

        private void btnBuscarPerroPerdido_Click(object sender, RoutedEventArgs e)
        {

        }

        //private void ComprobarEntradaInt(string valorIntroducido, TextBox componenteEntrada)
        //{
        //    int num;
        //    bool cosa = int.TryParse(valorIntroducido, out num);
        //    if (cosa == false)
        //    {
        //        componenteEntrada.Foreground = Brushes.Red;

        //    }

        //}

        //private void PulsarEdad(object sender, RoutedEventArgs e)
        //{
        //    TextBoxEdad.Foreground = Brushes.Black;
        //}
    }
}
