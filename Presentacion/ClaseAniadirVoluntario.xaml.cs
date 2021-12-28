﻿using System;
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
    /// Lógica de interacción para ClaseAniadirVoluntario.xaml
    /// </summary>
    public partial class ClaseAniadirVoluntario : Window
    {
        PaginaVoluntarios pagVoluntarios;

        public ClaseAniadirVoluntario(PaginaVoluntarios p)
        {
            InitializeComponent();
            pagVoluntarios = p;
        }
        private void LimpiarTextoNombre(object sender, EventArgs e)
        {
            txtNombreVoluntario.Text = txtNombreVoluntario.Text == "Nombre completo" ? string.Empty : txtNombreVoluntario.Text;
            txtNombreVoluntario.Foreground = new SolidColorBrush(Colors.Black);
            lblNombre.Visibility = Visibility.Visible;
        }
        private void RellenarTextoNombre(object sender, EventArgs e)
        {
            if (txtNombreVoluntario.Text == string.Empty)
            {
                txtNombreVoluntario.Text = "Nombre completo";
                lblNombre.Visibility = Visibility.Hidden;
                txtNombreVoluntario.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void LimpiarTextoCorreo(object sender, EventArgs e)
        {
            txtCorreoVoluntario.Text = txtCorreoVoluntario.Text == "Correo" ? string.Empty : txtCorreoVoluntario.Text;
            txtCorreoVoluntario.Foreground = new SolidColorBrush(Colors.Black);
            lblCorreo.Visibility = Visibility.Visible;

        }
        private void RellenarTextoCorreo(object sender, EventArgs e)
        {
            if (txtCorreoVoluntario.Text == string.Empty)
            {
                txtCorreoVoluntario.Text = "Correo";
                lblCorreo.Visibility = Visibility.Hidden;
                txtCorreoVoluntario.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void LimpiarTextoDNI(object sender, EventArgs e)
        {
            txtDniVoluntario.Text = txtDniVoluntario.Text == "DNI" ? string.Empty : txtDniVoluntario.Text;
            txtDniVoluntario.Foreground = new SolidColorBrush(Colors.Black);
            lblDni.Visibility = Visibility.Visible;

        }
        private void RellenarTextoDNI(object sender, EventArgs e)
        {
            if (txtDniVoluntario.Text == string.Empty)
            {
                txtDniVoluntario.Text = "DNI";
                lblDni.Visibility = Visibility.Hidden;
                txtDniVoluntario.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void LimpiarTextoTelefono(object sender, EventArgs e)
        {
            txtTelefonoVoluntario.Text = txtTelefonoVoluntario.Text == "Telefono" ? string.Empty : txtTelefonoVoluntario.Text;
            txtTelefonoVoluntario.Foreground = new SolidColorBrush(Colors.Black);
            lblTelefono.Visibility = Visibility.Visible;

        }
        private void RellenarTextoTelefono(object sender, EventArgs e)
        {
            if (txtTelefonoVoluntario.Text == string.Empty)
            {
                txtTelefonoVoluntario.Text = "Telefono";
                lblTelefono.Visibility = Visibility.Hidden;
                txtTelefonoVoluntario.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void LimpiarTextoHorario(object sender, EventArgs e)
        {
            txtHorarioVol.Text = txtHorarioVol.Text == "Horario del voluntario" ? string.Empty : txtHorarioVol.Text;
            txtHorarioVol.Foreground = new SolidColorBrush(Colors.Black);
            lblHorario.Visibility = Visibility.Visible;

        }
        private void RellenarTextoHorario(object sender, EventArgs e)
        {
            if (txtHorarioVol.Text == string.Empty)
            {
                txtHorarioVol.Text = "Horario del voluntario";
                lblHorario.Visibility = Visibility.Hidden;
                txtHorarioVol.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void LimpiarTextoZona(object sender, EventArgs e)
        {
            txtZonaDisVol.Text = txtZonaDisVol.Text == "Zona disponible" ? string.Empty : txtZonaDisVol.Text;
            txtZonaDisVol.Foreground = new SolidColorBrush(Colors.Black);
            lblZona.Visibility = Visibility.Visible;

        }
        private void RellenarTextoZona(object sender, EventArgs e)
        {
            if (txtZonaDisVol.Text == string.Empty)
            {
                txtZonaDisVol.Text = "Zona disponible";
                lblZona.Visibility = Visibility.Hidden;
                txtZonaDisVol.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void LimpiarTextoImagen(object sender, EventArgs e)
        {
            txtImagenVoluntarioNuevo.Text = txtImagenVoluntarioNuevo.Text == "Imagen" ? string.Empty : txtImagenVoluntarioNuevo.Text;
            txtImagenVoluntarioNuevo.Foreground = new SolidColorBrush(Colors.Black);
            lblImagen.Visibility = Visibility.Visible;

        }
        private void RellenarTextoImagen(object sender, EventArgs e)
        {
            if (txtImagenVoluntarioNuevo.Text == string.Empty)
            {
                txtImagenVoluntarioNuevo.Text = "Imagen";
                lblImagen.Visibility = Visibility.Hidden;
                txtImagenVoluntarioNuevo.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void NuevoVoluntario_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Voluntario voluntario = new Voluntario
                {
                    NombreCompleto = txtNombreVoluntario.Text,
                    Correo = txtCorreoVoluntario.Text,
                    Dni = txtDniVoluntario.Text,
                    Telefono = Int32.Parse(txtTelefonoVoluntario.Text),
                    Horario = txtHorarioVol.Text,
                    ZonaDisponibilidad = txtZonaDisVol.Text,

                };

                if (string.IsNullOrEmpty(txtImagenVoluntarioNuevo.Text) || txtImagenVoluntarioNuevo.Text == "Imagen")
                {
                    voluntario.Foto = "default.jpg";
                }
                else
                {
                    string s = txtImagenVoluntarioNuevo.Text;
                    string[] subs = s.Split('\\');
                    voluntario.Foto = subs[subs.Length - 1];
                }

                GestorPersona.crearVoluntario(voluntario);
                pagVoluntarios.CargarVoluntarios();
                this.Close();
            }
            catch (Exception ex)
            {
                ComprobarEntradaInt(txtTelefonoVoluntario.Text, txtTelefonoVoluntario);
                Console.Write(ex);
                //List<String> fila;
            }

            
        }

        private void BtnImagen_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog fd = new Microsoft.Win32.OpenFileDialog
            {
                Title = "Select a picture",
                Filter = "Images|*.jpg;*.gif;*.bmp;*.png"
            };
            if (fd.ShowDialog() == true)
            {
                try
                {
                    txtImagenVoluntarioNuevo.Text = fd.FileName;
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show("Error al cargar la imagen " + ex.Message);
                }
            }
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


       
    }
}
