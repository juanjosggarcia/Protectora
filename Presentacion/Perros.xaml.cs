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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Protectora.Presentacion
{
    /// <summary>
    /// Lógica de interacción para Perros.xaml
    /// </summary>
    public partial class Perros : UserControl
    {
        public Perros()
        {
            InitializeComponent();
            metodito();
        }
        private void BtnPdrino_Click(object sender, RoutedEventArgs e)
        {
            Padrino Padrinito = new Padrino();
            Padrinito.Show();
        }

        private void BtnAniadir_Click(object sender, RoutedEventArgs e)
        {
            //PanelDinamicoBotones.Children.Add(new ControlUsuarioPerro());
            BotonAniadir nuevoPerro = new BotonAniadir();
            nuevoPerro.Show();
        }

        private void BtnBorrar_Click(object sender, RoutedEventArgs e)
        {

            //int numItems = spPanelDinamicoPerros.Children.Count;
            //if (numItems >= 1)
            //{
            //    spPanelDinamicoPerros.Children.RemoveAt(numItems - 1);
            //}
        }
        private void metodito()
        {
            for (int i = 0; i < 10; i++)
            {
                PanelDinamicoBotones.Children.Add(new ControlUsuarioPerro());
            }
        }
    }

}
