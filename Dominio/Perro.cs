using System;
using Protectora.Persistencia;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Protectora.Dominio;

namespace Protectora
{
    public class Perro : Animal
    {
        private string raza;
        
         public Perro(): base()
        {
        }

        public Perro(int id, string nombre, string sexo, int tamanio, int peso, int edad, DateTime fechaEntrada, string foto, string enlace, string descripcion, string estado, int apadrinado, string raza) : base(id, nombre, sexo, tamanio, peso, edad, fechaEntrada, foto, enlace, descripcion, estado, apadrinado)
        //public Perro(string raza) : base()
        {
            this.raza = raza;
        }
        /*
        public Perro(int idR, String nR, String sexoR, String razaR, int tamanioR,
             int pesoR, int edadR, DateTime fechaEntradaR, String fotoR, 
             String enlaceR, String descripcionR,  String estadoR, int apadrinadoR)
        {
            id = idR;
            nombre = nR;
            sexo = sexoR;
            raza = razaR;
            tamanio = tamanioR;
            peso = pesoR;
            edad = edadR;
            fechaEntrada = fechaEntradaR;
            foto = fotoR;
            enlace = enlaceR;
            descripcion = descripcionR;
            estado = estadoR;
            apadrinado = apadrinadoR;
        }*/


        public List<Perro> LeerTodosAnimales()
        {
            List<Perro> arrayAnimales = new List<Perro>();
            AnimalDAO aniDao = new AnimalDAO();
            arrayAnimales = aniDao.LeerTodosAnimales();
            Console.Write(" ");

            return arrayAnimales;
        }

    }
}
