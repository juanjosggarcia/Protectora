﻿using Protectora.Dominio;
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
            Refresh();
        }
        public List<Perro> idAccess
        {
            get { return listaPerro; }
            
        }

        private void BtnPdrino_Click(object sender, RoutedEventArgs e)
        {
            ClasePadrinoPerro Padrinito = new ClasePadrinoPerro();
            Padrinito.Show();
        }

        private void ClickNuevoPerro(object sender, RoutedEventArgs e)
        {
            ClaseAniadirPerro nuevoPerro = new ClaseAniadirPerro(this);
            nuevoPerro.Show();

            //Algoperro();
            Refresh();
        }

        private void ListaPerros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItems = ListViewPerros.SelectedItems;
            foreach (Perro perro in selectedItems)
            {
                SetPerro(perro);
                DesactivarTextBoxs();

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
                string str = @"C:\Users\laura\source\repos\Protectora\recursos\Fotosbd\" + perro.Foto;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(str);
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

            //Window per = new GestionPerro();
            //GestionPerro pero = (GestionPerro)per;
            //Window pae = pero.ventanas[0];

            //Page2 jdf = (Page2)pero.paneles[0];

            //string st = jdf.putamierda;

            foreach (Perro perro in perros)
            {
                if (string.IsNullOrEmpty(perro.Foto))
                {
                    perro.Foto = "C:\\Users\\laura\\source\\repos\\Protectora\\recursos\\default.png";
                }

                listaPerro.Add(perro);

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
        }

        public void CrearPerro(Perro perro)
        {
            listaPerro.Add(perro);
            Refresh();
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
            btnEditCancelar.Visibility = Visibility.Visible;
            btnEditConfirmar.Visibility = Visibility.Visible;
            btnEditPerro.Visibility = Visibility.Hidden;
            btnDeletePerro.Visibility = Visibility.Hidden;
            btnAnteriorPerro.Visibility = Visibility.Hidden;
            btnNextPerro.Visibility = Visibility.Hidden;
            btnImagenPerro.Visibility = Visibility.Visible;

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
                ListViewPerros.Items.RemoveAt(index);
            }
            //SetPerro(ListViewPerros.Items.IndexOf;
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
            string str = @"C:\Users\laura\source\repos\Protectora\recursos\default.png";
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(str);
            bitmap.EndInit();
            ProfileImage.Source = bitmap;


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
            btnEditPerro.Visibility = Visibility.Visible;
            btnDeletePerro.Visibility = Visibility.Visible;
            btnAnteriorPerro.Visibility = Visibility.Visible;
            btnNextPerro.Visibility = Visibility.Visible;
            btnEditCancelar.Visibility = Visibility.Hidden;
            btnEditConfirmar.Visibility = Visibility.Hidden;
            DesactivarTextBoxs();
        }

        private void btnEditConfirmar_Click(object sender, RoutedEventArgs e)
        {
            btnEditPerro.Visibility = Visibility.Visible;
            btnDeletePerro.Visibility = Visibility.Visible;
            btnAnteriorPerro.Visibility = Visibility.Visible;
            btnNextPerro.Visibility = Visibility.Visible;
            btnEditCancelar.Visibility = Visibility.Hidden;
            btnEditConfirmar.Visibility = Visibility.Hidden;
            DesactivarTextBoxs();
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
                Refresh();
            }

        }

    }


}
