﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Persistencia
{
    interface IDAO<T>
    {
        List<T> leerTodas();
        List<T> leerName(T obj);
        T leerId(T obj);
        int insertar(T obj);
        int actualizar(T obj);
        int eliminar(T obj);

    }
}
