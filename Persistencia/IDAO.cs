using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Persistencia
{
    interface IDAO
    {
        //List<T> leerTodas<T>();
        //T leer<T>(T obj);
        void leerTodas<T>();
        void leer<T>(ref T obj);
        int insertar<T>(T obj);
        int actualizar<T>(T obj);
        int eliminar<T>(T obj);

    }
}
