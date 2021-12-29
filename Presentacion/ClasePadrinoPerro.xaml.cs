﻿using Protectora.Dominio;
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
        PaginaPerro pagPerro;
        Perro perro;
        Padrino padrino;
        public ClasePadrinoPerro(PaginaPerro p, Perro perro, bool visible)
        {
            InitializeComponent();
            if (visible)
            {
                mostrar();
            }
            pagPerro = p;
            this.perro = perro;
            mostrarPadrino();
        }

        public void mostrarPadrino()
        {
            //Padrino padrino = new Padrino();
            padrino = new Padrino();
            padrino.Id = perro.Apadrinado;
            padrino = GestorPersona.obtenerPadrino(padrino);
            if (padrino != null)
            {
                txtNombrePadrino.Text = padrino.NombreCompleto;
                txtDniPadrino.Text = padrino.Dni;
                txtCorreoPadrino.Text = padrino.Correo;
                txtTelefonoPadrino.Text = padrino.Telefono.ToString();
                txtDatosBanPadrino.Text = padrino.DatosBancarios.ToString();
                txtImportePadrino.Text = padrino.ImporteMensual.ToString();
                txtPagoPadrino.Text = padrino.FormaPago;
                txtComienzoPadrino.Text = padrino.FechaEntrada.ToString();
            }
        }

        private void BtnPdrino_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool existe = true;
                int idPadrino;
                //Padrino padrino = new Padrino();
                if (padrino == null)
                {
                    padrino = new Padrino();
                    existe = false;
                }
                padrino.NombreCompleto = txtNombrePadrino.Text;
                padrino.Dni = txtDniPadrino.Text;
                padrino.Correo = txtCorreoPadrino.Text;
                padrino.Telefono = Int32.Parse(txtTelefonoPadrino.Text);
                padrino.DatosBancarios = txtDatosBanPadrino.Text;
                padrino.ImporteMensual = Int32.Parse(txtImportePadrino.Text);
                padrino.FormaPago = txtPagoPadrino.Text;
                padrino.FechaEntrada = DateTime.Parse(txtComienzoPadrino.Text);
                if (existe == true)
                {
                    GestorPersona.modificarPadrino(padrino, perro);
                }
                else
                {
                    idPadrino = GestorPersona.addPadrino(padrino, perro);
                    perro.Apadrinado = idPadrino;
                    GestorAnimal.modificarPerro(perro);
                }
                Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                ComprobarEntradaInt(txtTelefonoPadrino.Text, txtTelefonoPadrino);
                ComprobarEntradaInt(txtImportePadrino.Text, txtImportePadrino);
                ComprobarEntradaFecha(txtComienzoPadrino.Text, txtComienzoPadrino);
                //List<String> fila;
            }


        }

        private void mostrar()
        {
            BtnAceptarCambios.Visibility = Visibility.Visible;
            BtnCancelarCambios.Visibility = Visibility.Visible;
            BtnAceptarCambios.IsEnabled = true;
            BtnCancelarCambios.IsEnabled = true;
            txtNombrePadrino.IsEnabled = true;
            txtDniPadrino.IsEnabled = true;
            txtCorreoPadrino.IsEnabled = true;
            txtTelefonoPadrino.IsEnabled = true;
            txtDatosBanPadrino.IsEnabled = true;
            txtImportePadrino.IsEnabled = true;
            txtPagoPadrino.IsEnabled = true;
            txtComienzoPadrino.IsEnabled = true;
        }

        private void BtnAceptarCambios_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnCancelarCambios_Click(object sender, RoutedEventArgs e)
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


        private void ComprobarEntradaFecha(string valorIntroducido, TextBox componenteEntrada)
        {
            DateTime num;
            bool cosa = DateTime.TryParse(valorIntroducido, out num);
            if (cosa == false)
            {
                componenteEntrada.Foreground = Brushes.Red;
                componenteEntrada.ToolTip = "El dato introducido debe de ser del tipo fecha";

            }

        }

        private void PulsarFecha(object sender, RoutedEventArgs e)
        {
            txtComienzoPadrino.Foreground = Brushes.Black;
        }

        private void PulsarTelefono(object sender, RoutedEventArgs e)
        {
            txtComienzoPadrino.Foreground = Brushes.Black;
        }

        private void PulsarImporte(object sender, RoutedEventArgs e)
        {
            txtComienzoPadrino.Foreground = Brushes.Black;
        }

    }
}
