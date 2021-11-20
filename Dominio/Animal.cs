using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Dominio
{
    public class Animal
    {
        protected int id;
        protected string nombre;
        protected string sexo;
        protected int tamanio;
        protected int peso;
        protected int edad;
        protected DateTime fechaEntrada;
        protected string foto;
        protected string enlace;
        protected string descripcion;
        protected string estado;
        protected int apadrinado;

        public Animal(int id, string nombre, string sexo, int tamanio, int peso, int edad, DateTime fechaEntrada, string foto, string enlace, string descripcion, string estado, int apadrinado)
        {
            this.id = id;
            this.nombre = nombre;
            this.sexo = sexo;
            this.tamanio = tamanio;
            this.peso = peso;
            this.edad = edad;
            this.fechaEntrada = fechaEntrada;
            this.foto = foto;
            this.enlace = enlace;
            this.descripcion = descripcion;
            this.estado = estado;
            this.apadrinado = apadrinado;
        }

    }
}
