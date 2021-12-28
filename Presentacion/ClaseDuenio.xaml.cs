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

                txtNombreDuenio.Text = persona.NombreCompleto;
                txtDniDuenio.Text = persona.Dni;
                txtCorreoDuenio.Text = persona.Correo;
                txtTelefonoDuenio.Text = persona.Telefono.ToString();
            }
        }


        private void mostrar()
        {

            BtnAceptarCambiosDuenio.Visibility = Visibility.Visible;
            BtnCancelarCambiosDuenio.Visibility = Visibility.Visible;
            BtnCancelarCambiosDuenio.IsEnabled = true;
            BtnAceptarCambiosDuenio.IsEnabled = true;
            txtNombreDuenio.IsEnabled = true;
            txtDniDuenio.IsEnabled = true;
            txtCorreoDuenio.IsEnabled = true;
            txtTelefonoDuenio.IsEnabled = true;
        }

        private void BtnAceptarCambiosDuenio_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool existe = true;
                int idDuenio;
                //Padrino padrino = new Padrino();
                if (persona == null)
                {
                    persona = new Persona();
                    existe = false;
                }
                persona.NombreCompleto = txtNombreDuenio.Text;
                persona.Dni = txtDniDuenio.Text;
                persona.Correo = txtCorreoDuenio.Text;
                persona.Telefono = Int32.Parse(txtTelefonoDuenio.Text);
                if (existe == true)
                {
                    GestorPersona.modificarPersona(persona);
                }
                else
                {
                    idDuenio = GestorPersona.addPersona(persona);
                    aviso.IdDuenio = idDuenio;
                    GestorAnimal.modificarAviso(aviso);
                }
                Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                ComprobarEntradaInt(txtTelefonoDuenio.Text, txtTelefonoDuenio);
                //List<String> fila;
            }
            
        }

        private void BtnCancelarCambiosDuenio_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void ComprobarEntradaInt(string valorIntroducido, TextBox componenteEntrada)
        {
            int num;
            bool cosa = int.TryParse(valorIntroducido, out num);
            if (cosa == false)
            {
                componenteEntrada.Foreground = Brushes.Red;
                componenteEntrada.ToolTip = "El dato introducido debe de ser del tipo numerico";
            }
        }

        private void PulsarTelefono(object sender, RoutedEventArgs e)
        {
            txtTelefonoDuenio.Foreground = Brushes.Black;
        }
    }

}
