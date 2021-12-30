using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora
{
    class Modulos
    {
        public static string[] extraerFName(string sourcePath)
        {
            string[] subs = sourcePath.Split('\\');
            if (subs.Length == 1)
            {
                subs = sourcePath.Split('/');
            }
            string fName = subs[subs.Length - 1];
            string sourceDir1 = sourcePath.Substring(0, (sourcePath.Length - fName.Length - 1));
            string sourceDir;
            if (sourceDir1.Contains("file:///"))
            {
                sourceDir = sourceDir1.Substring(8);
            }
            else
            {
                sourceDir = sourceDir1;
            }
            string[] datos = { sourceDir, fName };
            return datos;
        }
        public static string copiarImagen(string sourcePath, string perroPersona)
        {
            string foto = "imagenes";
            if (perroPersona == "perro")
            {
                foto = "imagenes\\fotosPerros";
            }
            else if (perroPersona == "persona")
            {
                foto = "imagenes\\fotosPersonas";
            }
            //string pathApp = AppDomain.CurrentDomain.BaseDirectory; // para produccion
            string pathApp = obtenerPath(); // para visual

            string backupDir = Path.Combine(pathApp, foto);

            System.IO.Directory.CreateDirectory(backupDir);

            List<string> picLis = obtenerImagenesCarpeta(backupDir);

            string[] sourcePath1 = extraerFName(sourcePath);
            string sourceDir = sourcePath1[0];
            string fName = sourcePath1[1];


            if (!(picLis.Contains(backupDir + "\\" + fName)))
            {
                File.Copy(Path.Combine(sourceDir, fName), Path.Combine(backupDir, fName), true);
            }
            return fName;
        }

        public static List<string> obtenerImagenesCarpeta(string backupDir)
        {
            List<string> picLis = Directory.GetFiles(backupDir, "*.jpg").ToList();
            picLis.AddRange(Directory.GetFiles(backupDir, "*.png").ToList());
            picLis.AddRange(Directory.GetFiles(backupDir, "*.gif").ToList());
            picLis.AddRange(Directory.GetFiles(backupDir, "*.bmp").ToList());
            return picLis;
        }

        public static string obtenerPath()
        {
            string pathApp1 = AppDomain.CurrentDomain.BaseDirectory;
            string proc = "\\Protectora\\";
            //string pathExe = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            //string pathApp1 = pathExe.Substring(8);
            //string proc = "/Protectora/";
            int posBin = pathApp1.IndexOf(proc);
            string pathApp = pathApp1.Remove(posBin + proc.Length - 1);
            return pathApp;

            //return AppDomain.CurrentDomain.BaseDirectory; // para produccion
        }
    }
}
