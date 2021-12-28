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
    /// Lógica de interacción para ClaseAcercaDe.xaml
    /// </summary>
    public partial class ClaseAcercaDe : Window
    {
        MainWindow mainwindow;
        int contadorJuanjo = 0;
        public ClaseAcercaDe(MainWindow m)
        {
            InitializeComponent();
            mainwindow = m;
            Configuracionidioma();

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

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Show();
            this.Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            contadorJuanjo ++;
            if (contadorJuanjo>=5)
            {
                dialogo.Visibility = Visibility.Visible;
                dialogo2.Visibility = Visibility.Visible;
                dialogo3.Visibility = Visibility.Visible;
                dialogo4.Visibility = Visibility.Visible;

            }
        }
    }
}
