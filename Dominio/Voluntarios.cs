using System;
using Protectora.Persistencia;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora
{
    class Voluntarios
    {
        public int id;
        public String nombreCompleto;
        public String correo;
        public String dni;
        public int telefono;
        public String foto;
        public String horario;
        public String zonaDisponibilidad;


        public List<Voluntarios> LeerTodosVoluntarios()
        {
            List<Voluntarios> arrayVoluntarios = new List<Voluntarios>();

            VoluntariosDAO volDao = new VoluntariosDAO();
            arrayVoluntarios = volDao.LeerTodosVoluntarios();

            Console.Write(" ");

            return arrayVoluntarios;
        }

    }
}