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
using Microsoft.Win32;
using Protectora.Dominio;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using Path = System.IO.Path;
using TextBox = System.Windows.Controls.TextBox;

namespace Protectora.Presentacion
{
    public partial class PaginaVoluntarios : Page
    {
        //public List<Voluntario> listaVoluntario = new List<Voluntario>();
        public PaginaVoluntarios()
        {
            InitializeComponent();
            CargarVoluntarios();
        }
        private void ListaVoluntarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItems = ListViewVoluntarios.SelectedItems;
            foreach (Voluntario voluntario in selectedItems)
            {
                SetVoluntario(voluntario);
                DesactivarTextBoxsVol();
            }

            btnAnteriorVoluntario.IsEnabled = true;
            btnNextVoluntario.IsEnabled = true;
            btnEditVoluntario.IsEnabled = true;
            btnDeleteVoluntario.IsEnabled = true;
        }

        ///////////////////////////////////////////////////////////////// EVENTOS DE BOTON /////////////////////////////////////////////////////////////////

        private void ClickNuevoVoluntario(object sender, RoutedEventArgs e)
        {
            ClaseAniadirVoluntario nuevoVoluntario = new ClaseAniadirVoluntario(this);
            nuevoVoluntario.Show();
        }
        private void BtnDeleteVoluntario_Click(object sender, RoutedEventArgs e)
        {
            int index = ListViewVoluntarios.SelectedIndex;
            string message = "¿Estas seguro que quieres eliminar el voluntario seleccionado?";
            string caption = "Eliminación de voluntario";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            DialogResult result;

            result = (DialogResult)MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    Voluntario voluntario = (Voluntario)ListViewVoluntarios.Items[ListViewVoluntarios.SelectedIndex];

                    GestorPersona.eliminarVoluntario(voluntario);
                    ListViewVoluntarios.Items.RemoveAt(index);
                    TextBoxIdVol.Text = "";
                    TextBoxNombreVol.Text = "";
                    TextBoxCorreoVol.Text = "";
                    TextBoxDNIVol.Text = "";
                    TextBoxTelefonoVol.Text = "";
                    TextBoxZonaVol.Text = "";
                    TextBoxHorarioVol.Text = "";
                    btnImagenVol.IsEnabled = true;
                    string str = @"../fotosPersona/default.jpg";
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(str, UriKind.Relative);
                    bitmap.EndInit();
                    ProfileImageVoluntario.Source = bitmap;
                }
                catch (Exception ex)
                {
                    ELog.save(this, ex);
                }
            }
        }
        private void BtnEditVoluntario_Click(object sender, RoutedEventArgs e)
        {
            TextBoxIdVol.IsEnabled = true;
            TextBoxNombreVol.IsEnabled = true;
            TextBoxCorreoVol.IsEnabled = true;
            TextBoxDNIVol.IsEnabled = true;
            TextBoxTelefonoVol.IsEnabled = true;
            TextBoxZonaVol.IsEnabled = true;
            TextBoxHorarioVol.IsEnabled = true;
            btnImagenVol.IsEnabled = true;

            btnEditCancelarVoluntario.Visibility = Visibility.Visible;
            btnEditConfirmarVoluntario.Visibility = Visibility.Visible;
            btnEditVoluntario.Visibility = Visibility.Hidden;
            btnDeleteVoluntario.Visibility = Visibility.Hidden;
            btnAnteriorVoluntario.Visibility = Visibility.Hidden;
            btnNextVoluntario.Visibility = Visibility.Hidden;
            btnImagenVol.Visibility = Visibility.Visible;

            NuevoVoluntario.Visibility = Visibility.Hidden;
            ListViewVoluntarios.IsEnabled = false;

        }
        private void btnEditConfirmarVoluntario_Click(object sender, RoutedEventArgs e)
        {
            Voluntario voluntario = (Voluntario)ListViewVoluntarios.Items[ListViewVoluntarios.SelectedIndex];

            try
            {
                int index = ListViewVoluntarios.SelectedIndex;
                voluntario.NombreCompleto = TextBoxNombreVol.Text;
                voluntario.Dni = TextBoxDNIVol.Text;
                voluntario.Correo = TextBoxCorreoVol.Text;
                voluntario.Telefono = Int32.Parse(TextBoxTelefonoVol.Text);
                voluntario.Horario = TextBoxHorarioVol.Text;
                voluntario.ZonaDisponibilidad = TextBoxZonaVol.Text;

                voluntario.Foto = copiarImagen(ProfileImageVoluntario.Source.ToString());

                GestorPersona.modificarVoluntario(voluntario);
                CargarVoluntarios();
                DesactivarTextBoxsVol();
                ListViewVoluntarios.SelectedItem = ListViewVoluntarios.Items[index];

            }
            catch (FormatException ex)
            {
                Console.Write(ex);
                ComprobarEntradaInt(TextBoxTelefonoVol.Text, TextBoxTelefonoVol, errorTelefono);
            }
            catch (Exception ex)
            {
                ELog.save(this, ex);
            }
        }
        private void btnEditCancelarVoluntario_Click(object sender, RoutedEventArgs e)
        {
            Voluntario voluntario = (Voluntario)ListViewVoluntarios.Items[ListViewVoluntarios.SelectedIndex];
            SetVoluntario(voluntario);
            TextBoxTelefonoVol.Foreground = Brushes.Black;
            DesactivarTextBoxsVol();

        }

        private void btnBuscarVoluntario_Click(object sender, RoutedEventArgs e)
        {
            Voluntario voluntario = new Voluntario();
            try
            {
                if (!string.IsNullOrEmpty(TextBoxBuscarVoluntario.Text))
                {
                    voluntario.NombreCompleto = TextBoxBuscarVoluntario.Text;
                    List<Voluntario> voluntarios = GestorPersona.obtenerVoluntarioName(voluntario);
                    ListViewVoluntarios.Items.Clear();
                    if (voluntario != null)
                    {
                        foreach (Voluntario voluntari in voluntarios)
                        {
                            voluntari.Foto = "default.jpg";
                            ListViewVoluntarios.Items.Add(voluntari);
                        }
                    }
                }
                else
                {
                    CargarVoluntarios();
                }
            }
            catch (Exception ex)
            {
                ELog.save(this, ex);
            }
        }

        private void btnMostrarTodosVoluntario_Click(object sender, RoutedEventArgs e)
        {
            CargarVoluntarios();
        }
        private void BtnNextVoluntario_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewVoluntarios.SelectedIndex != ListViewVoluntarios.Items.Count - 1)
            {
                ListViewVoluntarios.SelectedIndex++;
            }
        }
        private void BtnAnteriorVoluntario_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewVoluntarios.SelectedIndex != 0)
            {
                ListViewVoluntarios.SelectedIndex--;
            }
        }

        //////////////////////////////////////////////////////////////// EVENTOS AUXILIARES ////////////////////////////////////////////////////////////////

        private void BtnImagenVoluntario_Click(object sender, RoutedEventArgs e)
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
                ProfileImageVoluntario.Source = bitmap;

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
            TextBoxTelefonoVol.Foreground = Brushes.Black;
            errorTelefono.Visibility = Visibility.Hidden;
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btnBuscarVoluntario_Click(sender, e);
            }
        }


        /////////////////////////////////////////////////////////////// FUNCIONES AUXILIARES ///////////////////////////////////////////////////////////////

        public void CargarVoluntarios()
        {
            try
            {
                List<Voluntario> voluntarios = GestorPersona.obtenerTodosVoluntarios();
                ListViewVoluntarios.Items.Clear();
                foreach (Voluntario voluntario in voluntarios)
                {
                    if (string.IsNullOrEmpty(voluntario.Foto))
                    {
                        voluntario.Foto = "default.jpg";
                    }
                    ListViewVoluntarios.Items.Add(voluntario);
                }
            }
            catch (Exception ex)
            {
                ELog.save(this, ex);
            }
        }
        public void SetVoluntario(Voluntario voluntario)
        {
            try
            {
                TextBoxIdVol.Text = voluntario.Id.ToString();
                TextBoxNombreVol.Text = voluntario.NombreCompleto;
                TextBoxCorreoVol.Text = voluntario.Correo;
                TextBoxDNIVol.Text = voluntario.Dni;
                TextBoxTelefonoVol.Text = voluntario.Telefono.ToString();
                TextBoxZonaVol.Text = voluntario.ZonaDisponibilidad;
                TextBoxHorarioVol.Text = voluntario.Horario;

                string rutaPersonas = obtenerPath() + "/fotosPersonas";
                string[] picListTXT = Directory.GetFiles(rutaPersonas, "*.jpg");
                string[] picListPNG = Directory.GetFiles(rutaPersonas, "*.png");
                string[] picList = picListTXT.Concat(picListPNG).ToArray();

                if (!(picList.Contains(rutaPersonas + "\\" + voluntario.Foto)))
                {
                    voluntario.Foto = "default.jpg";
                }

                string str = rutaPersonas + "/" + voluntario.Foto;

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(str);
                //bitmap.UriSource = new Uri(str, UriKind.Relative);
                bitmap.EndInit();
                ProfileImageVoluntario.Source = bitmap;

            }
            catch (Exception ex)
            {
                ELog.save(this, ex);
            }
        }
        private void DesactivarTextBoxsVol()
        {
            TextBoxIdVol.IsEnabled = false;
            TextBoxNombreVol.IsEnabled = false;
            TextBoxCorreoVol.IsEnabled = false;
            TextBoxDNIVol.IsEnabled = false;
            TextBoxTelefonoVol.IsEnabled = false;
            TextBoxZonaVol.IsEnabled = false;
            TextBoxHorarioVol.IsEnabled = false;
            btnImagenVol.IsEnabled = false;

            btnAnteriorVoluntario.Visibility = Visibility;
            btnNextVoluntario.Visibility = Visibility;
            btnEditVoluntario.Visibility = Visibility;
            btnDeleteVoluntario.Visibility = Visibility;

            NuevoVoluntario.Visibility = Visibility.Visible;
            btnEditCancelarVoluntario.Visibility = Visibility.Hidden;
            btnEditConfirmarVoluntario.Visibility = Visibility.Hidden;
            ListViewVoluntarios.IsEnabled = true;
        }
        private string obtenerPath()
        {
            string pathExe = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            string pathApp1 = pathExe.Substring(8);
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

            string backupDir = pathApp + "/fotosPersonas";

            string[] picListTXT = Directory.GetFiles(backupDir, "*.jpg");
            string[] picListPNG = Directory.GetFiles(backupDir, "*.png");
            string[] picListGIF = Directory.GetFiles(backupDir, "*.gif");
            string[] picListBMP = Directory.GetFiles(backupDir, "*.bmp");
            string[] picList1 = picListTXT.Concat(picListPNG).ToArray();
            string[] picList2 = picList1.Concat(picListGIF).ToArray();
            string[] picList = picList2.Concat(picListBMP).ToArray();

            if (!(picList.Contains(backupDir + "\\" + fName)))
            {
                try
                {
                    File.Copy(Path.Combine(sourceDir, fName), Path.Combine(backupDir, fName), true);
                }
                catch (DirectoryNotFoundException ex)
                {
                    ELog.save(this, ex);
                }
            }
            return fName;
        }
    }
}
