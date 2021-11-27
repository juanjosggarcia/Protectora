using Protectora.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Persistencia
{
    class UsuarioDAO : IDAO
    {
        public readonly List<Usuario> usuarios;

        public UsuarioDAO()
        {
            this.usuarios = new List<Usuario>();
        }

        public void LeerTodosUsuarios()
        {
            //List<Usuario> arrayUsuarios = new List<Usuario>();
            AgenteDB agente = AgenteDB.obtenerAgente();

            List<List<String>> arrayCarUsuarios = new List<List<String>>();
            arrayCarUsuarios = agente.leer("SELECT * FROM usuarios");

            foreach (List<String> user in arrayCarUsuarios)
            {
                Usuario p = new Usuario(Int32.Parse(user[0]), user[1], user[2], DateTime.Parse(user[3]));
                //arrayUsuarios.Add(p);
                usuarios.Add(p);
            }

        }

        public int ModificarUsuarioFecha(int id, DateTime fechaUltimaConex)
        {
            AgenteDB agente = AgenteDB.obtenerAgente();
            //return agente.modificar("UPDATE usuarios SET ultimaConexion= '" + usuario.getfechaUltimaConex().ToString() + "' WHERE Id = " + usuario.getid().ToString() + "; ");
            return agente.modificar("UPDATE usuarios SET ultimaConexion= '" + fechaUltimaConex.ToString() + "' WHERE Id = " + id.ToString() + "; ");
        }
        public int ModificarUsuarioFecha_ALBERTO(Usuario usuario)
        {
            AgenteDB agente = AgenteDB.obtenerAgente();
            //return agente.modificar("UPDATE usuarios SET ultimaConexion= '" + usuario.getfechaUltimaConex().ToString() + "' WHERE Id = " + usuario.getid().ToString() + "; ");
            return agente.modificar("UPDATE usuarios SET ultimaConexion= '" + usuario.FechaUltimaConex.ToString() + "' WHERE Id = " + usuario.Id.ToString() + "; ");
        }

        public void LeerUsuario(Usuario usuario)
        {
            //List<Usuario> arrayUsuarios = new List<Usuario>();
            AgenteDB agente = AgenteDB.obtenerAgente();

            List<List<String>> arrayCarUsuarios = new List<List<String>>();
            arrayCarUsuarios = agente.leer("SELECT * FROM usuarios WHERE user='" + usuario.Nombre + "' and password='" + usuario.Password + "';");

            foreach (List<String> user in arrayCarUsuarios)
            {
                Usuario p = new Usuario(Int32.Parse(user[0]), user[1], user[2], DateTime.Parse(user[3]));
                //arrayUsuarios.Add(p);
                usuarios.Add(p);
            }
        }



        public void leerTodas<T>()
        {
            List<List<String>> arrayCarUsuarios = AgenteDB.obtenerAgente().leer("SELECT * FROM usuarios");

            foreach (List<String> user in arrayCarUsuarios)
            {
                Usuario p = new Usuario(Int32.Parse(user[0]), user[1], user[2], DateTime.Parse(user[3]));
                //arrayUsuarios.Add(p);
                usuarios.Add(p);
            }
        }

        public void leer<T>(Usuario obj)
        {
            List<List<String>> arrayCarUsuarios = AgenteDB.obtenerAgente().leer("SELECT * FROM usuarios WHERE user='" + obj.Nombre + "' and password='" + obj.Password + "';");

            foreach (List<String> user in arrayCarUsuarios)
            {
                Usuario p = new Usuario(Int32.Parse(user[0]), user[1], user[2], DateTime.Parse(user[3]));
                usuarios.Add(p);
            }
        }

        public int insertar<T>(T obj)
        {
            throw new NotImplementedException();
        }

        public int actualizar<T>(Usuario obj)
        {
            return AgenteDB.obtenerAgente().modificar("UPDATE usuarios SET ultimaConexion= '" + obj.FechaUltimaConex.ToString() + "' WHERE Id = " + obj.Id.ToString() + "; ");
        }

        public int eliminar<T>(T obj)
        {
            throw new NotImplementedException();
        }

        void IDAO.leer<T>(ref T obj)
        {
            throw new NotImplementedException();
        }

        int IDAO.actualizar<T>(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
