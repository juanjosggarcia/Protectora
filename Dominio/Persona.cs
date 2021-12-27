using Protectora.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Dominio
{
    public class Persona
    {
        private int? id;
        private string nombreCompleto;
        private string correo;
        private string dni;
        private int telefono;
        private PersonaDAO perDAO;

        public int? Id { get => id; set => id = value; }
        public string NombreCompleto { get => nombreCompleto; set => nombreCompleto = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Dni { get => dni; set => dni = value; }
        public int Telefono { get => telefono; set => telefono = value; }

        internal PersonaDAO PerDAO { get => perDAO; set => perDAO = value; }

        public Persona()
        {
            this.PerDAO = new PersonaDAO();
        }

        public Persona(Nullable<int> id, string nombreCompleto, string correo, string dni, int telefono)
        {
            this.id = id;
            this.NombreCompleto = nombreCompleto;
            this.Correo = correo;
            this.Dni = dni;
            this.Telefono = telefono;
        }

        public void InsertarPersona()
        {
            this.PerDAO.insertar(this);
        }

        public void EliminarPersona()
        {
            this.PerDAO.eliminar(this);
        }

        public void ModificarPersona()
        {
            this.PerDAO.actualizar(this);
        }

        public List<Persona> LeerTodasPersonas()
        {
            return PerDAO.leerTodas();
        }

        public Persona LeerPersona()
        {
            return PerDAO.leer(this);
        }

    }
}
