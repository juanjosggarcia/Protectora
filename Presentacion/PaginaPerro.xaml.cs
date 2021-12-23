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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Protectora.Presentacion
{
    /// <summary>
    /// Lógica de interacción para PaginaPerro.xaml
    /// </summary>
    public partial class PaginaPerro : Page
    {
        //Dominio.Perro perro;

        public List<Perro> listaPerro = new List<Perro>();
        public int numero = 2;
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
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(perro.Foto);
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

                perro.Foto = "";
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
            //listaPerro.Add(perro);
            //Dominio.Perro perrito = new Dominio.Perro();
            //perrito.Id = 2;
            //perrito.Nombre = "pili";
            //perrito.Sexo = "fem";
            //perrito.Tamanio = 10;
            //perrito.Estado = "sana";
            //perrito.Peso = 55;
            //perrito.Edad = 2;
            //perrito.Entrada = new DateTime(1998, 04, 30);
            //perrito.Descripcion = "perro calmado";
            GestorAnimal.crearPerro(perro);
            listaPerro.Add(perro);

            Refresh();
        }

        private void btnNextPerro_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewPerros.SelectedIndex != ListViewPerros.Items.Count - 1)
            {
                ListViewPerros.SelectedIndex = ListViewPerros.SelectedIndex + 1;
            }
        }

        private void btnAnteriorPerro_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewPerros.SelectedIndex != 0)
            {
                ListViewPerros.SelectedIndex = ListViewPerros.SelectedIndex - 1;
            }
        }

        private void btnEditPerro_Click(object sender, RoutedEventArgs e)
        {
            ClaseEditarPerro editarPerro = new ClaseEditarPerro();
            editarPerro.Show();

        }
    }


}
