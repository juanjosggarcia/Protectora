using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Protectora.Persistencia;

namespace Protectora.Dominio
{
    public class Padrino : Persona
    {

        private string datosBancarios;
        private int importeMensual;
        private string formaPago;
        private DateTime fechaEntrada;
        private PadrinoDAO padDAO;

        public Padrino() : base()
        {
            this.padDAO = new PadrinoDAO();
        }

        public Padrino(string nombreCompleto, string correo, string dni, int telefono,
            string datosBancarios, int importeMensual, string formaPago, DateTime fechaEntrada) : base(nombreCompleto, correo, dni, telefono)
        {
            this.padDAO = new PadrinoDAO();
            this.datosBancarios = datosBancarios;
            this.importeMensual = importeMensual;
            this.formaPago = formaPago;
            this.fechaEntrada = fechaEntrada;

        }

        public Padrino(int id, string nombreCompleto, string correo, string dni, int telefono,
            string datosBancarios, int importeMensual, string formaPago, DateTime fechaEntrada) : base(id, nombreCompleto, correo, dni, telefono)
        {
            this.padDAO = new PadrinoDAO();
            this.datosBancarios = datosBancarios;
            this.importeMensual = importeMensual;
            this.formaPago = formaPago;
            this.fechaEntrada = fechaEntrada;

        }

        public void InsertarPadrino()
        {
            this.padDAO.InsertarPadrino((Padrino)this.MemberwiseClone());
            Console.Write(" ");
        }

        public void EliminarPadrino()
        {
            this.padDAO.EliminarPadrino((Padrino)this.MemberwiseClone());
            Console.Write(" ");
        }

        public void ModificarPadrino()
        {
            this.padDAO.ModificarPadrino((Padrino)this.MemberwiseClone());
            Console.Write(" ");
        }

        public Padrino LeerunPadrino(int padrino)
        {
            return this.padDAO.LeerunPadrino(padrino);
        }
        
        public List<Padrino> LeerTodosPadrino()
        {
            List<Padrino> arrayPadrino = new List<Padrino>();
            PadrinoDAO padDAO = new PadrinoDAO();
            arrayPadrino = padDAO.LeerTodosPadrino();
            Console.Write(" ");

            return arrayPadrino;
        }

        public string getdatosBancarios()
        {
            return this.datosBancarios;
        }
        public void setdatosBancarios(string datosBancarios)
        {
            this.datosBancarios = datosBancarios;
        }
        public int getimporteMensual()
        {
            return this.importeMensual;
        }
        public void setcuantiaAyuda(int importeMensual)
        {
            this.importeMensual = importeMensual;
        }

        public string getformaPago()
        {
            return this.formaPago;
        }
        public void setformaPago(string formaPago)
        {
            this.formaPago = formaPago;
        }
        public DateTime getfechaEntrada()
        {
            return this.fechaEntrada;
        }
        public void setfechaEntrada(DateTime fechaEntrada)
        {
            this.fechaEntrada = fechaEntrada;
        }
    }
}