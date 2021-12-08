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
    /// Lógica de interacción para ControlUsuarioPerro.xaml
    /// </summary>
    public partial class ControlUsuarioPerro : UserControl
    {
        public ControlUsuarioPerro()
        {
            InitializeComponent();

        }

        public string id { get; set; }
        public string nombre { get; set; }
        public string sexo { get; set; }
        public string tamanio { get; set; }
        public string estado { get; set; }
        public string edad { get; set; }
        public string peso { get; set; }
        public string entrada { get; set; }
        public string descripcion { get; set; }

    }

}
