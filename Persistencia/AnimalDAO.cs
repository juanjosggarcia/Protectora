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

        public void leerTodos()
        {
            Perro animal = new Perro();
        }

        public int InsertarPerro(Perro p)
        {
            AgenteDB agente = AgenteDB.obtenerAgente();

            agente.modificar("INSERT INTO animales (nombre,sexo,tamanio,peso,edad,entradaProtectora,foto,enlace,descripcion,estado,padrinos) VALUES ('" + p.getNombre().ToString() + "', '" + p.getsexo().ToString() + "', " + p.gettamanio().ToString() + "" +
                ", " + p.getpeso().ToString() + ", " + p.getedad().ToString() + ", '" + p.getfechaEntrada().ToString() + "', '" + p.getfoto().ToString() + "', '" + p.getenlace().ToString() + "'" +
                ", '" + p.getdescripcion().ToString() + "', '" + p.getestado().ToString() + "', " + p.getapadrinado().ToString() + ");");
            p.setid(Int32.Parse(agente.leer("SELECT MAX(id) FROM animales")[0][0]));

            return agente.modificar("INSERT INTO perros ( raza, IdAnimal ) VALUES ('" + p.getraza().ToString() + "', " + p.getid().ToString() + ");");
        }


        public int EliminarPerro(Perro p)
        {
            AgenteDB agente = AgenteDB.obtenerAgente();
            return agente.modificar("DELETE FROM animales WHERE Id=" + p.getid().ToString() + ";");
        }

        public int ModificarPerro(Perro p)
        {
            AgenteDB agente = AgenteDB.obtenerAgente();

            agente.modificar("UPDATE perros SET raza='" + p.getraza().ToString() + "' WHERE IdAnimal = " + p.getid().ToString() + "; ");

            return agente.modificar("UPDATE animales SET nombre= '" + p.getNombre().ToString() + "',sexo='" + p.getsexo().ToString() + "',tamanio= " + p.gettamanio().ToString() + ",peso=" + p.getpeso().ToString() + "," +
                "edad=" + p.getedad().ToString() + ",entradaProtectora= '" + p.getfechaEntrada().ToString() + "',foto='" + p.getfoto().ToString() + "',enlace='" + p.getenlace().ToString() + "',descripcion='" + p.getdescripcion().ToString() + "'," +
                "estado='" + p.getestado().ToString() + "',padrinos=" + p.getapadrinado().ToString() + " WHERE Id = " + p.getid().ToString() + "; ");
        }

        public List<Perro> LeerTodosAnimales()
        {
            List<Perro> arrayAnimales = new List<Perro>();
            AgenteDB agente = AgenteDB.obtenerAgente();
            List<List<String>> arrayCarAnimales = new List<List<String>>();
            arrayCarAnimales = agente.leer("SELECT * FROM animales a, perros p WHERE a.id=p.idAnimal");

            foreach (List<String> user in arrayCarAnimales)
            {
                Console.Write(" ");
                Perro a = new Perro(Int32.Parse(user[0]), user[1], user[2],
                    Int32.Parse(user[3]), Int32.Parse(user[4]), Int32.Parse(user[5]),
                    DateTime.Parse(user[6]), user[7], user[8], user[9], user[10]
                    , Int32.Parse(user[11]), user[13]);
                arrayAnimales.Add(a);
            }
            Console.Write(" ");
            return arrayAnimales;
        }

    }
}
