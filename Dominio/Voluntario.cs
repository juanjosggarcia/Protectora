using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Protectora.Persistencia;

namespace Protectora
{
    class Voluntario
    {
        private int id;
        private String nombreCompleto;
        private String correo;
        private String dni;
        private int telefono;
        private String foto;
        private String horario;
        private String zonaDisponibilidad;

        public Voluntario()
        {
        }


        public Voluntario(int idR, String nCR, String correoR, String dniR
            , int telefonoR, String fotoR, String horarioR,
            String zonaDisponibilidadR)
        {
            id = idR;
            nombreCompleto = nCR;
            correo = correoR;
            dni = dniR;
            telefono = telefonoR;
            foto = fotoR;
            horario = horarioR;
            zonaDisponibilidad = zonaDisponibilidadR;
        }


        public List<Voluntario> LeerTodosVoluntarios()
        {
            List<Voluntario> arrayVoluntarios = new List<Voluntario>();

            VoluntariosDAO volDao = new VoluntariosDAO();
            arrayVoluntarios = volDao.LeerTodosVoluntarios();

            Console.Write(" ");

            return arrayVoluntarios;
        }
    }
}