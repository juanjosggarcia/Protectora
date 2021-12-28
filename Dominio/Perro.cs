using System;
using Protectora.Persistencia;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Protectora.Dominio;

namespace Protectora
{
    public class Perro : Animal, IDTO<Perro>
    {
        private string raza;
        private AnimalDAO aniDAO;

        public string Raza { get => raza; set => raza = value; }
        internal AnimalDAO AniDAO { get => aniDAO; set => aniDAO = value; }

        public Perro() : base()
        {
            this.AniDAO = new AnimalDAO();
        }

        public Perro(Nullable<int> id, string nombre, string sexo, int tamanio, int peso, int edad, DateTime fechaEntrada
            , string foto, string enlace, string descripcion, string estado, int apadrinado, string raza) :
            base(id, nombre, sexo, tamanio, peso, edad, fechaEntrada, foto, enlace, descripcion, estado, apadrinado)
        {
            this.AniDAO = new AnimalDAO();
            this.Raza = raza;
        }

        /////////////////////////////////////////////////////////////// PARTE DATA TRANSFER OBJECT ///////////////////////////////////////////////////////////////

        public List<Perro> leerTodosDatos()
        {
            return AniDAO.leerTodas();
        }
        public Perro leerDatoXName()
        {
            return AniDAO.leerName(this);
        }
        public Perro leerDatoXId()
        {
            throw new NotImplementedException();
        }

        public int insertarDato()
        {
            return this.AniDAO.insertar(this);
        }
        public int actualizarDato()
        {
            return this.AniDAO.actualizar(this);
        }
        public int eliminarDato()
        {
            return this.AniDAO.eliminar(this);
        }


    }
}
