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
        private UsuarioDAO usuDAO;


        public Usuario()
        {
            this.usuDAO = new UsuarioDAO();
        }


        public Usuario(int id, String n, String password, DateTime fechaUltimaConex)
        {
            this.usuDAO = new UsuarioDAO();
            this.id = id;
            this.nombre = n;
            this.password = password;
            this.fechaUltimaConex = fechaUltimaConex;
        }
        public void ModificarUsuarioFecha()
        {
            this.usuDAO.ModificarUsuarioFecha((Usuario)this.MemberwiseClone());
            Console.Write(" ");
        }

        public List<Usuario> LeerTodosUsuarios()
        {
            List<Usuario> arrayUsuarios = usuDAO.LeerTodosUsuarios();
            return arrayUsuarios;
        }

        public Usuario LeerUsuario(string usuario, string pass)
        {
            List<Usuario> arrayUsuarios = usuDAO.LeerUsuario(usuario, pass);

            if (arrayUsuarios.Count == 1)
            {
                return arrayUsuarios[0];
            }
            return null;
        }

        public int getid()
        {
            return this.id;
        }
        public void setid(int id)
        {
            this.id = id;
        }

        public string getNombre()
        {
            return this.nombre;
        }
        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public DateTime getfechaUltimaConex()
        {
            return this.fechaUltimaConex;
        }
        public void setfechaUltimaConex(DateTime fechaUltimaConex)
        {
            this.fechaUltimaConex = fechaUltimaConex;
        }

        public string getpassword()
        {
            return this.password;
        }
        public void setpassword(string password)
        {
            this.password = password;
        }
    }
}