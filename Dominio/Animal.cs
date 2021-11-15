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
        public int id;
        public String nombre;
        public String sexo;
        public String raza;
        public int tamanio;
        public int peso;
        public int edad;
        public DateTime fechaEntrada;
        public String foto;
        public String enlace;
        public String descripcion;
        public String estado;
        public int apadrinado;
       
        
        
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
