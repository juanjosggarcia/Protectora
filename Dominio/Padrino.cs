using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Protectora.Persistencia;

namespace Protectora.Dominio
{
    public class Padrino : Persona, IDTO<Padrino>
    {

        private string datosBancarios;
        private int importeMensual;
        private string formaPago;
        private DateTime fechaEntrada;
        private PadrinoDAO padDAO;

        public string DatosBancarios { get => datosBancarios; set => datosBancarios = value; }
        public int ImporteMensual { get => importeMensual; set => importeMensual = value; }
        public string FormaPago { get => formaPago; set => formaPago = value; }
        public DateTime FechaEntrada { get => fechaEntrada; set => fechaEntrada = value; }
        internal PadrinoDAO PadDAO { get => padDAO; set => padDAO = value; }

        public Padrino() : base()
        {
            this.PadDAO = new PadrinoDAO();
        }

        public Padrino(Nullable<int> id, string nombreCompleto, string correo, string dni, int telefono,
            string datosBancarios, int importeMensual, string formaPago, DateTime fechaEntrada) : base(id, nombreCompleto, correo, dni, telefono)
        {
            this.PadDAO = new PadrinoDAO();
            this.DatosBancarios = datosBancarios;
            this.ImporteMensual = importeMensual;
            this.FormaPago = formaPago;
            this.FechaEntrada = fechaEntrada;
        }

        /////////////////////////////////////////////////////////////// PARTE DATA TRANSFER OBJECT ///////////////////////////////////////////////////////////////

        public new List<Padrino> leerTodosDatos()
        {
            return PadDAO.leerTodas();
        }
        public new List<Padrino> leerDatoXName()
        {
            throw new NotImplementedException();
        }
        public new Padrino leerDatoXId()
        {
            return this.PadDAO.leerId(this);
        }

        public new int insertarDato()
        {
            throw new NotImplementedException();
        }
        public new int actualizarDato()
        {
            return this.PadDAO.actualizar(this);
        }
        public new int eliminarDato()
        {
            return this.PadDAO.eliminar(this);
        }

        public Padrino InsertarPadrino()
        {
            this.PadDAO.insertar(this);

            return padDAO.leerName(this)[0];
        }

    }
}