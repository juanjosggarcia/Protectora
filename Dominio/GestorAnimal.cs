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
            perro.leerDatoXName();
            if (perro.AniDAO.animales.Count != 0)
            {
                return perro.AniDAO.animales[0];
            }
            return null;

        }

        public static List<Perro> obtenerTodosPerros()
        {
            Perro perro = new Perro();
            perro.leerTodosDatos();
            if (perro.AniDAO.animales.Count != 0)
            {
                return perro.AniDAO.animales;
            }
            return null;

        }

        public static void crearPerro(Perro perro)
        {
            perro.insertarDato();

        }

        public static void modificarPerro(Perro perro)
        {
            perro.actualizarDato();
        }

        public static void eliminarPerro(Perro perro)
        {
            perro.eliminarDato();
        }

        public static List<Aviso> obtenerTodosAvisos()
        {
            Aviso aviso = new Aviso();
            aviso.leerTodosDatos();
            if (aviso.AviDAO.avisos.Count != 0)
            {
                return aviso.AviDAO.avisos;
            }
            return null;

        }

        public static void crearAviso(Aviso aviso)
        {
            aviso.insertarDato();

        }

        public static void modificarAviso(Aviso aviso)
        {
            aviso.actualizarDato();
        }

        public static void eliminarAviso(Aviso aviso)
        {
            aviso.eliminarDato();
        }
    }
}
