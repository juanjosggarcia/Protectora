using Protectora.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Persistencia
{
    class AnimalDAO : IDAO<Perro>
    {

        public List<Perro> leerTodas()
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

        public Perro leer(Perro obj)
        {
            throw new NotImplementedException();
        }

        public int insertar(Perro obj)
        {
            AgenteDB agente = AgenteDB.obtenerAgente();

            agente.modificar("INSERT INTO animales (nombre,sexo,tamanio,peso,edad,entradaProtectora,foto,enlace,descripcion,estado,padrinos) VALUES ('" + obj.nombre.ToString() + "', '" + obj.sexo.ToString() + "', " + obj.tamanio.ToString() + "" +
                ", " + obj.peso.ToString() + ", " + obj.edad.ToString() + ", '" + obj.fechaEntrada.ToString() + "', '" + obj.foto.ToString() + "', '" + obj.enlace.ToString() + "'" +
                ", '" + obj.descripcion.ToString() + "', '" + obj.estado.ToString() + "', " + obj.apadrinado.ToString() + ");");

            obj.id = (Int32.Parse(agente.leer("SELECT MAX(id) FROM animales")[0][0]));

            return agente.modificar("INSERT INTO perros ( raza, IdAnimal ) VALUES ('" + obj.Raza.ToString() + "', " + obj.id.ToString() + ");");
        }

        public int actualizar(Perro obj)
        {
            AgenteDB agente = AgenteDB.obtenerAgente();

            agente.modificar("UPDATE perros SET raza='" + obj.Raza.ToString() + "' WHERE IdAnimal = " + obj.id.ToString() + "; ");

            return agente.modificar("UPDATE animales SET nombre= '" + obj.nombre.ToString() + "',sexo='" + obj.sexo.ToString() + "',tamanio= " + obj.tamanio.ToString() + ",peso=" + obj.peso.ToString() + "," +
                "edad=" + obj.edad.ToString() + ",entradaProtectora= '" + obj.fechaEntrada.ToString() + "',foto='" + obj.foto.ToString() + "',enlace='" + obj.enlace.ToString() + "',descripcion='" + obj.descripcion.ToString() + "'," +
                "estado='" + obj.estado.ToString() + "',padrinos=" + obj.apadrinado.ToString() + " WHERE Id = " + obj.id.ToString() + "; ");

        }

        public int eliminar(Perro obj)
        {
            AgenteDB agente = AgenteDB.obtenerAgente();
            return agente.modificar("DELETE FROM animales WHERE Id=" + obj.id.ToString() + ";");
        }
    }
}
