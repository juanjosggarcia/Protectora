using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Protectora.Persistencia;

namespace Protectora.Dominio
{
    class Socio : Persona
    {
      
        private String datosBancarios;
        private int importeMensual;
        private String formaPago;


        public Socio():base()
        {

        }

        public Socio(int id, String nombreCompleto, String dni, int telefono, String correo,
            String datosBancariosR, int importeMensualR, String formaPagoR) : base(id, nombreCompleto, correo, dni, telefono)
        {

            datosBancarios= datosBancariosR;
            importeMensual= importeMensualR;
            formaPago = formaPagoR;

        }

        public List<Socio> LeerTodosSocios()
        {
            List<Socio> arraySocios = new List<Socio>();
            SocioDAO socDAO = new SocioDAO();
            arraySocios = socDAO.LeerTodosSocios();
            Console.Write(" ");

            return arraySocios;
        }
    }
}