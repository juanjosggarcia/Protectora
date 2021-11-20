using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Dominio
{
    class Persona
    {
        protected int id;
        protected string nombreCompleto;
        protected string correo;
        protected string dni;
        protected int telefono;

        public Persona(int id, string nombreCompleto, string correo, string dni, int telefono)
        {
            this.id = id;
            this.nombreCompleto = nombreCompleto;
            this.correo = correo;
            this.dni = dni;
            this.telefono = telefono;
        }

        public Persona()
        {
        }

    }
}
