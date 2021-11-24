using Protectora.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Persistencia
{
    class AvisoDAO
    {

        private String Tabla = "Avisos";

        public void leerTodos()
        {
            Aviso aviso = new Aviso();
        }

        public int InsertarAviso(Aviso a)
        {
            AgenteDB agente = AgenteDB.obtenerAgente();

            return agente.modificar("INSERT INTO avisos (nombre,sexo,raza,tamanio,descripcionAnimal,descripcionLocalizacion,foto,fechaperdida,datosDueños) VALUES ('" + a.getNombre().ToString() + "', '" + a.getsexo().ToString() + "', '" + a.getraza().ToString() + "', " + a.gettamanio().ToString() + "" +
                ", '" + a.getdescripcionAnimal().ToString() + "', '" + a.getdescripcionLocalizacion().ToString() + "', '" + a.getfoto().ToString() + "', '" + a.getfechaPerdida().ToString() + "', '" + a.getdatosDuenios().ToString() + "');");
        }

        public int EliminarAviso(Aviso a)
        {
            AgenteDB agente = AgenteDB.obtenerAgente();
            return agente.modificar("DELETE FROM avisos WHERE Id=" + a.getid().ToString() + ";");
        }

        public int ModificarAviso(Aviso a)
        {
            AgenteDB agente = AgenteDB.obtenerAgente();
            return agente.modificar("UPDATE avisos SET nombre= '" + a.getNombre().ToString() + "',sexo='" + a.getsexo().ToString() + "',raza='" + a.getraza().ToString() + "',tamanio= " + a.gettamanio().ToString() + "," +
                "descripcionAnimal='" + a.getdescripcionAnimal().ToString() + "',descripcionLocalizacion= '" + a.getdescripcionLocalizacion().ToString() + "',foto='" + a.getfoto().ToString() + "',fechaperdida='" + a.getfechaPerdida().ToString() +
                "',datosDueños='" + a.getdatosDuenios().ToString() + "' WHERE Id = " + a.getid().ToString() + "; ");
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
