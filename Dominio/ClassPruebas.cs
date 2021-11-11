using Protectora.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Dominio
{
    class ClassPruebas
    {
        public static void Main(string[] args)
        {
            Perro perro = new Perro();
            AgenteDB agente = AgenteDB.obtenerAgente();

            agente.conectar();

            List<List<String>> arrayUsuarios = new List<List<String>>();

            arrayUsuarios = agente.leer("SELECT * FROM usuarios");


            foreach (List<String> user in arrayUsuarios)
            {
                foreach (object item in user)
                {
                    Console.Write(item + " ");
                }

            }
        }
    }
}
