using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Protectora.Persistencia;

namespace Protectora.Dominio
{
    public class Socio : Persona, IDTO<Socio>
    {

        private string datosBancarios;
        private int cuantiaAyuda;
        private string formaPago;
        private string foto;
        private SocioDAO socDAO;

        public string DatosBancarios { get => datosBancarios; set => datosBancarios = value; }
        public int CuantiaAyuda { get => cuantiaAyuda; set => cuantiaAyuda = value; }
        public string FormaPago { get => formaPago; set => formaPago = value; }
        public string Foto { get => foto; set => foto = value; }
        internal SocioDAO SocDAO { get => socDAO; set => socDAO = value; }

        public Socio() : base()
        {
            this.SocDAO = new SocioDAO();
        }

        public Socio(Nullable<int> id, string nombreCompleto, string correo, string dni, int telefono,
            string datosBancarios, int cuantiaAyuda, string formaPago, string foto) : base(id, nombreCompleto, correo, dni, telefono)
        {
            this.SocDAO = new SocioDAO();
            this.DatosBancarios = datosBancarios;
            this.CuantiaAyuda = cuantiaAyuda;
            this.FormaPago = formaPago;
            this.foto = foto;
        }

        /////////////////////////////////////////////////////////////// PARTE DATA TRANSFER OBJECT ///////////////////////////////////////////////////////////////

        public new List<Socio> leerTodosDatos()
        {
            return SocDAO.leerTodas();
        }
        public new Socio leerDatoXName()
        {
            throw new NotImplementedException();
        }
        public new Socio leerDatoXId()
        {
            throw new NotImplementedException();
        }

        public new int insertarDato()
        {
            return this.SocDAO.insertar(this);
        }
        public new int actualizarDato()
        {
            return this.SocDAO.actualizar(this);
        }
        public new int eliminarDato()
        {
            return this.SocDAO.eliminar(this);
        }

    }
}