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

        private void BtnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();

            this.Close();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            BtnCerrarSesion.Visibility = Visibility.Visible;

        }
   

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
            BtnCerrarSesion.Visibility = Visibility.Collapsed;

        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemPerros":
                    usc = new Perros();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemSocios":
                    usc = new Socios();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemVoluntario":
                    usc = new Voluntarios();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemAvisos":
                    usc = new Avisos();
                    GridMain.Children.Add(usc);
                    break;

                default:
                    usc = new Perros();
                    GridMain.Children.Add(usc);
                    break;
            }
        }

    }
}
