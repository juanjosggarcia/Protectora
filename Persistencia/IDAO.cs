using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Persistencia
{
    interface IDAO<T>
    {
        /*
        List<T> ts
        {
            get;
            set;
        }
        */
        List<T> leerTodas();
        T leer(ref T obj);
        int insertar(ref T obj);
        int actualizar(ref T obj);
        int eliminar(ref T  obj);

    }
}
