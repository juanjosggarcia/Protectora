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
using Path = System.IO.Path;

namespace Protectora.Presentacion
{
    /// <summary>
    /// Lógica de interacción para PaginaAvisos.xaml
    /// </summary>
    public partial class PaginaAvisos : Page
    {
        public List<Aviso> listaAvisos = new List<Aviso>();
        public PaginaAvisos()
        {
            InitializeComponent();
            CargarPerrosPerdidos();
        }

        private void ListaPerrosPerdidos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItems = ListViewPerrosPerdidos.SelectedItems;
            foreach (Aviso aviso in selectedItems)
            {
                SetPerroPerdido(aviso);
                DesactivarTextBoxsPerdido();

            }

            btnAnteriorPerroPerdido.IsEnabled = true;
            btnNextPerroPerdido.IsEnabled = true;
            btnEditPerroPerdido.IsEnabled = true;
            btnDeletePerroPerdido.IsEnabled = true;
        }

        ///////////////////////////////////////////////////////////////// EVENTOS DE BOTON /////////////////////////////////////////////////////////////////


        private void BtnDuenio_Click(object sender, RoutedEventArgs e)
        {
            Aviso aviso = (Aviso)ListViewPerrosPerdidos.Items[ListViewPerrosPerdidos.SelectedIndex];
            ClaseDuenio winDuenio;

            if ((bool)ListViewPerrosPerdidos.IsEnabled == false)
            {
                winDuenio = new ClaseDuenio(this, aviso, true);
            }
            else
            {
                winDuenio = new ClaseDuenio(this, aviso, false);
            }
            winDuenio.Show();
        }

        private void ClickNuevoPerroPerdido(object sender, RoutedEventArgs e)
        {
            ClaseAniadirPerroPerdido nuevoPerroPerdido = new ClaseAniadirPerroPerdido(this);
            nuevoPerroPerdido.Show();

        }
        private void BtnDeletePerroPerdido_Click(object sender, RoutedEventArgs e)
        {
            int index = ListViewPerrosPerdidos.SelectedIndex;
            string message = "¿Estas seguro que quieres eliminar el aviso seleccionado?";
            string caption = "Eliminación de aviso";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            DialogResult result;

            result = (DialogResult)System.Windows.MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Aviso aviso = (Aviso)ListViewPerrosPerdidos.Items[ListViewPerrosPerdidos.SelectedIndex];
                GestorAnimal.eliminarAviso(aviso);
                ListViewPerrosPerdidos.Items.RemoveAt(index);
                TextBoxIdPerroPer.Text = "";
                TextBoxSexoPerdido.Text = "";
                TextBoxNombrePerdido.Text = "";
                TextBoxTamanioPerdido.Text = "";
                TextBoxRazaPerdido.Text = "";
                TextBoxZonaPerdida.Text = "";
                TextBoxFechaPerdida.Text = "";
                TextBoxDescripcionPerdida.Text = "";
                TextBoxDescripcionAdicional.Text = "";
                string str = @"../fotosPerros/default.jpg";
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(str, UriKind.Relative);
                bitmap.EndInit();
                ProfileImagePerroPerdido.Source = bitmap;
            }
        }
        private void BtnEditPerroPerdido_Click(object sender, RoutedEventArgs e)
        {
            BtnDuenio.ToolTip = "Editar los datos del dueño del perro perdido";
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
        private void btnEditConfirmarPerroPerdido_Click(object sender, RoutedEventArgs e)
        {
            Aviso aviso = (Aviso)ListViewPerrosPerdidos.Items[ListViewPerrosPerdidos.SelectedIndex];

            try
            {
                int index = ListViewPerrosPerdidos.SelectedIndex;
                aviso.Nombre = TextBoxNombrePerdido.Text;
                aviso.Sexo = TextBoxSexoPerdido.Text;
                aviso.Tamanio = Int32.Parse(TextBoxTamanioPerdido.Text);
                aviso.Raza = TextBoxRazaPerdido.Text;
                aviso.FechaPerdida = DateTime.Parse(TextBoxFechaPerdida.Text);
                aviso.ZonaPerdida = TextBoxZonaPerdida.Text;
                aviso.DescripcionAnimal = TextBoxDescripcionPerdida.Text;
                aviso.DescripcionAdicional = TextBoxDescripcionAdicional.Text;

                //string s = ProfileImagePerroPerdido.Source.ToString();
                //string[] subs = s.Split('/');
                //aviso.Foto = subs[subs.Length - 1];

                aviso.Foto = copiarImagen(ProfileImagePerroPerdido.Source.ToString());

                GestorAnimal.modificarAviso(aviso);
                CargarPerrosPerdidos();
                DesactivarTextBoxsPerdido();
                BtnDuenio.ToolTip = "Datos del dueño del perro perdido";
                ListViewPerrosPerdidos.SelectedItem = ListViewPerrosPerdidos.Items[index];

            }
            catch (Exception ex)
            {
                Console.Write(ex);
                ELog.save(this, ex);
            }
        }
        private void btnEditCancelarPerroPerdido_Click(object sender, RoutedEventArgs e)
        {
            Aviso aviso = (Aviso)ListViewPerrosPerdidos.Items[ListViewPerrosPerdidos.SelectedIndex];
            string message = "¿Estas seguro que quieres cacelar la edición? Se perderan todos los cambios no guardados";
            string caption = "Cancelar cambios";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            DialogResult result;

            // Displays the MessageBox.
            result = (DialogResult)System.Windows.MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                SetPerroPerdido(aviso);
                BtnDuenio.ToolTip = "Datos del dueño del perro perdido";
                DesactivarTextBoxsPerdido();
                ListViewPerrosPerdidos.SelectedItem = ListViewPerrosPerdidos.Items[ListViewPerrosPerdidos.SelectedIndex];
            }
        }
        private void btnBuscarPerroPerdido_Click(object sender, RoutedEventArgs e)
        {
            Aviso aviso = new Aviso();

            if (!string.IsNullOrEmpty(TextBoxBuscarPerroPerdido.Text))
            {
                aviso.Nombre = TextBoxBuscarPerroPerdido.Text;
                List<Aviso> avisos = GestorAnimal.obtenerAviso(aviso);
                ListViewPerrosPerdidos.Items.Clear();
                if (avisos != null)
                {
                    foreach (Aviso avis in avisos)
                    {
                        avis.Foto = "default.jpg";
                        ListViewPerrosPerdidos.Items.Add(avis);
                    }
                }
            }
            else
            {
                CargarPerrosPerdidos();
            }
        }
        private void btnMostrarTodosAvisos_Click(object sender, RoutedEventArgs e)
        {
            CargarPerrosPerdidos();
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

        //////////////////////////////////////////////////////////////// EVENTOS AUXILIARES ////////////////////////////////////////////////////////////////

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

        /////////////////////////////////////////////////////////////// FUNCIONES AUXILIARES ///////////////////////////////////////////////////////////////

        public void CargarPerrosPerdidos()
        {
            List<Aviso> avisos = new List<Aviso>();
            avisos = GestorAnimal.obtenerTodosAvisos();
            ListViewPerrosPerdidos.Items.Clear();
            foreach (Aviso aviso in avisos)
            {
                if (string.IsNullOrEmpty(aviso.Foto))
                {
                    aviso.Foto = "default.jpg";
                }

                listaAvisos.Add(aviso);
                ListViewPerrosPerdidos.Items.Add(aviso);
            }
        }
        public void SetPerroPerdido(Aviso aviso)
        {
            try
            {
                TextBoxIdPerroPer.Text = aviso.Id.ToString();
                TextBoxNombrePerdido.Text = aviso.Nombre;
                TextBoxSexoPerdido.Text = aviso.Sexo;
                TextBoxTamanioPerdido.Text = aviso.Tamanio.ToString();
                TextBoxRazaPerdido.Text = aviso.Raza;
                TextBoxFechaPerdida.Text = aviso.FechaPerdida.ToString();
                TextBoxZonaPerdida.Text = aviso.ZonaPerdida;
                TextBoxDescripcionPerdida.Text = aviso.DescripcionAnimal;
                TextBoxDescripcionAdicional.Text = aviso.DescripcionAdicional;

                string rutaPerros = obtenerPath() + "/fotosPerros";
                string[] picList = Directory.GetFiles(rutaPerros, "*.jpg");

                if (!(picList.Contains(rutaPerros + "\\" + aviso.Foto)))
                {
                    aviso.Foto = "default.jpg";
                }

                string str = rutaPerros + "/" + aviso.Foto;

                //string str = @"../fotosPerros/" + aviso.Foto;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                //bitmap.UriSource = new Uri(str, UriKind.Relative);
                bitmap.UriSource = new Uri(str);
                bitmap.EndInit();
                ProfileImagePerroPerdido.Source = bitmap;


            }
            catch (Exception ex)
            {
                Console.Write(ex);
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
        private string obtenerPath()
        {
            string pathExe = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            string pathApp1 = pathExe.Substring(8);
            //int posBin = pathApp1.IndexOf("/bin");
            string proc = "/Protectora/";
            int posBin = pathApp1.IndexOf(proc);
            string pathApp = pathApp1.Remove(posBin + proc.Length);
            return pathApp;
        }
        private string copiarImagen(string sourcePath)
        {
            string[] subs = sourcePath.Split('/');
            string fName = subs[subs.Length - 1];

            int tam = 8;
            string sourceDir1 = sourcePath.Substring(tam);
            string sourceDir = sourceDir1.Substring(0, (sourceDir1.Length - fName.Length - 1));

            string pathApp = obtenerPath();

            string backupDir = pathApp + "/fotosPerros";

            string[] picList = Directory.GetFiles(backupDir, "*.jpg");

            if (!(picList.Contains(backupDir + "\\" + fName)))
            {
                try
                {
                    File.Copy(Path.Combine(sourceDir, fName), Path.Combine(backupDir, fName), true);
                }
                catch (DirectoryNotFoundException dirNotFound)
                {
                    Console.WriteLine(dirNotFound.Message);
                }
            }
            return fName;
        }

        private void OnKeyDownHandler(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btnBuscarPerroPerdido_Click(sender, e);
            }
        }


        private void PulsarFecha(object sender, RoutedEventArgs e)
        {
            TextBoxFechaPerdida.Foreground = Brushes.Black;
        }
        private void PulsarTamanio(object sender, RoutedEventArgs e)
        {
            TextBoxTamanioPerdido.Foreground = Brushes.Black;
        }
    }
}
