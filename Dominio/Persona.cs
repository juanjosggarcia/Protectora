using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Dominio
{
    public class Persona
    {
        protected int id;
        protected string nombreCompleto;
        protected string correo;
        protected string dni;
        protected int telefono;

        public Persona()
        {
        }

        public Persona(int id, string nombreCompleto, string correo, string dni, int telefono)
        {
            this.id = id;
            this.nombreCompleto = nombreCompleto;
            this.correo = correo;
            this.dni = dni;
            this.telefono = telefono;
        }

        public Persona(string nombreCompleto, string correo, string dni, int telefono)
        {
            this.nombreCompleto = nombreCompleto;
            this.correo = correo;
            this.dni = dni;
            this.telefono = telefono;
        }



        public int getid()
        {
            return this.id;
        }
        public void setid(int id)
        {
            this.id = id;
        }

        public string getNombre()
        {
            return this.nombreCompleto;
        }
        public void setNombre(string nombreCompleto)
        {
            this.nombreCompleto = nombreCompleto;
        }

        public string getcorreo()
        {
            return this.correo;
        }
        public void setcorreo(string correo)
        {
            this.correo = correo;
        }

        public string getdni()
        {
            return this.dni;
        }
        public void setdni(string dni)
        {
            this.dni = dni;
        }

        public int gettelefono()
        {
            return this.telefono;
        }
        public void settelefono(int telefono)
        {
            this.telefono = telefono;
        }

    }
}
