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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Protectora.Presentacion
{
    /// <summary>
    /// Lógica de interacción para PaginaSocios.xaml
    /// </summary>
    public partial class PaginaSocios : Page
    {
        public List<Socio> listaSocio = new List<Socio>();
        public PaginaSocios()
        {
            InitializeComponent();
        }

        private void BtnNextSocio_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewSocios.SelectedIndex != ListViewSocios.Items.Count - 1)
            {
                ListViewSocios.SelectedIndex++;
            }
        }

        private void BtnAnteriorSocio_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewSocios.SelectedIndex != 0)
            {
                ListViewSocios.SelectedIndex--;
            }
        }
        private void ListaSocios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItems = ListViewSocios.SelectedItems;
            foreach (Socio socio in selectedItems)
            {
                //SetSocio(perro);
                //DesactivarTextBoxs();

            }

            btnAnteriorSocio.IsEnabled = true;
            btnNextSocio.IsEnabled = true;
            btnEditSocio.IsEnabled = true;
            btnDeleteSocio.IsEnabled = true;
        }

    }
}
