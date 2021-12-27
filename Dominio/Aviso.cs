using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Protectora.Persistencia;

namespace Protectora.Dominio
{
    public class Aviso
    {
        private int? id;
        private string nombre;
        private string sexo;
        private string raza;
        private int tamanio;
        private string descripcionAnimal;
        private string descripcionAdicional;
        private string foto;
        private DateTime fechaPerdida;
        private string zonaPerdida;
        private int idDuenio;
        private AvisoDAO aviDAO;

        public int? Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public string Raza { get => raza; set => raza = value; }
        public int Tamanio { get => tamanio; set => tamanio = value; }
        public string DescripcionAnimal { get => descripcionAnimal; set => descripcionAnimal = value; }
        public string DescripcionAdicional { get => descripcionAdicional; set => descripcionAdicional = value; }
        public string Foto { get => foto; set => foto = value; }
        public DateTime FechaPerdida { get => fechaPerdida; set => fechaPerdida = value; }
        public string ZonaPerdida { get => zonaPerdida; set => zonaPerdida = value; }
        public int IdDuenio { get => idDuenio; set => idDuenio = value; }
        internal AvisoDAO AviDAO { get => aviDAO; set => aviDAO = value; }

        public Aviso()
        {
            this.AviDAO = new AvisoDAO();
        }

        public Aviso(int? id, string nombre, string sexo, string raza, int tamanio, string descripcionAnimal, string descripcionAdicional, string foto, DateTime fechaPerdida, string zonaPerdida, int idDuenio)
        {
            this.aviDAO = new AvisoDAO();
            Id = id;
            Nombre = nombre;
            Sexo = sexo;
            Raza = raza;
            Tamanio = tamanio;
            DescripcionAnimal = descripcionAnimal;
            DescripcionAdicional = descripcionAdicional;
            Foto = foto;
            FechaPerdida = fechaPerdida;
            ZonaPerdida = zonaPerdida;
            IdDuenio = idDuenio;
            AviDAO = aviDAO;
        }

        public void InsertarAviso()
        {

            this.AviDAO.insertar((Aviso)this.MemberwiseClone());
            //Console.Write(" ");
        }

        public void EliminarAviso()
        {
            this.AviDAO.eliminar((Aviso)this.MemberwiseClone());
            //Console.Write(" ");
        }

        public void ModificarAviso()
        {
            this.AviDAO.actualizar((Aviso)this.MemberwiseClone());
            Console.Write(" ");
        }


        public List<Aviso> LeerTodosAvisos()
        {
            List<Aviso> arrayAvisos = new List<Aviso>();

            AvisoDAO aviDao = new AvisoDAO();
            arrayAvisos = aviDao.leerTodas();
            Console.Write(" ");

            return arrayAvisos;
        }


    }
}
