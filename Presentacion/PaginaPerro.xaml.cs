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

        List<Dominio.Perro> listaPerro = new List<Dominio.Perro>();
        public PaginaPerro()
        {
            InitializeComponent();
        }

        private void BtnPdrino_Click(object sender, RoutedEventArgs e)
        {
            Padrino Padrinito = new Padrino();
            Padrinito.Show();
        }

        private void ClickNuevoPerro(object sender, RoutedEventArgs e)
        {
            BotonAniadir nuevoPerro = new BotonAniadir();
            nuevoPerro.Show();

            Algoperro();
            Refresh();
        }

        private void BtnAniadir_Click(object sender, RoutedEventArgs e)
        {
            //PanelDinamicoBotones.Children.Add(new ControlUsuarioPerro());
            BotonAniadir nuevoPerro = new BotonAniadir();
            nuevoPerro.Show();
        }

        private void ListaPerros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItems = ListViewPerros.SelectedItems;
            foreach (Dominio.Perro perro in selectedItems)
            {
                SetPerro(perro);
            }
        }

        public void SetPerro(Dominio.Perro perro)
        {
            TextBoxId.Text = perro.Id.ToString();
            TextBoxSexo.Text = perro.Sexo;
            TextBoxNombre.Text = perro.Nombre;
            TextBoxTamanio.Text = perro.Tamanio.ToString();
            TextBoxEstado.Text = perro.Estado;
            TextBoxPeso.Text = perro.Peso.ToString();
            TextBoxEdad.Text = perro.Edad.ToString();
            TextBoxEntrada.Text = perro.Entrada.ToString("dd-MM-yyyy");
            TextBoxDescripcion.Text = perro.Descripcion;
        }

        public void Algoperro()
        {
            Dominio.Perro perrito = new Dominio.Perro();
            perrito.Id = 2;
            perrito.Nombre = "mari";
            perrito.Sexo = "fem";
            perrito.Tamanio = 10;
            perrito.Estado = "sana";
            perrito.Peso = 55;
            perrito.Edad = 2;
            perrito.Entrada = new DateTime(1998, 04, 30);
            perrito.Descripcion = "perro calmado";
            listaPerro.Add(perrito);
        }

        private void Refresh()
        {
            ListViewPerros.Items.Clear();
            if (listaPerro != null)
            {
                foreach (Dominio.Perro perro in listaPerro)
                {
                    ListViewPerros.Items.Add(perro);
                }
            }
        }

        public void CrearPerro(Dominio.Perro perro)
        {
            //listaPerro.Add(perro);
            Dominio.Perro perrito = new Dominio.Perro();
            perrito.Id = 2;
            perrito.Nombre = "pili";
            perrito.Sexo = "fem";
            perrito.Tamanio = 10;
            perrito.Estado = "sana";
            perrito.Peso = 55;
            perrito.Edad = 2;
            perrito.Entrada = new DateTime(1998, 04, 30);
            perrito.Descripcion = "perro calmado";
            listaPerro.Add(perrito);
            Refresh();
        }

    }


}
