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
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : Window, ICompartir
    {
        public Menu()
        {
            InitializeComponent();
        }
        public void pasaUltimaConexion(string texto)
        {
            lblFinalSesion.Content = texto;
        }

        private void BtnPerro_Click(object sender, RoutedEventArgs e)
        {
         
            Presentacion.GestionPerro nw = new Presentacion.GestionPerro();
            nw.Show();
            this.Close();

            
        }

        private void BtnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();

            this.Close();
        }
    }


}
