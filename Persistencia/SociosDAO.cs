using Protectora.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Persistencia
{
    class SociosDAO
    {

        private String Tabla = "Socio";

        public void leerTodos()
        {
            Socios socios = new Socios();
        }

        public List<Socios> LeerTodosSocios()
        {
            List<Socios> arraySocios = new List<Socios>();
            AgenteDB agente = AgenteDB.obtenerAgente();

            List<List<String>> arrayCarSocios = new List<List<String>>();
            arrayCarSocios = agente.leer("SELECT * FROM socios");

            foreach (List<String> user in arrayCarSocios)
            {
                Socios s = new Socios();
                s.set(Int32.Parse(user[0]), user[1], user[2], Int32.Parse(user[3]), user[4], user[5], Int32.Parse(user[6]), user[7]);
                arraySocios.Add(s);
            }
            Console.Write(" ");
            return arraySocios;
        }

    }
}
