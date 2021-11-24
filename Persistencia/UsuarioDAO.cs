using Protectora.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Persistencia
{
    class UsuarioDAO
    {
        private String Tabla = "Usuario";
        public void leerTodos()
        {
            Usuario persona = new Usuario();
        }

        public List<Usuario> LeerTodosUsuarios()
        {
            List<Usuario> arrayUsuarios = new List<Usuario>();
            AgenteDB agente = AgenteDB.obtenerAgente();

            List<List<String>> arrayCarUsuarios = new List<List<String>>();
            arrayCarUsuarios = agente.leer("SELECT * FROM usuarios");

            foreach (List<String> user in arrayCarUsuarios)
            {
                Usuario p = new Usuario(Int32.Parse(user[0]), user[1], user[2], DateTime.Parse(user[3]));
                arrayUsuarios.Add(p);
            }
            Console.Write(" ");
            return arrayUsuarios;
        }
    }
}
