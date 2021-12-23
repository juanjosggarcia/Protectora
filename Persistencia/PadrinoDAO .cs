﻿using Protectora.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Persistencia
{
    class PadrinoDAO : IDAO<Padrino>
    {

        public List<Padrino> leerTodas()
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


        public Padrino leer(Padrino obj)
        {
            AgenteDB agente = AgenteDB.obtenerAgente();
            Console.Write(" ");
            List<List<String>> arrayCarPadrino = agente.leer("SELECT * FROM personas p, padrinos s WHERE p.id=s.idPersona  AND p.id = " + obj.Id.ToString() + "; ");
            Padrino s = new Padrino();

            foreach (List<String> user in arrayCarPadrino)
            {
                s = new Padrino(Int32.Parse(user[0]), user[1], user[2], user[3], Int32.Parse(user[4]), user[6], Int32.Parse(user[7]), user[8], DateTime.Parse(user[9]));

            }
            Console.Write(" ");
            return s;
        }

        public int insertar(Padrino obj)
        {
            AgenteDB agente = AgenteDB.obtenerAgente();

            agente.modificar("INSERT INTO personas (nombreCompleto,correo,dni,telefono) VALUES ('" + obj.NombreCompleto.ToString() + "', '" + obj.Correo.ToString() + "'," +
                " '" + obj.Dni.ToString() + "', " + obj.Telefono.ToString() + ");");
            obj.Id = (Int32.Parse(agente.leer("SELECT MAX(Id) FROM personas")[0][0]));

            return agente.modificar("INSERT INTO padrinos ( datosBancarios, importeMensual, formaPago, comienzoApadrinamiento, IdPersona ) VALUES ('" + obj.DatosBancarios.ToString() + "'," +
                " " + obj.ImporteMensual.ToString() + ", '" + obj.FormaPago.ToString() + "','" + obj.FechaEntrada.ToString() + "', " + obj.Id.ToString() + ");");

        }

        public int actualizar(Padrino obj)
        {
            AgenteDB agente = AgenteDB.obtenerAgente();

            agente.modificar("UPDATE padrinos SET datosBancarios='" + obj.DatosBancarios.ToString() + "' ,importeMensual=" + obj.ImporteMensual.ToString() + ",formaPago= " +
                "'" + obj.FormaPago.ToString() + "',comienzoApadrinamiento='" + obj.FechaEntrada.ToString() + "' WHERE IdPersona = " + obj.Id.ToString() + "; ");

            return agente.modificar("UPDATE personas SET nombreCompleto= '" + obj.NombreCompleto.ToString() + "',correo='" + obj.Correo.ToString() + "'," +
                "dni='" + obj.Dni.ToString() + "',telefono=" + obj.Telefono.ToString() + " WHERE Id = " + obj.Id.ToString() + "; ");
        }

        public int eliminar(Padrino obj)
        {
            AgenteDB agente = AgenteDB.obtenerAgente();
            return agente.modificar("DELETE FROM personas WHERE Id=" + obj.Id.ToString() + ";");
        }
    }
}
