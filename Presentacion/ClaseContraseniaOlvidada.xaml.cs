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
    /// Lógica de interacción para ClaseContraseniaOlvidada.xaml
    /// </summary>
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
            lblContrasenia.Content = "234234";
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
