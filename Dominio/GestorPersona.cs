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
            padrino.LeerunPadrino();
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
            padrino.ModificarPadrino();
        }

        public static List<Socio> obtenerTodosSocios()
        {
            Socio socio = new Socio();
            socio.LeerTodosSocios();
            if (socio.SocDAO.socios.Count != 0)
            {
                return socio.SocDAO.socios;
            }
            return null;

        }

        public static void crearSocio(Socio socio)
        {
            socio.InsertarSocio();
        }

        public static void modificarSocio(Socio socio)
        {
            socio.ModificarSocio();
        }

        public static void eliminarSocio(Socio socio)
        {
            socio.EliminarSocio();
        }


        public static List<Voluntario> obtenerTodosVoluntarios()
        {
            Voluntario voluntario = new Voluntario();
            voluntario.LeerTodosVoluntarios();
            if (voluntario.VolDAO.voluntarios.Count != 0)
            {
                return voluntario.VolDAO.voluntarios;
            }
            return null;

        }
        public static void crearVoluntario(Voluntario voluntario)
        {
            voluntario.InsertarVoluntario();
        }

        public static void modificarVoluntario(Voluntario voluntario)
        {
            voluntario.ModificarVoluntario();
        }

        public static void eliminarVoluntario(Voluntario voluntario)
        {
            voluntario.EliminarVoluntario();
        }

        public static List<Persona> obtenerTodasPersonas()
        {
            Persona persona = new Persona();
            persona.LeerTodasPersonas();
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
            persona.ModificarPersona();
        }

        public static void eliminarPersona(Persona persona)
        {
            persona.EliminarPersona();
        }

        public static Persona obtenerPersona(Persona persona)
        {
            persona.LeerPersona();
            if (persona.PerDAO.personas.Count != 0)
            {
                return persona.PerDAO.personas[0];
            }
            return null;

        }

        public static Persona obtenerPersonaName(Persona persona)
        {
            persona.LeerPersonaName();
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
