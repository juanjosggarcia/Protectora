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
    /// Lógica de interacción para BotonAniadir.xaml
    /// </summary>
    public partial class BotonAniadir : Window
    {
        public BotonAniadir()
        {
            InitializeComponent();
        }

        private void LimpiarTextoNombre(object sender, EventArgs e)
        {
            if (txtNombrePerro.Text == "Nombre de Usuario")
            {
                txtNombrePerro.Text = "";
                txtNombrePerro.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void LimpiarTextoSexo(object sender, EventArgs e)
        {
            if (txtSexoPerro.Text == "Nombre de Usuario")
            {
                txtSexoPerro.Text = "";
                txtSexoPerro.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

    }
}
