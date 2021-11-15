using System;
using Protectora.Persistencia;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora
{
    class Avisos
    {
        public int id;
        public String nombre;
        public String sexo;
        public String raza;
        public int tamanio;
        public String descripcionAnimal;
        public String descripcionLocalizacion;
        public String foto;
        public DateTime fechaPerdida;
        public String datosDuenios;



        public List<Avisos> LeerTodosAvisos()
        {
            List<Avisos> arrayAvisos = new List<Avisos>();
            AvisosDAO aviDao = new AvisosDAO();
            arrayAvisos = aviDao.LeerTodosAvisos();
            Console.Write(" ");

            return arrayAvisos;
        }

    }
} 