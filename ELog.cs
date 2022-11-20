using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora
{
    class ELog
    {
        public static void save(object obj, Exception ex)
        {
            string fecha = System.DateTime.Now.ToString("yyyyMMdd");
            string hora = System.DateTime.Now.ToString("HH:mm:ss");

            string pathExe = Modulos.obtenerPath(); // devuelve la ruta de la carpeta base dentro de visual
            //string pathExe = AppDomain.CurrentDomain.BaseDirectory; // devuelve la ruta donde se encuentra el ejecutable

            string pathLog = Path.Combine(pathExe, "log");
            System.IO.Directory.CreateDirectory(pathLog);
            string path = Path.Combine(pathLog, (fecha + ".txt"));

            StreamWriter sw = new StreamWriter(path, true);

            StackTrace stacktrace = new StackTrace();
            sw.WriteLine(obj.GetType().FullName + " " + hora);
            sw.WriteLine(stacktrace.GetFrame(1).GetMethod().Name + " - " + ex.Message);
            sw.WriteLine("");

            sw.Flush();
            sw.Close();
        }
    }
}
