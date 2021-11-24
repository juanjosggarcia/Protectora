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

        public Animal()
        {
        }

        public Animal(string nombre, string sexo, int tamanio, int peso, int edad, DateTime fechaEntrada, string foto, string enlace, string descripcion, string estado, int apadrinado)
        {
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
            return this.nombre;
        }
        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public string getsexo()
        {
            return this.sexo;
        }
        public void setsexo(string sexo)
        {
            this.sexo = sexo;
        }

        public int gettamanio()
        {
            return this.tamanio;
        }
        public void settamanio(int tamanio)
        {
            this.tamanio = tamanio;
        }

        public int getpeso()
        {
            return this.peso;
        }
        public void setpeso(int peso)
        {
            this.peso = peso;
        }

        public int getedad()
        {
            return this.edad;
        }
        public void setedad(int edad)
        {
            this.edad = edad;
        }

        public DateTime getfechaEntrada()
        {
            return this.fechaEntrada;
        }
        public void setfechaEntrada(DateTime fechaEntrada)
        {
            this.fechaEntrada = fechaEntrada;
        }

        public string getfoto()
        {
            return this.foto;
        }
        public void setfoto(string foto)
        {
            this.foto = foto;
        }

        public string getenlace()
        {
            return this.enlace;
        }
        public void setenlace(string enlace)
        {
            this.enlace = enlace;
        }

        public string getdescripcion()
        {
            return this.descripcion;
        }
        public void setdescripcion(string descripcion)
        {
            this.descripcion = descripcion;
        }

        public string getestado()
        {
            return this.estado;
        }
        public void setestado(string estado)
        {
            this.estado = estado;
        }

        public int getapadrinado()
        {
            return this.apadrinado;
        }
        public void setapadrinado(int apadrinado)
        {
            this.apadrinado = apadrinado;
        }
    }
}
