using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Dominio
{
    class GestorUsuario
    {
        /*
        public static Boolean autentificar(string user, string pass)
        {
            Usuario usuario = new Usuario();
            if (usuario.LeerUsuario(user, pass) != null)
            {
                return true;
            }
            return false;
        }
        */
        public static Usuario obtenerUser(Usuario usuario)
        {
            usuario.LeerUsuario();
            if (usuario.UsuDAO.usuarios.Count!=0)
            {
                return usuario.UsuDAO.usuarios[0];
            }
            return null;

        }
        

        public static Boolean addUltimaConexion(Usuario user)
        {
            user.ModificarUsuarioFecha();
            return true;
        }
    }

    
}
