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
using Protectora.Dominio;

namespace Protectora.Presentacion
{
    /// <summary>
    /// Lógica de interacción para ClaseDuenio.xaml
    /// </summary>

    public partial class ClaseDuenio : Window
    {
        PaginaAvisos pagAviso;
        Aviso aviso;
        Persona persona;
        public ClaseDuenio(PaginaAvisos p, Aviso aviso, bool visible)
        {

            InitializeComponent();
            if (visible)
            {
                mostrar();
            }
            pagAviso = p;
            this.aviso = aviso;
            mostrarDuenio();
        }

        public void mostrarDuenio()
        {
            //Padrino padrino = new Padrino();
            persona = new Persona();
            persona.Id = aviso.IdDuenio;
            persona = GestorPersona.obtenerPersona(persona);
            if (persona != null)
            {
                /*
                txtNombrePadrino.Text = persona.NombreCompleto;
                txtDniPadrino.Text = persona.Dni;
                txtCorreoPadrino.Text = persona.Correo;
                txtTelefonoPadrino.Text = persona.Telefono.ToString();
                txtDatosBanPadrino.Text = persona.DatosBancarios.ToString();
                txtImportePadrino.Text = persona.ImporteMensual.ToString();
                txtPagoPadrino.Text = persona.FormaPago;
                txtComienzoPadrino.Text = persona.FechaEntrada.ToString();*/
            }
        }


        private void mostrar()
        {
            /*
            BtnAceptarCambios.Visibility = Visibility.Visible;
            BtnAceptarCambios.IsEnabled = true;
            txtNombrePadrino.IsEnabled = true;
            txtDniPadrino.IsEnabled = true;
            txtCorreoPadrino.IsEnabled = true;
            txtTelefonoPadrino.IsEnabled = true;
            txtDatosBanPadrino.IsEnabled = true;
            txtImportePadrino.IsEnabled = true;
            txtPagoPadrino.IsEnabled = true;
            txtComienzoPadrino.IsEnabled = true;*/
        }
    }
}
