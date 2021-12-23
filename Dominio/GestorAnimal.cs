﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Dominio
{
    class GestorAnimal
    {

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
    }
}