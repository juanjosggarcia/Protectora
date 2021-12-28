using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Protectora.Persistencia;

namespace Protectora.Dominio
{
    public class Voluntario : Persona, IDTO<Voluntario>
    {
        private string foto;
        private string horario;
        private string zonaDisponibilidad;
        private VoluntarioDAO volDAO;

        public string Foto { get => foto; set => foto = value; }
        public string Horario { get => horario; set => horario = value; }
        public string ZonaDisponibilidad { get => zonaDisponibilidad; set => zonaDisponibilidad = value; }
        internal VoluntarioDAO VolDAO { get => volDAO; set => volDAO = value; }

        public Voluntario() : base()
        {
            this.VolDAO = new VoluntarioDAO();
        }

        public Voluntario(Nullable<int> id, string nombreCompleto, string correo, string dni, int telefono,
            string foto, string horario, string zonaDisponibilidad) : base(id, nombreCompleto, correo, dni, telefono)
        {
            this.VolDAO = new VoluntarioDAO();
            this.Foto = foto;
            this.Horario = horario;
            this.ZonaDisponibilidad = zonaDisponibilidad;
        }

        /////////////////////////////////////////////////////////////// PARTE DATA TRANSFER OBJECT ///////////////////////////////////////////////////////////////

        public new List<Voluntario> leerTodosDatos()
        {
            return VolDAO.leerTodas();
        }

        public new Voluntario leerDatoXName()
        {
            throw new NotImplementedException();
        }

        public new Voluntario leerDatoXId()
        {
            throw new NotImplementedException();
        }

        public new int insertarDato()
        {
            return this .VolDAO.insertar(this);
        }
        public new int eliminarDato()
        {
            return this.VolDAO.eliminar(this);
        }
        public new int actualizarDato()
        {
            return this.VolDAO.actualizar(this);
        }


    }
}