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
                s.id = Int32.Parse(user[0]);
                s.nombreCompleto = user[1];
                s.dni = user[2];
                s.telefono = Int32.Parse(user[3]);
                s.correo = user[4];
                s.datosBancarios = user[5];
                s.importeMensual = Int32.Parse(user[6]);
                s.formaPago = user[7];
                

                arraySocios.Add(s);
            }
            Console.Write(" ");
            return arraySocios;
        }

    }
}
