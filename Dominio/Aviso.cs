using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Protectora.Persistencia;

namespace Protectora.Dominio
{
    class Aviso
    {
        private int id;
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

        public Aviso()
        {
            this.aviDAO = new AvisoDAO();
        }

        public Aviso(string nR, string sexoR, string razaR
            , int tamanioR, string descripcionAnimalR, string descripcionLocalizacionR,
            string fotoR, DateTime fechaPerdidaR, string datosDueniosR)
        {
            this.aviDAO = new AvisoDAO();
            nombre = nR;
            sexo = sexoR;
            raza = razaR;
            tamanio = tamanioR;
            descripcionAnimal = descripcionAnimalR;
            descripcionLocalizacion = descripcionLocalizacionR;
            foto = fotoR;
            fechaPerdida = fechaPerdidaR;
            datosDuenios = datosDueniosR;

        }

        public Aviso(int idR, string nR, string sexoR, string razaR
            , int tamanioR, string descripcionAnimalR, string descripcionLocalizacionR,
            string fotoR, DateTime fechaPerdidaR, string datosDueniosR)
        {
            this.aviDAO = new AvisoDAO();
            id = idR;
            nombre = nR;
            sexo = sexoR;
            raza = razaR;
            tamanio = tamanioR;
            descripcionAnimal = descripcionAnimalR;
            descripcionLocalizacion = descripcionLocalizacionR;
            foto = fotoR;
            fechaPerdida = fechaPerdidaR;
            datosDuenios = datosDueniosR;

        }
        public void InsertarAviso()
        {

            this.aviDAO.InsertarAviso((Aviso)this.MemberwiseClone());
            Console.Write(" ");
        }

        public void EliminarAviso()
        {
            this.aviDAO.EliminarAviso((Aviso)this.MemberwiseClone());
            Console.Write(" ");
        }

        public void ModificarAviso()
        {
            this.aviDAO.ModificarAviso((Aviso)this.MemberwiseClone());
            Console.Write(" ");
        }


        public List<Aviso> LeerTodosAvisos()
        {
            List<Aviso> arrayAvisos = new List<Aviso>();

            AvisoDAO aviDao = new AvisoDAO();
            arrayAvisos = aviDao.LeerTodosAvisos();
            Console.Write(" ");

            return arrayAvisos;
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
        public string getraza()
        {
            return this.raza;
        }
        public void setraza(string raza)
        {
            this.raza = raza;
        }

        public string getdescripcionAnimal()
        {
            return this.descripcionAnimal;
        }
        public void setdescripcionAnimal(string descripcionAnimal)
        {
            this.descripcionAnimal = descripcionAnimal;
        }

        public string getdescripcionLocalizacion()
        {
            return this.descripcionLocalizacion;
        }
        public void setdescripcionLocalizacion(string descripcionLocalizacion)
        {
            this.descripcionLocalizacion = descripcionLocalizacion;
        }

        public string getfoto()
        {
            return this.foto;
        }
        public void setfoto(string foto)
        {
            this.foto = foto;
        }

        public DateTime getfechaPerdida()
        {
            return this.fechaPerdida;
        }
        public void setfechaPerdida(DateTime fechaPerdida)
        {
            this.fechaPerdida = fechaPerdida;
        }

        public string getdatosDuenios()
        {
            return this.datosDuenios;
        }
        public void setdatosDuenios(string datosDuenios)
        {
            this.datosDuenios = datosDuenios;
        }
    }
}
