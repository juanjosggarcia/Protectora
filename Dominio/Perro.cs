using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Dominio
{
    public class Perro
    {
        public int id;
        public string nombre;
        public string sexo;
        public int tamanio;
        public int peso;
        public int edad;
        public DateTime entrada;
        public string foto;
        public string descripcion;
        public string estado;
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public int Tamanio { get; set; }
        public string Estado { get; set; }
        public int Edad { get; set; }
        public int Peso { get; set; }
        public DateTime Entrada { get; set; }
        public string Imagen { get; set; }
        public string Foto { get; set; }

        public string Descripcion { get; set; }

        public Perro(int id, string nombre, string sexo, int tamanio, int peso, int edad, DateTime entrada, string foto, string descripcion, string estado)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Sexo = sexo;
            this.Tamanio = tamanio;
            this.Peso = peso;
            this.Edad = edad;
            this.Entrada = entrada;
            this.Foto = foto;
            this.Descripcion = descripcion;
            this.Estado = estado;
            
        }

        public Perro()
        {
        }
    }

}

