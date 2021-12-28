using System;
using Protectora.Persistencia;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Dominio
{
    public class Usuario : IDTO<Usuario>
    {
        private int? id; // ? hace que la variable acepte los valores propios del tipo de dato y tambien el valor null
        private string nombre;
        private string password;
        private DateTime? fechaUltimaConex;
        private UsuarioDAO usuDAO;

        public int? Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Password { get => password; set => password = value; }
        public DateTime? FechaUltimaConex { get => fechaUltimaConex; set => fechaUltimaConex = value; }
        internal UsuarioDAO UsuDAO { get => usuDAO; set => usuDAO = value; }


        public Usuario()
        {
            this.UsuDAO = new UsuarioDAO();
        }

        public Usuario(Nullable<int> id, string nombre, string password, DateTime? fechaUltimaConex)
        {
            this.UsuDAO = new UsuarioDAO();
            this.id = id;
            this.nombre = nombre;
            this.password = password;
            this.fechaUltimaConex = fechaUltimaConex;
        }

        /////////////////////////////////////////////////////////////// PARTE DATA TRANSFER OBJECT ///////////////////////////////////////////////////////////////



        public List<Usuario> leerTodosDatos()
        {
            return UsuDAO.leerTodas();
        }
        public Usuario leerDatoXName()
        {
            return UsuDAO.leerName(this);
        }
        public Usuario leerDatoXId()
        {
            return UsuDAO.leerId(this);
        }

        public int insertarDato()
        {
            throw new NotImplementedException();
        }
        public int actualizarDato()
        {
            return UsuDAO.actualizar(this);
        }
        public int eliminarDato()
        {
            throw new NotImplementedException();
        }
    }
}