using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Protectora.Persistencia;

namespace Protectora.Dominio
{
    class Socio
    {
      
        private int id;
        private String nombreCompleto;
        private String dni;
        private int telefono;
        private String correo;
        private String datosBancarios;
        private int importeMensual;
        private String formaPago;


        public Socio()
        {

        }

        public Socio(int idR, String nCR, String dniR, int telefonoR, String correoR, String datosBancariosR, int importeMensualR, String formaPagoR)
        {
            id = idR;
            nombreCompleto = nCR;
            dni=dniR;
            telefono= telefonoR;
            correo= correoR;
            datosBancarios= datosBancariosR;
            importeMensual= importeMensualR;
            formaPago = formaPagoR;

        }

        public List<Socio> LeerTodosSocios()
        {
            List<Socio> arraySocios = new List<Socio>();
            SociosDAO socDAO = new SociosDAO();
            arraySocios = socDAO.LeerTodosSocios();
            Console.Write(" ");

            return arraySocios;
        }
    }
}