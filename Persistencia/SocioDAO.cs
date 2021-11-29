using Protectora.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Persistencia
{
    class SocioDAO : IDAO<Socio>
    {



        public void leerTodos()
        {
            Socio socios = new Socio();
        }

        public int InsertarSocio(Socio s)
        {
            AgenteDB agente = AgenteDB.obtenerAgente();

            agente.modificar("INSERT INTO personas (nombreCompleto,correo,dni,telefono) VALUES ('" + s.getNombre().ToString() + "', '" + s.getcorreo().ToString() + "'," +
                " '" + s.getdni().ToString() + "', " + s.gettelefono().ToString() + ");");
            s.setid(Int32.Parse(agente.leer("SELECT MAX(Id) FROM personas")[0][0]));

            return agente.modificar("INSERT INTO socios ( datosBancarios, cuantiaAyuda, formaPago, IdPersona ) VALUES ('" + s.getdatosBancarios().ToString() + "'," +
                " " + s.getcuantiaAyuda().ToString() + ", '" + s.getformaPago().ToString() + "', " + s.getid().ToString() + ");");
        }


        public int EliminarSocio(Socio s)
        {
            AgenteDB agente = AgenteDB.obtenerAgente();
            return agente.modificar("DELETE FROM personas WHERE Id=" + s.getid().ToString() + ";");
        }

        public int ModificarSocio(Socio s)
        {
            AgenteDB agente = AgenteDB.obtenerAgente();

            agente.modificar("UPDATE socios SET datosBancarios='" + s.getdatosBancarios().ToString() + "' ,cuantiaAyuda=" + s.getcuantiaAyuda().ToString() + ",formaPago= '" + s.getformaPago().ToString() + "' WHERE IdPersona = " + s.getid().ToString() + "; ");

            return agente.modificar("UPDATE personas SET nombreCompleto= '" + s.getNombre().ToString() + "',correo='" + s.getcorreo().ToString() + "'," +
                "dni='" + s.getdni().ToString() + "',telefono=" + s.gettelefono().ToString() + " WHERE Id = " + s.getid().ToString() + "; ");
        }

        public List<Socio> LeerTodosSocios()
        {
            List<Socio> arraySocios = new List<Socio>();
            AgenteDB agente = AgenteDB.obtenerAgente();

            List<List<String>> arrayCarSocios = new List<List<String>>();
            arrayCarSocios = agente.leer("SELECT * FROM personas p, socios s WHERE p.id=s.idPersona");

            foreach (List<String> user in arrayCarSocios)
            {
                Socio s = new Socio(Int32.Parse(user[0]), user[1], user[2], user[3], Int32.Parse(user[4]), user[6], Int32.Parse(user[7]), user[8]);
                arraySocios.Add(s);
            }
            Console.Write(" ");
            return arraySocios;
        }

        public List<Socio> leerTodas()
        {
            throw new NotImplementedException();
        }

        public Socio leer(ref Socio obj)
        {
            throw new NotImplementedException();
        }

        public int insertar(ref Socio obj)
        {
            throw new NotImplementedException();
        }

        public int actualizar(ref Socio obj)
        {
            throw new NotImplementedException();
        }

        public int eliminar(ref Socio obj)
        {
            AgenteDB agente = AgenteDB.obtenerAgente();
            return agente.modificar("DELETE FROM personas WHERE Id=" + s.getid().ToString() + ";");
        }
    }
}
