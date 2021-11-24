using Protectora.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Persistencia
{
    class PadrinoDAO
    {

        private String Tabla = "Padrino";

        public void leerTodos()
        {
            Padrino socios = new Padrino();
        }

        public int InsertarPadrino(Padrino p)
        {
            AgenteDB agente = AgenteDB.obtenerAgente();

            agente.modificar("INSERT INTO personas (nombreCompleto,correo,dni,telefono) VALUES ('" + p.getNombre().ToString() + "', '" + p.getcorreo().ToString() + "'," +
                " '" + p.getdni().ToString() + "', " + p.gettelefono().ToString() + ");");
            p.setid(Int32.Parse(agente.leer("SELECT MAX(Id) FROM personas")[0][0]));

            return agente.modificar("INSERT INTO padrinos ( datosBancarios, importeMensual, formaPago, comienzoApadrinamiento, IdPersona ) VALUES ('" + p.getdatosBancarios().ToString() + "'," +
                " " + p.getimporteMensual().ToString() + ", '" + p.getformaPago().ToString() + "','" + p.getfechaEntrada().ToString() + "', " + p.getid().ToString() + ");");
        }


        public int EliminarPadrino(Padrino p)
        {
            AgenteDB agente = AgenteDB.obtenerAgente();
            return agente.modificar("DELETE FROM personas WHERE Id=" + p.getid().ToString() + ";");
        }

        public int ModificarPadrino(Padrino p)
        {
            AgenteDB agente = AgenteDB.obtenerAgente();

            agente.modificar("UPDATE padrinos SET datosBancarios='" + p.getdatosBancarios().ToString() + "' ,importeMensual=" + p.getimporteMensual().ToString() + ",formaPago= " +
                "'" + p.getformaPago().ToString() + "',comienzoApadrinamiento='" + p.getfechaEntrada().ToString() + "' WHERE IdPersona = " + p.getid().ToString() + "; ");

            return agente.modificar("UPDATE personas SET nombreCompleto= '" + p.getNombre().ToString() + "',correo='" + p.getcorreo().ToString() + "'," +
                "dni='" + p.getdni().ToString() + "',telefono=" + p.gettelefono().ToString() + " WHERE Id = " + p.getid().ToString() + "; ");
        }

        public List<Padrino> LeerTodosPadrino()
        {
            List<Padrino> arrayPadrino = new List<Padrino>();
            AgenteDB agente = AgenteDB.obtenerAgente();

            List<List<String>> arrayCarPadrino = new List<List<String>>();
            arrayCarPadrino = agente.leer("SELECT * FROM personas p, padrinos a WHERE p.id=a.idPersona");

            foreach (List<String> user in arrayCarPadrino)
            {
                Padrino s = new Padrino(Int32.Parse(user[0]), user[1], user[2], user[3], Int32.Parse(user[4]), user[6], Int32.Parse(user[7]), user[8], DateTime.Parse(user[9]));
                arrayPadrino.Add(s);
            }
            Console.Write(" ");
            return arrayPadrino;
        }

    }
}
