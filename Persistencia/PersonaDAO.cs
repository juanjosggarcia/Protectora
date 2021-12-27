﻿using Protectora.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Persistencia
{
    class PersonaDAO : IDAO<Persona>
    {
        public readonly List<Persona> personas;

        public PersonaDAO()
        {
            this.personas = new List<Persona>();
        }

        public int actualizar(Persona obj)
        {
            return AgenteDB.obtenerAgente().modificar("UPDATE personas SET nombreCompleto= '" + obj.NombreCompleto.ToString() + "',correo='" + obj.Correo.ToString() + "'," +
                "dni='" + obj.Dni.ToString() + "',telefono=" + obj.Telefono.ToString() + " WHERE Id = " + obj.Id.ToString() + "; ");

        }

        public int eliminar(Persona obj)
        {
            return AgenteDB.obtenerAgente().modificar("DELETE FROM personas WHERE Id=" + obj.Id.ToString() + ";");
        }

        public int insertar(Persona obj)
        {
            return AgenteDB.obtenerAgente().modificar("INSERT INTO personas (nombreCompleto,correo,dni,telefono) VALUES ('" + obj.NombreCompleto.ToString() + "', '" + obj.Correo.ToString() + "'," +
            " '" + obj.Dni.ToString() + "', " + obj.Telefono.ToString() + ");");
        }

        public Persona leer(Persona obj)
        {
            List<List<String>> arrayCarPersonas = AgenteDB.obtenerAgente().leer("SELECT * FROM Personas WHERE nombreCompleto='" + obj.NombreCompleto + "';");

            foreach (List<String> user in arrayCarPersonas)
            {
                Persona p = new Persona(Int32.Parse(user[0]), user[1], user[2], user[3], Int32.Parse(user[4]));
                personas.Add(p);
            }
            if (personas.Count != 0)
            {
                return personas[0];
            }
            else return null;
        }

        public List<Persona> leerTodas()
        {
            List<List<String>> arrayCarPersonas = AgenteDB.obtenerAgente().leer("SELECT * FROM Persona");

            foreach (List<String> user in arrayCarPersonas)
            {
                Persona p = new Persona(Int32.Parse(user[0]), user[1], user[2], user[3], Int32.Parse(user[4]));
                personas.Add(p);
            }
            return personas;
        }
    }
}
