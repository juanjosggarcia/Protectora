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
        private AnimalDAO aniDAO;

        public Perro() : base()
        {
            this.aniDAO = new AnimalDAO();
        }

        public Perro(int id, string nombre, string sexo, int tamanio, int peso, int edad, DateTime fechaEntrada
            , string foto, string enlace, string descripcion, string estado, int apadrinado, string raza) :
            base(id, nombre, sexo, tamanio, peso, edad, fechaEntrada, foto, enlace, descripcion, estado, apadrinado)
        {
            this.aniDAO = new AnimalDAO();
            this.raza = raza;
        }

        public Perro(string nombre, string sexo, int tamanio, int peso, int edad, DateTime fechaEntrada
            , string foto, string enlace, string descripcion, string estado, int apadrinado, string raza) :
            base(nombre, sexo, tamanio, peso, edad, fechaEntrada, foto, enlace, descripcion, estado, apadrinado)
        {
            this.aniDAO = new AnimalDAO();
            this.raza = raza;
        }

        public void InsertarPerro()
        {
            this.aniDAO.InsertarPerro((Perro)this.MemberwiseClone());
            Console.Write(" ");
        }

        public void EliminarPerro()
        {
            this.aniDAO.EliminarPerro((Perro)this.MemberwiseClone());
            Console.Write(" ");
        }

        public void ModificarPerro()
        {
            this.aniDAO.ModificarPerro((Perro)this.MemberwiseClone());
            Console.Write(" ");
        }


        public List<Perro> LeerTodosAnimales()
        {
            List<Perro> arrayAnimales = new List<Perro>();

            arrayAnimales = this.aniDAO.LeerTodosAnimales();
            Console.Write(" ");

            return arrayAnimales;
        }

        public string getraza()
        {
            return this.raza;
        }
        public void setraza(string raza)
        {
            this.raza = raza;
        }

    }
}
