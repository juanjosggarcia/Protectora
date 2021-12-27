using Protectora.Dominio;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Lógica de interacción para PaginaPerro.xaml
    /// </summary>
    public partial class PaginaPerro : Page
    {
        //Dominio.Perro perro;

        public List<Perro> listaPerro = new List<Perro>();

        public PaginaPerro()
        {
            InitializeComponent();
            CargarPerros();
            //Refresh();
        }

        private void BtnPdrino_Click(object sender, RoutedEventArgs e)
        {
            Perro perro = (Perro)ListViewPerros.Items[ListViewPerros.SelectedIndex];

            /*
            ClasePadrinoPerro winPadrino = System.Windows.Application.Current.Windows.OfType<ClasePadrinoPerro>().FirstOrDefault();

            if (winPadrino == null)
            {
                Perro perro = (Perro)ListViewPerros.Items[ListViewPerros.SelectedIndex];
                if ((bool)ListViewPerros.IsEnabled==false)
                {
                    winPadrino = new ClasePadrinoPerro(this, perro, true);
                }
                else
                {
                    winPadrino = new ClasePadrinoPerro(this, perro, false);
                }

            }
            winPadrino.Show();*/

            ClasePadrinoPerro winPadrino;
            if ((bool)ListViewPerros.IsEnabled == false)
            {
                winPadrino = new ClasePadrinoPerro(this, perro, true);
            }
            else
            {
                winPadrino = new ClasePadrinoPerro(this, perro, false);
            }

            //ClasePadrinoPerro Padrinito = new ClasePadrinoPerro(perro);
            winPadrino.Show();
        }

        private void ClickNuevoPerro(object sender, RoutedEventArgs e)
        {
            ClaseAniadirPerro nuevoPerro = new ClaseAniadirPerro(this);
            nuevoPerro.Show();

            //Algoperro();
            //Refresh();
        }

        private void ListaPerros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItems = ListViewPerros.SelectedItems;
            foreach (Perro perro in selectedItems)
            {
                SetPerro(perro);
                DesactivarTextBoxs();
                if (perro.Apadrinado != 0)
                {
                    BtnPdrino.IsEnabled = true;
                }
                else
                {
                    BtnPdrino.IsEnabled = false;
                }

            }

            btnAnteriorPerro.IsEnabled = true;
            btnNextPerro.IsEnabled = true;
            btnEditPerro.IsEnabled = true;
            btnDeletePerro.IsEnabled = true;
        }

        public void SetPerro(Perro perro)
        {
            try
            {
                TextBoxId.Text = perro.Id.ToString();
                TextBoxSexo.Text = perro.Sexo;
                TextBoxNombre.Text = perro.Nombre;
                TextBoxTamanio.Text = perro.Tamanio.ToString();
                TextBoxEstado.Text = perro.Estado;
                TextBoxPeso.Text = perro.Peso.ToString();
                TextBoxEdad.Text = perro.Edad.ToString();
                TextBoxEntrada.Text = perro.FechaEntrada.ToString("dd-MM-yyyy");
                TextBoxDescripcion.Text = perro.Descripcion;
                TextBoxRaza.Text = perro.Raza;
                //string str = @"C:\Users\juanj\vs2019-workspace\Protectora\recursos\Fotosbd\" + perro.Foto;
                string str = @"../fotosPerros/" + perro.Foto;
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

        public void CargarPerros()
        {
            List<Perro> perros = new List<Perro>();
            perros = GestorAnimal.obtenerTodosPerros();
            ListViewPerros.Items.Clear();
            foreach (Perro perro in perros)
            {
                if (string.IsNullOrEmpty(perro.Foto))
                {
                    //perro.Foto = "C:\\Users\\laura\\source\\repos\\Protectora\\recursos\\default.png";
                    perro.Foto = "default.jpg";
                }

                listaPerro.Add(perro);
                ListViewPerros.Items.Add(perro);

                //PanelDinamicoBotones.Children.Add(new ControlUsuarioPerro(perro));
                //TextBoxId.Text = perro.id.ToString();
                /*
                lblNombreAnimal.Content = perro.nombre;
                lblsexoAnimal.Content = perro.sexo;
                lbltamanioAnimal.Content = perro.tamanio;
                lblEstadoAnimal.Content = perro.estado;
                lblEdadAnimal.Content = perro.edad;
                lblPesoAnimal.Content = perro.peso;
                lblEntradaAnimal.Content = perro.fechaEntrada.ToString();
                lblDescrpcionAnimal.Content = perro.descripcion;
                */
            }

        }
        /*
        private void Refresh()
        {
            ListViewPerros.Items.Clear();
            if (listaPerro != null)
            {
                foreach (Perro perro in listaPerro)
                {
                    ListViewPerros.Items.Add(perro);
                }
            }
        }*/

        /*
        public void CrearPerro(Perro perro)
        {
            listaPerro.Add(perro);

            Refresh();
        }*/

        private void BtnNextPerro_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewPerros.SelectedIndex != ListViewPerros.Items.Count - 1)
            {
                ListViewPerros.SelectedIndex++;
            }
        }

        private void BtnAnteriorPerro_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewPerros.SelectedIndex != 0)
            {
                ListViewPerros.SelectedIndex--;
            }
        }

        private void BtnEditPerro_Click(object sender, RoutedEventArgs e)
        {
            TextBoxId.IsEnabled = true;
            TextBoxNombre.IsEnabled = true;
            TextBoxSexo.IsEnabled = true;
            TextBoxPeso.IsEnabled = true;
            TextBoxEdad.IsEnabled = true;
            TextBoxTamanio.IsEnabled = true;
            TextBoxEntrada.IsEnabled = true;
            TextBoxRaza.IsEnabled = true;
            TextBoxDescripcion.IsEnabled = true;
            TextBoxEstado.IsEnabled = true;
            btnImagenPerro.IsEnabled = true;
            BtnPdrino.IsEnabled = true;
            btnEditCancelar.Visibility = Visibility.Visible;
            btnEditConfirmar.Visibility = Visibility.Visible;
            btnEditPerro.Visibility = Visibility.Hidden;
            btnDeletePerro.Visibility = Visibility.Hidden;
            btnAnteriorPerro.Visibility = Visibility.Hidden;
            btnNextPerro.Visibility = Visibility.Hidden;
            btnImagenPerro.Visibility = Visibility.Visible;
            NuevoPerro.Visibility = Visibility.Hidden;
            ListViewPerros.IsEnabled = false;

            //Perro perro = (Perro)ListViewPerros.Items[ListViewPerros.SelectedIndex];
            //ClasePadrinoPerro winPadrino = new ClasePadrinoPerro(this, perro, true);

            /*
            winPadrino.BtnAceptarCambios.Visibility = Visibility.Visible;
            winPadrino.BtnAceptarCambios.IsEnabled = true;
            winPadrino.txtNombrePadrino.IsEnabled = true;
            winPadrino.txtDniPadrino.IsEnabled = true;
            winPadrino.txtCorreoPadrino.IsEnabled = true;
            winPadrino.txtTelefonoPadrino.IsEnabled = true;
            winPadrino.txtDatosBanPadrino.IsEnabled = true;
            winPadrino.txtImportePadrino.IsEnabled = true;
            winPadrino.txtPagoPadrino.IsEnabled = true;
            winPadrino.txtComienzoPadrino.IsEnabled = true;*/
        }

        private void BtnDeletePerro_Click(object sender, RoutedEventArgs e)
        {
            int index = ListViewPerros.SelectedIndex;
            string message = "¿Estas seguro que quieres eliminar el perro seleccionado?";
            string caption = "Eliminación de perro";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            DialogResult result;

            // Displays the MessageBox.
            result = (DialogResult)MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                // Closes the parent form.
                //System.Windows.Forms.ListViewItem item = (System.Windows.Forms.ListViewItem)ListViewPerros.Items[ListViewPerros.SelectedIndex];
                Perro perro = (Perro)ListViewPerros.Items[ListViewPerros.SelectedIndex];

                //int idperro = item.SubItems[0].Text;
                //int cosa= ListViewPerros.ListViewSubItem();

                //Perro perro = new Perro();
                //string idper = TextBoxId.Text;
                //int idperro = Int32.Parse(TextBoxId.Text);

                //perro.Id = idperro;
                GestorAnimal.eliminarPerro(perro);
                ListViewPerros.Items.RemoveAt(index);
                TextBoxId.Text = "";
                TextBoxSexo.Text = "";
                TextBoxNombre.Text = "";
                TextBoxTamanio.Text = "";
                TextBoxEstado.Text = "";
                TextBoxPeso.Text = "";
                TextBoxEdad.Text = "";
                TextBoxEntrada.Text = "";
                TextBoxDescripcion.Text = "";
                TextBoxRaza.Text = "";
                //@"../fotosPerros/default.jpg"
                string str = @"../fotosPerros/default.jpg";
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(str, UriKind.Relative);
                bitmap.EndInit();
                ProfileImage.Source = bitmap;
            }
            //SetPerro(ListViewPerros.Items.IndexOf;



        }

        private void BtnImagenPerro_Click(object sender, RoutedEventArgs e)
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
                ProfileImage.Source = bitmap;

            }
            catch (Exception ex)
            {
                if (ex.Message != "URI no válido: URI está vacío.") {
                    MessageBox.Show("Error al cargar la imagen " + ex.Message);
                }
            }

            
        }

        private void btnEditCancelar_Click(object sender, RoutedEventArgs e)
        {
            Perro perro = (Perro)ListViewPerros.Items[ListViewPerros.SelectedIndex];
            SetPerro(perro);
            TextBoxEdad.Foreground = Brushes.Black;
            TextBoxPeso.Foreground = Brushes.Black;
            TextBoxTamanio.Foreground = Brushes.Black;
            DesactivarTextBoxs();
        }

        private void btnEditConfirmar_Click(object sender, RoutedEventArgs e)
        {
            Perro perro = (Perro)ListViewPerros.Items[ListViewPerros.SelectedIndex];

            try
            {
                perro.Sexo = TextBoxSexo.Text;
                perro.Nombre = TextBoxNombre.Text;
                perro.Tamanio = Int32.Parse(TextBoxTamanio.Text);
                perro.Estado = TextBoxEstado.Text;
                perro.Peso = Int32.Parse(TextBoxPeso.Text);
                perro.Edad = Int32.Parse(TextBoxEdad.Text);
                perro.FechaEntrada = DateTime.Parse(TextBoxEntrada.Text);
                perro.Descripcion = TextBoxDescripcion.Text;
                perro.Raza = TextBoxRaza.Text;

                string s = ProfileImage.Source.ToString();
                string[] subs = s.Split('/');
                perro.Foto = subs[subs.Length - 1];

                GestorAnimal.modificarPerro(perro);
                DesactivarTextBoxs();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                ComprobarEntradaInt(TextBoxEdad.Text, TextBoxEdad);
                ComprobarEntradaInt(TextBoxPeso.Text, TextBoxPeso);
                ComprobarEntradaInt(TextBoxTamanio.Text, TextBoxTamanio);

                //List<String> fila;
            }
            
            //Refresh();
        }

        private void DesactivarTextBoxs()
        {
            TextBoxId.IsEnabled = false;
            TextBoxNombre.IsEnabled = false;
            TextBoxSexo.IsEnabled = false;
            TextBoxPeso.IsEnabled = false;
            TextBoxEdad.IsEnabled = false;
            TextBoxTamanio.IsEnabled = false;
            TextBoxEntrada.IsEnabled = false;
            TextBoxRaza.IsEnabled = false;
            TextBoxDescripcion.IsEnabled = false;
            TextBoxEstado.IsEnabled = false;
            btnImagenPerro.IsEnabled = false;
            btnEditPerro.Visibility = Visibility.Visible;
            btnDeletePerro.Visibility = Visibility.Visible;
            btnAnteriorPerro.Visibility = Visibility.Visible;
            btnNextPerro.Visibility = Visibility.Visible;
            NuevoPerro.Visibility = Visibility.Visible;
            btnEditCancelar.Visibility = Visibility.Hidden;
            btnEditConfirmar.Visibility = Visibility.Hidden;
            ListViewPerros.IsEnabled = true;
        }

        //ESTO ESTA PUESTO PROVISIONALMENTE
        private void btnBuscarPerro_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBoxBuscar.Text))
            {
                ListViewPerros.Items.Clear();
                foreach (Perro perro in listaPerro)
                {
                    if (perro.Nombre.ToLower().Contains(TextBoxBuscar.Text.ToLower()))
                    {
                        ListViewPerros.Items.Add(perro);
                    }

                }
            }
            else
            {
                //Refresh();
            }

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

        private void PulsarEdad(object sender, RoutedEventArgs e)
        {
            TextBoxEdad.Foreground = Brushes.Black;
        }

        private void PulsarTamanio(object sender, RoutedEventArgs e)
        {
            TextBoxTamanio.Foreground = Brushes.Black;
        }

        private void PulsarPeso(object sender, RoutedEventArgs e)
        {
            TextBoxPeso.Foreground = Brushes.Black;
        }

    }


}
