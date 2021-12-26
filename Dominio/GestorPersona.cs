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
    }
}
