using Protectora.Dominio;
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
    /// Lógica de interacción para ClasePadrinoPerro.xaml
    /// </summary>
    public partial class ClasePadrinoPerro : Window
    {
        public ClasePadrinoPerro(Perro perro)
        {
            InitializeComponent();
            mostrarPadrino(perro);
        }

        public void mostrarPadrino(Perro perro)
        {
            Padrino padrino = new Padrino();
            padrino.Id = perro.Apadrinado;
            padrino = GestorPersona.obtenerPadrino(padrino);
            lblNombrePadrino.Content = padrino.NombreCompleto;
            lblDniPadrino.Content = padrino.Dni;
            lblCorreoPadrino.Content = padrino.Correo;
            lblTelefonoPadrino.Content = padrino.Telefono;
            lblDatosBanPadrino.Content = padrino.DatosBancarios;
            lblImportePadrino.Content = padrino.ImporteMensual;
            lblPagoPadrino.Content = padrino.FormaPago;
            lblComienzoPadrino.Content = padrino.FechaEntrada;

        }
    }
}
