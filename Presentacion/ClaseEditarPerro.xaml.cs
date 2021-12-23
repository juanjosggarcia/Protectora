using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Protectora.Presentacion
{
    /// <summary>
    /// Lógica de interacción para ClaseEditarPerro.xaml
    /// </summary>
    public partial class ClaseEditarPerro : Window
    {
        PaginaPerro pagPerro;
        Perro perro;
        public ClaseEditarPerro(PaginaPerro p, Perro pe)
        {
            InitializeComponent();
            pagPerro = p;
            perro = pe;
            CargarDatos();
        }
        private void CargarDatos()
        {
           
                SetPerroEditar(perro);
            
            
        }

        private void SetPerroEditar(Perro perro)
        {
            try
            {
                txtSexoPerro.Text = perro.Sexo;
                txtNombrePerro.Text = perro.Nombre;
                txtTamanioPerro.Text = perro.Tamanio.ToString();
                txtEstadoPerro.Text = perro.Estado;
                txtPesoPerro.Text = perro.Peso.ToString();
                txtEdadPerro.Text = perro.Edad.ToString();
                dateEntradaPerro.Text = perro.FechaEntrada.ToString("dd-MM-yyyy");
                txtDescripcionPerro.Text = perro.Descripcion;
                txtRazaPerro.Text = perro.Raza;
                txtImagenPerro.Text = perro.Foto;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                //List<String> fila;
            }
        }
       
    }
}
