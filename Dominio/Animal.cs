using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Dominio
{
    public class Animal
    {
        private int? id;
        private string nombre;
        private string sexo;
        private int tamanio;
        private int peso;
        private int edad;
        private DateTime fechaEntrada;
        private string foto;
        private string enlace;
        private string descripcion;
        private string estado;
        private int apadrinado;

        public int? Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public int Tamanio { get => tamanio; set => tamanio = value; }
        public int Peso { get => peso; set => peso = value; }
        public int Edad { get => edad; set => edad = value; }
        public DateTime FechaEntrada { get => fechaEntrada; set => fechaEntrada = value; }
        public string Foto { get => foto; set => foto = value; }
        public string Enlace { get => enlace; set => enlace = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Estado { get => estado; set => estado = value; }
        public int Apadrinado { get => apadrinado; set => apadrinado = value; }

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
