using Protectora.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Persistencia
{
    class AvisosDAO
    {

        private String Tabla = "Avisos";

        public void leerTodos()
        {
            Aviso aviso = new Aviso();
        }

        public List<Aviso> LeerTodosAvisos()
        {
            List<Aviso> arrayAvisos = new List<Aviso>();
            AgenteDB agente = AgenteDB.obtenerAgente();

            List<List<String>> arrayCarAvisos = new List<List<String>>();
            arrayCarAvisos = agente.leer("SELECT * FROM avisos");

            foreach (List<String> user in arrayCarAvisos)
            {
                Aviso a = new Aviso(Int32.Parse(user[0]), user[1], user[2], user[3], Int32.Parse(user[4]),
                    user[5], user[6], user[7], DateTime.Parse(user[8]), user[9]);
                arrayAvisos.Add(a);
            }
            Console.Write(" ");
            return arrayAvisos;
        }

    }
}
