using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Dominio
{
    public class Persona
    {
        private int id;
        private string nombreCompleto;
        private string correo;
        private string dni;
        private int telefono;

        protected int Id { get => id; set => id = value; }
        protected string NombreCompleto { get => nombreCompleto; set => nombreCompleto = value; }
        protected string Correo { get => correo; set => correo = value; }
        protected string Dni { get => dni; set => dni = value; }
        protected int Telefono { get => telefono; set => telefono = value; }

        public Persona()
        {
        }

        public Persona(int id, string nombreCompleto, string correo, string dni, int telefono)
        {
            this.Id = id;
            this.NombreCompleto = nombreCompleto;
            this.Correo = correo;
            this.Dni = dni;
            this.Telefono = telefono;
        }

        public Persona(string nombreCompleto, string correo, string dni, int telefono)
        {
            this.NombreCompleto = nombreCompleto;
            this.Correo = correo;
            this.Dni = dni;
            this.Telefono = telefono;
        }



        public int getid()
        {
            return this.Id;
        }
        public void setid(int id)
        {
            this.Id = id;
        }

        public string getNombre()
        {
            return this.NombreCompleto;
        }
        public void setNombre(string nombreCompleto)
        {
            this.NombreCompleto = nombreCompleto;
        }

        public string getcorreo()
        {
            return this.Correo;
        }
        public void setcorreo(string correo)
        {
            this.Correo = correo;
        }

        public string getdni()
        {
            return this.Dni;
        }
        public void setdni(string dni)
        {
            this.Dni = dni;
        }

        public int gettelefono()
        {
            return this.Telefono;
        }
        public void settelefono(int telefono)
        {
            this.Telefono = telefono;
        }

    }
}
