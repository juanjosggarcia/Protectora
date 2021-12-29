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
    public partial class ClaseContraseniaOlvidada : Window
    {
        MainWindow mainwindow;
        public ClaseContraseniaOlvidada(MainWindow m)
        {
            InitializeComponent();
            mainwindow = m;
            Configuracionidioma();
        }

        private void BtnRecordarContrasenia_Click(object sender, RoutedEventArgs e)
        {
            try {
                lblContrasenia.Content = "234234";
                Usuario usuario = new Usuario();
                usuario.Nombre = TexBoxUsuario.Text;
                usuario = GestorUsuario.obtenerPass(usuario);
                if (usuario != null)
                {
                    lblContrasenia.Content = usuario.Password;
                } else
                {
                    lblContrasenia.Content = "El usuario no existe";
                }
            }
            catch (Exception ex)
            {
                ELog.save(this, ex);
            }
        }
        public void Configuracionidioma()
        {
            string idioma = "";
            int eleccion = mainwindow.ComboBoxIdioma.SelectedIndex;
            switch (eleccion)
            {
                case 0:
                    idioma = "es-ES";
                    break;
                case 1:
                    idioma = "en-UK";
                    break;
            }
            Resources.MergedDictionaries.Add(App.DefineIdioma(idioma));
        }
    }
}
