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
    }
}
