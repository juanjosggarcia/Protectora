using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Dominio
{
    interface IDTO<T>
    {
        List<T> leerTodosDatos();
        List<T> leerDatoXName();
        T leerDatoXId();
        int insertarDato();
        int actualizarDato();
        int eliminarDato();

    }
}
