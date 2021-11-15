using Protectora.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Persistencia
{
    class VoluntariosDAO
    {

        private String Tabla = "Voluntarios";

        public void leerTodos()
        {
            Voluntarios voluntario = new Voluntarios();
        }

        public List<Voluntarios> LeerTodosVoluntarios()
        {
            List<Voluntarios> arrayVoluntarios = new List<Voluntarios>();
            AgenteDB agente = AgenteDB.obtenerAgente();

            List<List<String>> arrayCarVoluntarios = new List<List<String>>();
            arrayCarVoluntarios = agente.leer("SELECT * FROM voluntarios");

            foreach (List<String> user in arrayCarVoluntarios)
            {
                Voluntarios v = new Voluntarios();
                v.id = Int32.Parse(user[0]);
                v.nombreCompleto = user[1];
                v.correo = user[2];
                v.dni = user[3];
                v.telefono = Int32.Parse(user[4]);
                v.foto = user[5];
                v.horario = user[6];
                v.zonaDisponibilidad = user[7];


                arrayVoluntarios.Add(v);
            }
            Console.Write(" ");
            return arrayVoluntarios;
        }

    }
}
