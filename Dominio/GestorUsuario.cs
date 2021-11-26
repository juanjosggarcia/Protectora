using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Dominio
{
    class GestorUsuario
    {

        public static Boolean autentificar(string user, string pass)
        {
            Usuario usuario = new Usuario();
            if (usuario.LeerUsuario(user, pass) != null)
            {
                return true;
            }
            return false;
        }

        public static Usuario autentificar1(string user, string pass)
        {
            Usuario usuario = new Usuario();
            usuario.LeerUsuario(user, pass);
            return usuario;
        }

        public static Boolean autentificar2(string user, string pass)
        {
            Usuario usuario = new Usuario();
            List<string> usuarioList = new List<string>();
            if (usuario.LeerUsuario(user, pass) != null)
            {
                usuarioList.Add(usuario.Id.ToString());
                usuarioList.Add(usuario.Nombre.ToString());
                usuarioList.Add(usuario.Password.ToString());
                usuarioList.Add(usuario.FechaUltimaConex.ToString());
                return true;
            }
            return false;
        }
    }

    
}
