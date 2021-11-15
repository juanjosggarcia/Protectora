using System;
using Protectora.Persistencia;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora
{
    class Socios
    {
        public int id;
        public String nombreCompleto;
        public String dni;
        public int telefono;
        public String correo;
        public String datosBancarios;
        public int importeMensual;
        public String formaPago;




        public List<Socios> LeerTodosSocios()
        {
            List<Socios> arraySocios = new List<Socios>();
            Socios socDAO = new SociosDAO();
            arraySocios = socDAO.LeerTodosSocios();
            Console.Write(" ");

            return arraySocios;
        }

    }
}