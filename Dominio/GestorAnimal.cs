using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Dominio
{
    class GestorAnimal
    {
        public static Perro obtenerPerro(Perro perro)
        {
            perro.LeerPerroName();
            if (perro.AniDAO.animales.Count != 0)
            {
                return perro.AniDAO.animales[0];
            }
            return null;

        }

        public static List<Perro> obtenerTodosPerros()
        {
            Perro perro = new Perro();
            perro.LeerTodosAnimales();
            if (perro.AniDAO.animales.Count != 0)
            {
                return perro.AniDAO.animales;
            }
            return null;

        }

        public static void crearPerro(Perro perro)
        {
            perro.InsertarPerro();

        }

        public static void modificarPerro(Perro perro)
        {
            perro.ModificarPerro();
        }

        public static void eliminarPerro(Perro perro)
        {
            perro.EliminarPerro();
        }

        public static List<Aviso> obtenerTodosAvisos()
        {
            Aviso aviso = new Aviso();
            aviso.LeerTodosAvisos();
            if (aviso.AviDAO.avisos.Count != 0)
            {
                return aviso.AviDAO.avisos;
            }
            return null;

        }

        public static void crearAviso(Aviso aviso)
        {
            aviso.InsertarAviso();

        }

        public static void modificarAviso(Aviso aviso)
        {
            aviso.ModificarAviso();
        }

        public static void eliminarAviso(Aviso aviso)
        {
            aviso.EliminarAviso();
        }
    }
}
