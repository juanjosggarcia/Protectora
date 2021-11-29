using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Dominio
{
    public class Animal
    {
        public int? id;
        public string nombre;
        public string sexo;
        public int tamanio;
        public int peso;
        public int edad;
        public DateTime fechaEntrada;
        public string foto;
        public string enlace;
        public string descripcion;
        public string estado;
        public int apadrinado;

        protected int? Id { get => id; set => id = value; }
        protected string Nombre { get => nombre; set => nombre = value; }
        protected string Sexo { get => sexo; set => sexo = value; }
        protected int Tamanio { get => tamanio; set => tamanio = value; }
        protected int Peso { get => peso; set => peso = value; }
        protected int Edad { get => edad; set => edad = value; }
        protected DateTime FechaEntrada { get => fechaEntrada; set => fechaEntrada = value; }
        protected string Foto { get => foto; set => foto = value; }
        protected string Enlace { get => enlace; set => enlace = value; }
        protected string Descripcion { get => descripcion; set => descripcion = value; }
        protected string Estado { get => estado; set => estado = value; }
        protected int Apadrinado { get => apadrinado; set => apadrinado = value; }

        public Animal()
        {
        }


        public Animal(Nullable<int> id, string nombre, string sexo, int tamanio, int peso, int edad, DateTime fechaEntrada, string foto, string enlace, string descripcion, string estado, int apadrinado)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Sexo = sexo;
            this.Tamanio = tamanio;
            this.Peso = peso;
            this.Edad = edad;
            this.FechaEntrada = fechaEntrada;
            this.Foto = foto;
            this.Enlace = enlace;
            this.Descripcion = descripcion;
            this.Estado = estado;
            this.Apadrinado = apadrinado;
        }

    }
}
