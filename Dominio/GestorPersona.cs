using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Dominio
{
    class GestorPersona
    {
        public static Padrino obtenerPadrino(Padrino padrino)
        {
            padrino.leerDatoXId();
            if (padrino.PadDAO.padrinos.Count != 0)
            {
                return padrino.PadDAO.padrinos[0];
            }
            return null;

        }

        public static int addPadrino(Padrino padrino, Perro perro)
        {
            return (int)padrino.InsertarPadrino().Id;

        }

        public static void modificarPadrino(Padrino padrino, Perro perro)
        {
            padrino.actualizarDato();
        }

        public static Socio obtenerSocio(Socio socio)
        {
            socio.leerDatoXName();
            if (socio.SocDAO.socios.Count != 0)
            {
                return socio.SocDAO.socios[0];
            }
            return null;

        }
        public static List<Socio> obtenerTodosSocios()
        {
            Socio socio = new Socio();
            socio.leerTodosDatos();
            if (socio.SocDAO.socios.Count != 0)
            {
                return socio.SocDAO.socios;
            }
            return null;

        }

        public static void crearSocio(Socio socio)
        {
            socio.insertarDato();
        }

        public static void modificarSocio(Socio socio)
        {
            socio.actualizarDato();
        }

        public static void eliminarSocio(Socio socio)
        {
            socio.eliminarDato();
        }

        public static Voluntario obtenerVoluntarioName(Voluntario voluntario)
        {
            voluntario.leerDatoXName();
            if (voluntario.VolDAO.voluntarios.Count != 0)
            {
                return voluntario.VolDAO.voluntarios[0];
            }
            return null;

        }
        public static List<Voluntario> obtenerTodosVoluntarios()
        {
            Voluntario voluntario = new Voluntario();
            voluntario.leerTodosDatos();
            if (voluntario.VolDAO.voluntarios.Count != 0)
            {
                return voluntario.VolDAO.voluntarios;
            }
            return null;

        }
        public static void crearVoluntario(Voluntario voluntario)
        {
            voluntario.insertarDato();
        }

        public static void modificarVoluntario(Voluntario voluntario)
        {
            voluntario.actualizarDato();
        }

        public static void eliminarVoluntario(Voluntario voluntario)
        {
            voluntario.eliminarDato();
        }

        public static List<Persona> obtenerTodasPersonas()
        {
            Persona persona = new Persona();
            persona.leerTodosDatos();
            if (persona.PerDAO.personas.Count != 0)
            {
                return persona.PerDAO.personas;
            }
            return null;

        }
        public static void crearPersona(Persona persona)
        {
            persona.InsertarPersona();
        }

        public static void modificarPersona(Persona persona)
        {
            persona.actualizarDato();
        }

        public static void eliminarPersona(Persona persona)
        {
            persona.eliminarDato();
        }

        public static Persona obtenerPersona(Persona persona)
        {
            persona.leerDatoXId();
            if (persona.PerDAO.personas.Count != 0)
            {
                return persona.PerDAO.personas[0];
            }
            return null;

        }

        public static Persona obtenerPersonaName(Persona persona)
        {
            persona.leerDatoXName();
            if (persona.PerDAO.personas.Count != 0)
            {
                return persona.PerDAO.personas[0];
            }
            return null;

        }

        public static int addPersona(Persona persona)
        {
            return (int)persona.InsertarPersona().Id;

        }
    }
}
