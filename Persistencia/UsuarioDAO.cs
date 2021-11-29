using Protectora.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Persistencia
{
    class UsuarioDAO : IDAO<Usuario>
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


        // ESTA PARTE ES LA QUE VALE
        public List<Usuario> leerTodas()
        {
            List<List<String>> arrayCarUsuarios = AgenteDB.obtenerAgente().leer("SELECT * FROM usuarios");

            foreach (List<String> user in arrayCarUsuarios)
            {
                Usuario p = new Usuario(Int32.Parse(user[0]), user[1], user[2], DateTime.Parse(user[3]));
                usuarios.Add(p);
            }
            return usuarios;
        }

        public Usuario leer(ref Usuario obj)
        {
            List<List<String>> arrayCarUsuarios = AgenteDB.obtenerAgente().leer("SELECT * FROM usuarios WHERE user='" + obj.Nombre + "' and password='" + obj.Password + "';");

            foreach (List<String> user in arrayCarUsuarios)
            {
                Usuario p = new Usuario(Int32.Parse(user[0]), user[1], user[2], DateTime.Parse(user[3]));
                usuarios.Add(p);
            }
            return usuarios[0];
        }

        public int insertar(ref Usuario obj)
        {
            throw new NotImplementedException();
        }

        public int actualizar(ref Usuario obj)
        {
            return AgenteDB.obtenerAgente().modificar("UPDATE usuarios SET ultimaConexion= '" + obj.FechaUltimaConex.ToString() + "' WHERE Id = " + obj.Id.ToString() + "; ");
        }

        public int eliminar(ref Usuario obj)
        {
            throw new NotImplementedException();
        }
    }
}
