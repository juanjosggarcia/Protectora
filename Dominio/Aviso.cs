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
        private string descripcionLocalizacion;
        private string foto;
        private DateTime fechaPerdida;
        private string datosDuenios;
        private AvisoDAO aviDAO;

        public int? Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public string Raza { get => raza; set => raza = value; }
        public int Tamanio { get => tamanio; set => tamanio = value; }
        public string DescripcionAnimal { get => descripcionAnimal; set => descripcionAnimal = value; }
        public string DescripcionLocalizacion { get => descripcionLocalizacion; set => descripcionLocalizacion = value; }
        public string Foto { get => foto; set => foto = value; }
        public DateTime FechaPerdida { get => fechaPerdida; set => fechaPerdida = value; }
        public string DatosDuenios { get => datosDuenios; set => datosDuenios = value; }
        internal AvisoDAO AviDAO { get => aviDAO; set => aviDAO = value; }

        public Aviso()
        {
            this.AviDAO = new AvisoDAO();
        }

        public Aviso(Nullable<int> idR, string nR, string sexoR, string razaR
            , int tamanioR, string descripcionAnimalR, string descripcionLocalizacionR,
            string fotoR, DateTime fechaPerdidaR, string datosDueniosR)
        {
            this.AviDAO = new AvisoDAO();
            Id = idR;
            Nombre = nR;
            Sexo = sexoR;
            Raza = razaR;
            Tamanio = tamanioR;
            DescripcionAnimal = descripcionAnimalR;
            DescripcionLocalizacion = descripcionLocalizacionR;
            Foto = fotoR;
            FechaPerdida = fechaPerdidaR;
            DatosDuenios = datosDueniosR;

        }
        public void InsertarAviso()
        {

            this.AviDAO.insertar((Aviso)this.MemberwiseClone());
            Console.Write(" ");
        }

        public void EliminarAviso()
        {
            this.AviDAO.eliminar((Aviso)this.MemberwiseClone());
            Console.Write(" ");
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
