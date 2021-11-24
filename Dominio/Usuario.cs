using System;
using Protectora.Persistencia;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Dominio
{
    class Usuario
    {
        private int id;
        private String nombre;
        private String password;
        private DateTime fechaUltimaConex;


        public Usuario()
        {
        }


        public Usuario(int idR, String nR, String passwordR, DateTime fechaUltimaConexR)
        {
            id = idR;
            nombre = nR;
            password = passwordR;
            fechaUltimaConex = fechaUltimaConexR;

        }

        public List<Usuario> LeerTodosUsuarios()
        {
            UsuarioDAO perAUX = new UsuarioDAO();
            List<Usuario> arrayUsuarios = perAUX.LeerTodosUsuarios();
            return arrayUsuarios;
        }

        public Usuario LeerUsuario(string usuario, string pass)
        {
            UsuarioDAO perAUX = new UsuarioDAO();
            List<Usuario> arrayUsuarios = perAUX.LeerUsuario(usuario, pass);

            if (arrayUsuarios.Count == 1)
            {
                return arrayUsuarios[0];
            }
            return null;
        }
    }
}