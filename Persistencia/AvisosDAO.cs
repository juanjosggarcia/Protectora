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
            Avisos aviso = new Avisos();
        }

        public List<Avisos> LeerTodosAvisos()
        {
            List<Avisos> arrayAvisos = new List<Avisos>();
            AgenteDB agente = AgenteDB.obtenerAgente();

            List<List<String>> arrayCarAvisos = new List<List<String>>();
            arrayCarAvisos = agente.leer("SELECT * FROM avisos");

            foreach (List<String> user in arrayCarAvisos)
            {
                Avisos a = new Avisos();
                a.id = Int32.Parse(user[0]);
                a.nombre = user[1];
                a.sexo = user[2];
                a.raza = user[3];
                a.tamanio = Int32.Parse(user[4]);
                a.descripcionAnimal = user[5];
                a.descripcionLocalizacion = user[6];
                a.foto = user[7];
                a.fechaPerdida = DateTime.Parse(user[8]);
                a.datosDuenios = user[9];


                arrayAvisos.Add(a);
            }
            Console.Write(" ");
            return arrayAvisos;
        }

    }
}
