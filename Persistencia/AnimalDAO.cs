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
            Animales animal = new Animales();
        }

        public List<Animales> LeerTodosAnimales()
        {
            List<Animales> arrayAnimales = new List<Animales>();
            AgenteDB agente = AgenteDB.obtenerAgente();

            List<List<String>> arrayCarAnimales = new List<List<String>>();
            arrayCarAnimales = agente.leer("SELECT * FROM animales");

            foreach (List<String> user in arrayCarAnimales)
            {
                Animales a = new Animales();
                a.id= Int32.Parse(user[0]);
                a.nombre= user[1];
                a.sexo= user[2];
                a.raza= user[3];
                a.tamanio= Int32.Parse(user[4]);
                a.peso= Int32.Parse(user[5]);
                a.edad= Int32.Parse(user[6]);
                a.fechaEntrada=DateTime.Parse(user[7]);
                a.foto= user[8];
                a.enlace= user[9];
                a.descripcion= user[10];
                a.estado= user[11];
                a.apadrinado= Int32.Parse(user[4]);


                arrayAnimales.Add(a);
            }
            Console.Write(" ");
            return arrayAnimales;
        }

    }
}
