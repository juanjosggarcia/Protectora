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
            txtNombrePadrino.Text = padrino.NombreCompleto;
            txtDniPadrino.Text = padrino.Dni;
            txtCorreoPadrino.Text = padrino.Correo;
            txtTelefonoPadrino.Text = padrino.Telefono.ToString();
            txtDatosBanPadrino.Text = padrino.DatosBancarios.ToString();
            txtImportePadrino.Text = padrino.ImporteMensual.ToString();
            txtPagoPadrino.Text = padrino.FormaPago;
            txtComienzoPadrino.Text = padrino.FechaEntrada.ToString();

        }

        private void BtnPdrino_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
