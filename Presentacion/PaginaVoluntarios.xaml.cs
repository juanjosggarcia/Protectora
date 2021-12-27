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
using Microsoft.Win32;
using Protectora.Dominio;
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using TextBox = System.Windows.Controls.TextBox;

namespace Protectora.Presentacion
{
    /// <summary>
    /// Lógica de interacción para PaginaVoluntarios.xaml
    /// </summary>
    public partial class PaginaVoluntarios : Page
    {
        public List<Voluntario> listaVoluntario = new List<Voluntario>();
        public PaginaVoluntarios()
        {
            InitializeComponent();
            CargarVoluntarios();
        }
        public void CargarVoluntarios()
        {
            List<Voluntario> voluntarios = GestorPersona.obtenerTodosVoluntarios();
            //socios = GestorPersona.obtenerTodosSocios();
            ListViewVoluntarios.Items.Clear();
            foreach (Voluntario voluntario in voluntarios)
            {
                if (string.IsNullOrEmpty(voluntario.Foto))
                {
                    //perro.Foto = "C:\\Users\\laura\\source\\repos\\Protectora\\recursos\\default.png";
                    voluntario.Foto = "default.jpg";
                }
                listaVoluntario.Add(voluntario);
                ListViewVoluntarios.Items.Add(voluntario);
            }

        }

        private void ClickNuevoVoluntario(object sender, RoutedEventArgs e)
        {
            ClaseAniadirVoluntario nuevoVoluntario = new ClaseAniadirVoluntario(this);
            nuevoVoluntario.Show();
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

        private void BtnDeleteVoluntario_Click(object sender, RoutedEventArgs e)
        {
            int index = ListViewVoluntarios.SelectedIndex;
            string message = "¿Estas seguro que quieres eliminar el voluntario seleccionado?";
            string caption = "Eliminación de voluntario";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            DialogResult result;

            // Displays the MessageBox.
            result = (DialogResult)MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                // Closes the parent form.
                //System.Windows.Forms.ListViewItem item = (System.Windows.Forms.ListViewItem)ListViewPerros.Items[ListViewPerros.SelectedIndex];
                Voluntario voluntario = (Voluntario)ListViewVoluntarios.Items[ListViewVoluntarios.SelectedIndex];

                //int idperro = item.SubItems[0].Text;
                //int cosa= ListViewPerros.ListViewSubItem();

                //Perro perro = new Perro();
                //string idper = TextBoxId.Text;
                //int idperro = Int32.Parse(TextBoxId.Text);

                //perro.Id = idperro;
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
                //@"../fotosPerros/default.jpg"
                string str = @"../fotosPersona/default.jpg";
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(str, UriKind.Relative);
                bitmap.EndInit();
                ProfileImageVoluntario.Source = bitmap;
            }
            //SetPerro(ListViewPerros.Items.IndexOf;

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

        private void btnBuscarVoluntario_Click(object sender, RoutedEventArgs e)
        {
            //AQUI VA BUSCAR VOLUNTARIO
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
            catch (Exception ex)
            {
                if (ex.Message != "URI no válido: URI está vacío.")
                {
                    MessageBox.Show("Error al cargar la imagen " + ex.Message);
                }
            }

        }
        private void btnEditCancelarVoluntario_Click(object sender, RoutedEventArgs e)
        {
            Voluntario voluntario = (Voluntario)ListViewVoluntarios.Items[ListViewVoluntarios.SelectedIndex];
            SetVoluntario(voluntario);
            TextBoxTelefonoVol.Foreground = Brushes.Black;
            DesactivarTextBoxsVol();

        }
        private void btnEditConfirmarVoluntario_Click(object sender, RoutedEventArgs e)
        {
            Voluntario voluntario = (Voluntario)ListViewVoluntarios.Items[ListViewVoluntarios.SelectedIndex];

            try
            {
                voluntario.NombreCompleto = TextBoxNombreVol.Text;
                voluntario.Dni = TextBoxDNIVol.Text;
                voluntario.Correo = TextBoxCorreoVol.Text;
                voluntario.Telefono = Int32.Parse(TextBoxTelefonoVol.Text);
                voluntario.Horario = TextBoxHorarioVol.Text;
                voluntario.ZonaDisponibilidad = TextBoxZonaVol.Text;

                string s = ProfileImageVoluntario.Source.ToString();
                string[] subs = s.Split('/');
                voluntario.Foto = subs[subs.Length - 1];

                GestorPersona.modificarVoluntario(voluntario);
                DesactivarTextBoxsVol();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                ComprobarEntradaInt(TextBoxTelefonoVol.Text, TextBoxTelefonoVol);

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
                
                string str = @"../fotosPersonas/" + voluntario.Foto;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(str, UriKind.Relative);
                bitmap.EndInit();
                ProfileImageVoluntario.Source = bitmap;

            }
            catch (Exception ex)
            {
                Console.Write(ex);
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

            }

        }
        private void PulsarTelefono(object sender, RoutedEventArgs e)
        {
            TextBoxTelefonoVol.Foreground = Brushes.Black;
        }

    }
}
