using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Protectora.Persistencia;

namespace Protectora.Dominio
{
    class Voluntario : Persona
    {
        private string foto;
        private string horario;
        private string zonaDisponibilidad;
        private VoluntarioDAO volDAO;
        public Voluntario() : base()
        {
            this.volDAO = new VoluntarioDAO();
        }


        public Voluntario(int id, string nombreCompleto, string correo, string dni, int telefono,
            string foto, string horario, string zonaDisponibilidad) : base(id, nombreCompleto, correo, dni, telefono)
        {
            this.volDAO = new VoluntarioDAO();
            this.foto = foto;
            this.horario = horario;
            this.zonaDisponibilidad = zonaDisponibilidad;
        }

        public Voluntario(string nombreCompleto, string correo, string dni, int telefono,
            string foto, string horario, string zonaDisponibilidad) : base(nombreCompleto, correo, dni, telefono)
        {
            this.volDAO = new VoluntarioDAO();
            this.foto = foto;
            this.horario = horario;
            this.zonaDisponibilidad = zonaDisponibilidad;
        }

        public void InsertarVoluntario()
        {
            this.volDAO.InsertarVoluntario((Voluntario)this.MemberwiseClone());
            Console.Write(" ");
        }

        public void EliminarVoluntario()
        {
            this.volDAO.EliminarVoluntario((Voluntario)this.MemberwiseClone());
            Console.Write(" ");
        }

        public void ModificarVoluntario()
        {
            this.volDAO.ModificarVoluntario((Voluntario)this.MemberwiseClone());
            Console.Write(" ");
        }

        public List<Voluntario> LeerTodosVoluntarios()
        {
            List<Voluntario> arrayVoluntarios = new List<Voluntario>();

            VoluntarioDAO volDao = new VoluntarioDAO();
            arrayVoluntarios = volDao.LeerTodosVoluntarios();

            Console.Write(" ");

            return arrayVoluntarios;
        }

        public string getfoto()
        {
            return this.foto;
        }
        public void setfoto(string foto)
        {
            this.foto = foto;
        }
        public string gethorario()
        {
            return this.horario;
        }
        public void sethorario(string horario)
        {
            this.horario = horario;
        }
        public string getzonaDisponibilidad()
        {
            return this.zonaDisponibilidad;
        }
        public void setzonaDisponibilidad(string zonaDisponibilidad)
        {
            this.zonaDisponibilidad = zonaDisponibilidad;
        }
    }
}