using System;
using Protectora.Persistencia;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Dominio
{
    class Persona
    {
        private int id;
        private String nombre;
        private String password;
        private DateTime fechaUltimaConex;


        public Persona()
        {
        }


        public Persona(int idR, String nR, String passwordR, DateTime fechaUltimaConexR)
        {
            id = idR;
            nombre = nR;
            password = passwordR;
            fechaUltimaConex = fechaUltimaConexR;

        }

        public List<Persona> LeerTodasPersonas()
        {
            PersonaDAO perAUX = new PersonaDAO();
            List<Persona> arrayUsuarios = perAUX.LeerTodasPersonas();
            return arrayUsuarios;
        }
    }
}