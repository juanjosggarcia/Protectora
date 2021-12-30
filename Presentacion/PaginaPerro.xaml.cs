using Protectora.Dominio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
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
    public partial class PaginaPerro : Page
    {
        public PaginaPerro()
        {
            InitializeComponent();
            CargarPerros();
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

        ///////////////////////////////////////////////////////////////// EVENTOS DE BOTON /////////////////////////////////////////////////////////////////


        private void BtnPdrino_Click(object sender, RoutedEventArgs e)
        {
            Perro perro = (Perro)ListViewPerros.Items[ListViewPerros.SelectedIndex];

            ClasePadrinoPerro winPadrino;
            if ((bool)ListViewPerros.IsEnabled == false)
            {
                winPadrino = new ClasePadrinoPerro(this, perro, true);
            }
            else
            {
                winPadrino = new ClasePadrinoPerro(this, perro, false);
            }
            winPadrino.Show();
        }

        private void ClickNuevoPerro(object sender, RoutedEventArgs e)
        {
            ClaseAniadirPerro nuevoPerro = new ClaseAniadirPerro(this);
            nuevoPerro.Show();
        }
        private void BtnDeletePerro_Click(object sender, RoutedEventArgs e)
        {
            int index = ListViewPerros.SelectedIndex;
            string message = "¿Estas seguro que quieres eliminar el perro seleccionado?";
            string caption = "Eliminación de perro";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            DialogResult result;

            result = (DialogResult)MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    Perro perro = (Perro)ListViewPerros.Items[ListViewPerros.SelectedIndex];
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

                    BitmapImage bmi = new BitmapImage(new Uri("pack://application:,,,/recursos/default.png"));
                    ProfileImage.Source = bmi;

                    btnEditPerro.IsEnabled = false;
                    btnDeletePerro.IsEnabled = false;
                    btnNextPerro.IsEnabled = false;
                    btnAnteriorPerro.IsEnabled = false;
                }
                catch (Exception ex)
                {
                    ELog.save(this, ex);
                }
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
            BtnPdrino.ToolTip = "Editar los datos del padrino del perro";
        }
        private void btnEditConfirmar_Click(object sender, RoutedEventArgs e)
        {
            Perro perro = (Perro)ListViewPerros.Items[ListViewPerros.SelectedIndex];

            try
            {
                int index = ListViewPerros.SelectedIndex;
                perro.Sexo = TextBoxSexo.Text;
                perro.Nombre = TextBoxNombre.Text;
                perro.Tamanio = Int32.Parse(TextBoxTamanio.Text);
                perro.Estado = TextBoxEstado.Text;
                perro.Peso = Int32.Parse(TextBoxPeso.Text);
                perro.Edad = Int32.Parse(TextBoxEdad.Text);
                perro.FechaEntrada = DateTime.Parse(TextBoxEntrada.Text);
                perro.Descripcion = TextBoxDescripcion.Text;
                perro.Raza = TextBoxRaza.Text;

                perro.Foto = Modulos.copiarImagen(ProfileImage.Source.ToString(), "perro");

                GestorAnimal.modificarPerro(perro);
                CargarPerros();
                DesactivarTextBoxs();
                BtnPdrino.ToolTip = "Datos del padrino del perro";
                ListViewPerros.SelectedItem = ListViewPerros.Items[index];

            }
            catch (FormatException ex)
            {
                Console.Write(ex);
                ComprobarEntradaInt(TextBoxEdad.Text, TextBoxEdad, errorEdad);
                ComprobarEntradaInt(TextBoxPeso.Text, TextBoxPeso, errorPeso);
                ComprobarEntradaInt(TextBoxTamanio.Text, TextBoxTamanio, errorTamanio);
                ComprobarEntradaFecha(TextBoxEntrada.Text, TextBoxEntrada, errorFecha);
            }
            catch (Exception ex)
            {
                ELog.save(this, ex);
            }
        }
        private void btnEditCancelar_Click(object sender, RoutedEventArgs e)
        {
            int index = ListViewPerros.SelectedIndex;
            string message = "¿Estas seguro que quieres cacelar la edición? Se perderan todos los cambios no guardados";
            string caption = "Cancelar cambios";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            DialogResult result;

            result = (DialogResult)MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Perro perro = (Perro)ListViewPerros.Items[ListViewPerros.SelectedIndex];
                SetPerro(perro);
                TextBoxEdad.Foreground = Brushes.Black;
                TextBoxPeso.Foreground = Brushes.Black;
                TextBoxTamanio.Foreground = Brushes.Black;
                BtnPdrino.ToolTip = "Datos del padrino del perro";
                DesactivarTextBoxs();
                ListViewPerros.SelectedItem = ListViewPerros.Items[ListViewPerros.SelectedIndex];
            }
        }
        private void btnBuscarPerro_Click(object sender, RoutedEventArgs e)
        {
            Perro perro = new Perro();

            try
            {
                if (!string.IsNullOrEmpty(TextBoxBuscar.Text))
                {
                    perro.Nombre = TextBoxBuscar.Text;
                    List<Perro> perros = GestorAnimal.obtenerPerro(perro);
                    ListViewPerros.Items.Clear();
                    if (perros != null)
                    {
                        foreach (Perro perr in perros)
                        {
                            perr.Foto = "default.jpg";
                            ListViewPerros.Items.Add(perr);
                        }
                    }
                }
                else
                {
                    CargarPerros();
                }
            }
            catch (Exception ex)
            {
                ELog.save(this, ex);
            }
        }
        private void btnMostrarTodosPerro_Click(object sender, RoutedEventArgs e)
        {
            CargarPerros();
        }
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

        //////////////////////////////////////////////////////////////// EVENTOS AUXILIARES ////////////////////////////////////////////////////////////////

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

        private void ComprobarEntradaFecha(string valorIntroducido, TextBox componenteEntrada, Image entradaImagen)
        {
            DateTime num;
            bool cosa = DateTime.TryParse(valorIntroducido, out num);
            if (cosa == false)
            {
                componenteEntrada.Foreground = Brushes.Red;
                componenteEntrada.ToolTip = "El dato introducido debe de ser del tipo fecha dd-mm-aaaa";
                entradaImagen.Visibility = Visibility.Visible;

            }
        }
        private void PulsarEdad(object sender, RoutedEventArgs e)
        {
            TextBoxEdad.Foreground = Brushes.Black;
            errorEdad.Visibility = Visibility.Hidden;


        }
        private void PulsarTamanio(object sender, RoutedEventArgs e)
        {
            TextBoxTamanio.Foreground = Brushes.Black;
            errorTamanio.Visibility = Visibility.Hidden;

        }
        private void PulsarPeso(object sender, RoutedEventArgs e)
        {
            TextBoxPeso.Foreground = Brushes.Black;
            errorPeso.Visibility = Visibility.Hidden;

        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btnBuscarPerro_Click(sender, e);
            }
        }
        private void PulsarFecha(object sender, RoutedEventArgs e)
        {
            TextBoxEntrada.Foreground = Brushes.Black;
            errorFecha.Visibility = Visibility.Hidden;

        }



        /////////////////////////////////////////////////////////////// FUNCIONES AUXILIARES ///////////////////////////////////////////////////////////////

        public void CargarPerros()
        {
            try
            {
                List<Perro> perros = GestorAnimal.obtenerTodosPerros();
                ListViewPerros.Items.Clear();
                foreach (Perro perro in perros)
                {
                    if (string.IsNullOrEmpty(perro.Foto))
                    {
                        perro.Foto = "default.jpg";
                    }

                    ListViewPerros.Items.Add(perro);
                }
            }
            catch (Exception ex)
            {
                ELog.save(this, ex);
            }
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

                string rutaPerros = Path.Combine(Modulos.obtenerPath(), "imagenes\\fotosPerros");

                string dirFoto = Path.Combine(rutaPerros, perro.Foto);
                List<string> picList = Modulos.obtenerImagenesCarpeta(rutaPerros);

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
                ProfileImage.Source = bitmap;

            }
            catch (Exception ex)
            {
                ELog.save(this, ex);
            }

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

    }


}
