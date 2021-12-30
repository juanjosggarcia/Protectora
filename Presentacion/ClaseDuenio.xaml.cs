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
            try{
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
            catch (Exception ex)
            {
                ELog.save(this, ex);
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
                persona = new Persona();
                persona.Id = aviso.IdDuenio;
                persona.NombreCompleto = txtNombreDuenio.Text;
                persona.Dni = txtDniDuenio.Text;
                persona.Correo = txtCorreoDuenio.Text;
                persona.Telefono = Int32.Parse(txtTelefonoDuenio.Text);
                if (aviso.IdDuenio!=0)
                {
                    GestorPersona.modificarPersona(persona);
                }
                else
                {
                    int idDuenio = GestorPersona.addPersona(persona);
                    aviso.IdDuenio = idDuenio;
                    GestorAnimal.modificarAviso(aviso);
                }
                Close();
            }
            catch (FormatException ex)
            {
                Console.Write(ex);
                ComprobarEntradaInt(txtTelefonoDuenio.Text, txtTelefonoDuenio, errorTelefono);
            }
            catch (System.Data.OleDb.OleDbException ex)
            {
                Console.Write(ex);
                ELog.save(this, ex);
            }
            catch (Exception ex)
            {
                ELog.save(this, ex);
            }

        }
        private void BtnCancelarCambiosDuenio_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        //////////////////////////////////////////////////////////////// EVENTOS AUXILIARES ////////////////////////////////////////////////////////////////

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
            txtTelefonoDuenio.Foreground = Brushes.Black;
            errorTelefono.Visibility = Visibility.Hidden;

        }
    }
}
