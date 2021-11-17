using Protectora.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Persistencia
{
    class VoluntariosDAO
    {

        private String Tabla = "Voluntarios";

        public void leerTodos()
        {
            Voluntarios voluntario = new Voluntarios();
        }

        public List<Voluntarios> LeerTodosVoluntarios()
        {
            List<Voluntarios> arrayVoluntarios = new List<Voluntarios>();
            AgenteDB agente = AgenteDB.obtenerAgente();

            List<List<String>> arrayCarVoluntarios = new List<List<String>>();
            arrayCarVoluntarios = agente.leer("SELECT * FROM voluntarios");

            foreach (List<String> user in arrayCarVoluntarios)
            {
                Voluntarios v = new Voluntarios();
                v.set(Int32.Parse(user[0]), user[1], user[2], user[3],
                    Int32.Parse(user[4]), user[5], user[6], user[7]);
                


                arrayVoluntarios.Add(v);
            }
            Console.Write(" ");
            return arrayVoluntarios;
        }

    }
}
