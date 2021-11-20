using Protectora.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Persistencia
{
    class AnimalDAO
    {

        private String Tabla = "Animal";

        public void leerTodos() {
            Perro animal = new Perro();
        }

        public List<Perro> LeerTodosAnimales()
        {
            List<Perro> arrayAnimales = new List<Perro>();
            AgenteDB agente = AgenteDB.obtenerAgente();

            List<List<String>> arrayCarAnimales = new List<List<String>>();
            arrayCarAnimales = agente.leer("SELECT * FROM animales");

            foreach (List<String> user in arrayCarAnimales)
            {
                Perro a = new Perro(Int32.Parse(user[0]), user[1], user[2], 
                    Int32.Parse(user[3]), Int32.Parse(user[4]), Int32.Parse(user[5]),
                    DateTime.Parse(user[6]), user[7], user[8], user[9], user[10]
                    , Int32.Parse(user[11]),user[12]);
                arrayAnimales.Add(a);
            }
            Console.Write(" ");
            return arrayAnimales;
        }

    }
}
