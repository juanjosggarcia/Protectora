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
        public ClaseAcercaDe(MainWindow m)
        {
            InitializeComponent();
            App.DefineIdioma("es-ES");
            mainwindow = m;
        }
    }
}
