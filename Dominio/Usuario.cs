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
        private string nombre;
        private string password;
        private DateTime fechaUltimaConex;


        public Usuario()
        {
        }


        public Usuario(int idR, string nR, string passwordR, DateTime fechaUltimaConexR)
        {
            Id = idR;
            Nombre = nR;
            Password = passwordR;
            FechaUltimaConex = fechaUltimaConexR;

        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Password { get => password; set => password = value; }
        public DateTime FechaUltimaConex { get => fechaUltimaConex; set => fechaUltimaConex = value; }

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