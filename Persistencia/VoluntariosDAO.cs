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
            Voluntario voluntario = new Voluntario();
        }

        public List<Voluntario> LeerTodosVoluntarios()
        {
            List<Voluntario> arrayVoluntarios = new List<Voluntario>();
            AgenteDB agente = AgenteDB.obtenerAgente();

            List<List<String>> arrayCarVoluntarios = new List<List<String>>();
            arrayCarVoluntarios = agente.leer("SELECT * FROM voluntarios");

            foreach (List<String> user in arrayCarVoluntarios)
            {
                Voluntario v = new Voluntario();
                v.set(Int32.Parse(user[0]), user[1], user[2], user[3],
                    Int32.Parse(user[4]), user[5], user[6], user[7]);
                


                arrayVoluntarios.Add(v);
            }
            Console.Write(" ");
            return arrayVoluntarios;
        }

    }
}
