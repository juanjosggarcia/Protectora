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

        public List<Aviso> leerTodas()
        {
            AgenteDB agente = AgenteDB.obtenerAgente();

            List<List<String>> arrayCarAvisos = new List<List<String>>();
            arrayCarAvisos = agente.leer("SELECT * FROM avisos");

            foreach (List<String> user in arrayCarAvisos)
            {
                Aviso a = new Aviso(Int32.Parse(user[0]), user[1], user[2], user[3], Int32.Parse(user[4]),
                    user[5], user[6], user[7], DateTime.Parse(user[8]), user[9]);
                avisos.Add(a);
            }
            Console.Write(" ");
            return avisos;
        }

        public Aviso leer(Aviso obj)
        {
            throw new NotImplementedException();
        }

        public int insertar(Aviso obj)
        {
            AgenteDB agente = AgenteDB.obtenerAgente();

            return agente.modificar("INSERT INTO avisos (nombre,sexo,raza,tamanio,descripcionAnimal,descripcionLocalizacion,foto,fechaperdida,datosDueños) VALUES ('" + obj.Nombre.ToString() + "', '" + obj.Sexo.ToString() + "', '" + obj.Raza.ToString() + "', " + obj.Tamanio.ToString() + "" +
                ", '" + obj.DescripcionAnimal.ToString() + "', '" + obj.DescripcionLocalizacion.ToString() + "', '" + obj.Foto.ToString() + "', '" + obj.FechaPerdida.ToString() + "', '" + obj.DatosDuenios.ToString() + "');");
        }

        public int actualizar(Aviso obj)
        {
            AgenteDB agente = AgenteDB.obtenerAgente();
            return agente.modificar("UPDATE avisos SET nombre= '" + obj.Nombre.ToString() + "',sexo='" + obj.Sexo.ToString() + "',raza='" + obj.Raza.ToString() + "',tamanio= " + obj.Tamanio.ToString() + "," +
                "descripcionAnimal='" + obj.DescripcionAnimal.ToString() + "',descripcionLocalizacion= '" + obj.DescripcionLocalizacion.ToString() + "',foto='" + obj.Foto.ToString() + "',fechaperdida='" + obj.FechaPerdida.ToString() +
                "',datosDueños='" + obj.DatosDuenios.ToString() + "' WHERE Id = " + obj.Id.ToString() + "; ");
        }

        public int eliminar(Aviso obj)
        {
            AgenteDB agente = AgenteDB.obtenerAgente();
            return agente.modificar("DELETE FROM avisos WHERE Id=" + obj.Id.ToString() + ";");
        }
    }
}
