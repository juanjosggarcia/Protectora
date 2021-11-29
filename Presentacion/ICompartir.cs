using Protectora.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Presentacion
{
    interface ICompartir
    {
        void pasarUltimaConexion(string texto);
        void pasarUsuario(Usuario user);
    }
}
