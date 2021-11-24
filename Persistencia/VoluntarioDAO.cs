using Protectora.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Persistencia
{
    class VoluntarioDAO
    {


        public void leerTodos()
        {
            Voluntario voluntario = new Voluntario();
        }
        public int InsertarVoluntario(Voluntario v)
        {
            AgenteDB agente = AgenteDB.obtenerAgente();

            agente.modificar("INSERT INTO personas (nombreCompleto,correo,dni,telefono) VALUES ('" + v.getNombre().ToString() + "', '" + v.getcorreo().ToString() + "'," +
                " '" + v.getdni().ToString() + "', " + v.gettelefono().ToString() + ");");
            v.setid(Int32.Parse(agente.leer("SELECT MAX(Id) FROM personas")[0][0]));

            return agente.modificar("INSERT INTO voluntarios ( fotografia, horario, zonaDisponibilidad, IdPersona ) VALUES ('" + v.getfoto().ToString() + "'," +
                " '" + v.gethorario().ToString() + "', '" + v.getzonaDisponibilidad().ToString() + "', " + v.getid().ToString() + ");");
        }


        public int EliminarVoluntario(Voluntario v)
        {
            AgenteDB agente = AgenteDB.obtenerAgente();
            return agente.modificar("DELETE FROM personas WHERE Id=" + v.getid().ToString() + ";");
        }

        public int ModificarVoluntario(Voluntario v)
        {
            AgenteDB agente = AgenteDB.obtenerAgente();

            agente.modificar("UPDATE voluntarios SET fotografia='" + v.getfoto().ToString() + "' ,horario='" + v.gethorario().ToString() + "',zonaDisponibilidad= '" + v.getzonaDisponibilidad().ToString() + "' WHERE IdPersona = " + v.getid().ToString() + "; ");

            return agente.modificar("UPDATE personas SET nombreCompleto= '" + v.getNombre().ToString() + "',correo='" + v.getcorreo().ToString() + "'," +
                "dni='" + v.getdni().ToString() + "',telefono=" + v.gettelefono().ToString() + " WHERE Id = " + v.getid().ToString() + "; ");
        }

        public List<Voluntario> LeerTodosVoluntarios()
        {
            List<Voluntario> arrayVoluntarios = new List<Voluntario>();
            AgenteDB agente = AgenteDB.obtenerAgente();

            List<List<String>> arrayCarVoluntarios = new List<List<String>>();
            arrayCarVoluntarios = agente.leer("SELECT * FROM personas p, voluntarios v WHERE p.id=v.idPersona");

            foreach (List<String> user in arrayCarVoluntarios)
            {
                Voluntario v = new Voluntario(Int32.Parse(user[0]), user[1], user[2], user[3],
                     Int32.Parse(user[4]), user[6], user[7], user[8]);
                arrayVoluntarios.Add(v);
            }
            Console.Write(" ");
            return arrayVoluntarios;
        }

    }
}
