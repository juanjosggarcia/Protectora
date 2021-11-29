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
    /// Lógica de interacción para GestionPerro.xaml
    /// </summary>
    public partial class GestionPerro : Window
    {
        public GestionPerro()
        {
            InitializeComponent();
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            // recorre todas las ventanas en ejecucion actualmente
            /*
            foreach (Window window in Application.Current.Windows)
            {
                Console.WriteLine(window.Title);
            }
            */

            Application.Current.Windows.OfType<Menu>().FirstOrDefault().Show();

            //menuWin.Show();
            //App.Current.menuWin.Show();

            //Presentacion.Menu nw = new Presentacion.Menu();
            //nw.Show();
            Hide();
            //this.Close();
        }
    }
}
