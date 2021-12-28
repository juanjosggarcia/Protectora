using Protectora.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Persistencia
{
    class AvisoDAO : IDAO<Aviso>
    {
        public readonly List<Aviso> avisos;

        public AvisoDAO()
        {
            this.avisos = new List<Aviso>();
        }

        public Aviso leerName(Aviso obj)
        {
            //AgenteDB agente = AgenteDB.obtenerAgente();
            //List<List<String>> arrayCarPerros = agente.leer("SELECT * FROM animales a, perros p WHERE a.id=p.idAnimal AND a.nombre = '" + obj.Nombre + "'; ");

            List<List<String>> arrayCarAvisos = AgenteDB.obtenerAgente().leer("SELECT * FROM avisos a WHERE a.nombre = '" + obj.Nombre + "';");

            foreach (List<String> user in arrayCarAvisos)
            {
                Aviso a = new Aviso(Int32.Parse(user[0]), user[1], user[2], user[3], Int32.Parse(user[4]),
                    user[5], user[6], user[7], DateTime.Parse(user[8]), user[9], Int32.Parse(user[10]));
                avisos.Add(a);
            }
            if (avisos.Count != 0)
            {
                return avisos[0];
            }
            else return null;
        }
        public List<Aviso> leerTodas()
        {
            List<List<String>> arrayCarAvisos = AgenteDB.obtenerAgente().leer("SELECT * FROM avisos");

            foreach (List<String> user in arrayCarAvisos)
            {
                Aviso a = new Aviso(Int32.Parse(user[0]), user[1], user[2], user[3], Int32.Parse(user[4]),
                    user[5], user[6], user[7], DateTime.Parse(user[8]), user[9], Int32.Parse(user[10]));
                avisos.Add(a);
            }
            return avisos;
        }

        public Aviso leerId(Aviso obj)
        {
            throw new NotImplementedException();
        }

        public int insertar(Aviso obj)
        {
            //AgenteDB agente = AgenteDB.obtenerAgente();

            return AgenteDB.obtenerAgente().modificar("INSERT INTO avisos (nombre,sexo,raza,tamanio,descripcionAnimal,descripcionAdicional,foto,fechaperdida,zonaPerdida,idDuenio) VALUES ('" + obj.Nombre.ToString() + "', '" + obj.Sexo.ToString() + "', '" + obj.Raza.ToString() + "', " + obj.Tamanio.ToString() + "" +
                ", '" + obj.DescripcionAnimal.ToString() + "', '" + obj.DescripcionAdicional.ToString() + "', '" + obj.Foto.ToString() + "', '" + obj.FechaPerdida.ToString() + "', '" + obj.ZonaPerdida.ToString() + "', " + obj.IdDuenio + ");");
        }

        public int actualizar(Aviso obj)
        {
            //AgenteDB agente = AgenteDB.obtenerAgente();

            return AgenteDB.obtenerAgente().modificar("UPDATE avisos SET nombre= '" + obj.Nombre.ToString() + "',sexo='" + obj.Sexo.ToString() + "',raza='" + obj.Raza.ToString() + "',tamanio= " + obj.Tamanio.ToString() + "," +
                "descripcionAnimal='" + obj.DescripcionAnimal.ToString() + "',descripcionAdicional= '" + obj.DescripcionAdicional.ToString() + "',foto='" + obj.Foto.ToString() + "',fechaperdida='" + obj.FechaPerdida.ToString() +
                "',zonaPerdida='" + obj.ZonaPerdida.ToString() + "',idDuenio="+obj.IdDuenio.ToString() + " WHERE Id = " + obj.Id.ToString() + ";");
        }

        public int eliminar(Aviso obj)
        {
            //AgenteDB agente = AgenteDB.obtenerAgente();

            //return agente.modificar("DELETE FROM avisos WHERE Id=" + obj.Id.ToString() + ";");

            return AgenteDB.obtenerAgente().modificar("DELETE FROM avisos WHERE Id=" + obj.Id.ToString() + ";");
        }
    }
}
