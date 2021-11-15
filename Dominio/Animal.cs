using System;
using Protectora.Persistencia;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora
{
    class Animales
    {
        private int id;
        private String nombre;
        private String sexo;
        private String raza;
        private int tamanio;
        private int peso;
        private int edad;
        private DateTime fechaEntrada;
        private String foto;
        private String enlace;
        private String descripcion;
        private String estado;
        private int apadrinado;

        public void set(int idR, String nR, String sexoR, String razaR, int tamanioR,
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
        }


        public List<Animales> LeerTodosAnimales()
        {
            List<Animales> arrayAnimales = new List<Animales>();
            AnimalDAO aniDao = new AnimalDAO();
            arrayAnimales = aniDao.LeerTodosAnimales();
            Console.Write(" ");

            return arrayAnimales;
        }

    }
}
