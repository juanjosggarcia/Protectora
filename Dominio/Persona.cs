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
        public int id;
        public String nombre;
        public String password;
        public DateTime fechaUltimaConex;
       
        
        
        public List<Persona> LeerTodasPersonas()
        {
            PersonaDAO perAUX = new PersonaDAO();
            List<Persona> arrayUsuarios = perAUX.LeerTodasPersonas();
            return arrayUsuarios;
        }
    }
}
