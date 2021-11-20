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
            Perro aniAUX = new Perro();
            List<Perro> arrayAnimales =  aniAUX.LeerTodosAnimales();

            //Obtener todos los voluntarios
            Voluntario volAUX = new Voluntario();
            List<Voluntario> arrayVoluntarios =  volAUX.LeerTodosVoluntarios();

            //Obtener todos los socios
            Socio socAUX = new Socio();
            List<Socio> arraySocios =  socAUX.LeerTodosSocios();

            //Obtener todos los socios
            Aviso aviAUX = new Aviso();
            List<Aviso> arrayAvisos =  aviAUX.LeerTodosAvisos();

            Console.Write(" ");

        }
    }
}
