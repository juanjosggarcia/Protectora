using Protectora.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Dominio
{
    class ClassPruebas
    {
        public static void Main(string[] args)
        {

            //Conexión BBDD
            AgenteDB agente = AgenteDB.obtenerAgente();
            agente.conectar();

            //Obtener todos usuarios
            Persona usuAUX = new Persona();
            List<Persona> arrayUsuarios =  usuAUX.LeerTodasPersonas();

            //Obtener todos los animales
            Animales aniAUX = new Animales();
            List<Animales> arrayAnimales =  aniAUX.LeerTodosAnimales();

            //Obtener todos los voluntarios
            Voluntarios volAUX = new Voluntarios();
            List<Voluntarios> arrayVoluntarios =  volAUX.LeerTodosVoluntarios();

            //Obtener todos los socios
            Socios socAUX = new Socios();
            List<Socios> arraySocios =  socAUX.LeerTodosSocios();

            //Obtener todos los socios
            Avisos aviAUX = new Avisos();
            List<Avisos> arrayAvisos =  aviAUX.LeerTodosAvisos();

            Console.Write(" ");

        }
    }
}
