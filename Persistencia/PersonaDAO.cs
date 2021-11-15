using Protectora.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Persistencia
{
    class PersonaDAO
    {
        private String Tabla = "Persona";
        public void leerTodos() {
            Persona persona = new Persona();
        }

        public List<Persona> LeerTodasPersonas()
        {
            List<Persona> arrayUsuarios = new List<Persona>();
            AgenteDB agente = AgenteDB.obtenerAgente();

            List<List<String>> arrayCarUsuarios = new List<List<String>>();
            arrayCarUsuarios = agente.leer("SELECT * FROM usuarios");

            foreach (List<String> user in arrayCarUsuarios)
            {
                Persona p = new Persona();
                p.set(Int32.Parse(user[0]),user[1],user[2],DateTime.Parse(user[3]));
                arrayUsuarios.Add(p);
            }
            Console.Write(" ");
            return arrayUsuarios;
        }
    }
}
