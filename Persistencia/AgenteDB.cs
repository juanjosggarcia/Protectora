using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;


namespace Protectora.Persistencia
{
    public class AgenteDB
    {
        private static AgenteDB AgenteBD = null;
        private static OleDbConnection conexionBD = new OleDbConnection();
        //private static string rutaBD = @"..\..\protectoraDB.accdb";
        private static string rutaBD = obtenerPath() + @"\protectoraDB.accdb";
        private string cadenaConexionBD = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=";

        private AgenteDB()
        {
            conexionBD = new OleDbConnection();
            conexionBD.ConnectionString = cadenaConexionBD + rutaBD;
            conexionBD.Open();
        }

        public static AgenteDB obtenerAgente()
        {
            if (AgenteBD == null)
            {
                AgenteBD = new AgenteDB();
            }
            return AgenteBD;
        }
        public bool conectar()
        {
            try
            {
                conexionBD.Open();
                return true;

            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return false;
            }
        }

        public void desconectar()
        {
            if (conexionBD.State == ConnectionState.Open)
            {
                conexionBD.Close();
            }
        }

        public List<List<String>> leer(string sql)
        {
            List<List<String>> result = new List<List<String>>();
            List<String> fila;
            OleDbDataReader reader;
            OleDbCommand com = new OleDbCommand(sql, conexionBD);
            conectar();
            //conectarCutre();

            reader = com.ExecuteReader();
            while (reader.Read())
            {
                fila = new List<String>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    fila.Add(reader[i].ToString());
                }
                result.Add(fila);
            }
            desconectar();
            return result;
        }

        public int modificar(string sql)
        {
            OleDbCommand com = new OleDbCommand(sql, conexionBD);
            int result;
            conectar();
            //conectarCutre();
            result = com.ExecuteNonQuery();
            desconectar();
            return result;
        }

        private static string obtenerPath()
        {
            string pathExe = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            string pathApp1 = pathExe.Substring(8);
            string proc = "/Protectora/";
            int posBin = pathApp1.IndexOf(proc);
            string pathApp = pathApp1.Remove(posBin + proc.Length);
            return pathApp;
        }

    }


}

