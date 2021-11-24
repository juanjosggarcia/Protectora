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

        private string datosBancarios;
        private int cuantiaAyuda;
        private string formaPago;
        private SocioDAO socDAO;

        public Socio() : base()
        {
            this.socDAO = new SocioDAO();
        }

        public Socio(string nombreCompleto, string correo, string dni, int telefono,
            string datosBancarios, int cuantiaAyuda, string formaPago) : base(nombreCompleto, correo, dni, telefono)
        {
            this.socDAO = new SocioDAO();
            this.datosBancarios = datosBancarios;
            this.cuantiaAyuda = cuantiaAyuda;
            this.formaPago = formaPago;

        }

        public Socio(int id, string nombreCompleto, string correo, string dni, int telefono,
            string datosBancarios, int cuantiaAyuda, string formaPago) : base(id, nombreCompleto, correo, dni, telefono)
        {
            this.socDAO = new SocioDAO();
            this.datosBancarios = datosBancarios;
            this.cuantiaAyuda = cuantiaAyuda;
            this.formaPago = formaPago;

        }

        public void InsertarSocio()
        {
            this.socDAO.InsertarSocio((Socio)this.MemberwiseClone());
            Console.Write(" ");
        }

        public void EliminarSocio()
        {
            this.socDAO.EliminarSocio((Socio)this.MemberwiseClone());
            Console.Write(" ");
        }

        public void ModificarSocio()
        {
            this.socDAO.ModificarSocio((Socio)this.MemberwiseClone());
            Console.Write(" ");
        }

        public List<Socio> LeerTodosSocios()
        {
            List<Socio> arraySocios = new List<Socio>();
            SocioDAO socDAO = new SocioDAO();
            arraySocios = socDAO.LeerTodosSocios();
            Console.Write(" ");

            return arraySocios;
        }

        public string getdatosBancarios()
        {
            return this.datosBancarios;
        }
        public void setdatosBancarios(string datosBancarios)
        {
            this.datosBancarios = datosBancarios;
        }
        public int getcuantiaAyuda()
        {
            return this.cuantiaAyuda;
        }
        public void setcuantiaAyuda(int cuantiaAyuda)
        {
            this.cuantiaAyuda = cuantiaAyuda;
        }

        public string getformaPago()
        {
            return this.formaPago;
        }
        public void setformaPago(string formaPago)
        {
            this.formaPago = formaPago;
        }

    }
}