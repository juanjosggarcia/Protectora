﻿using Protectora.Dominio;
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
        public List<Usuario> leerName(Usuario obj)
        {
            List<List<String>> arrayCarUsuarios = AgenteDB.obtenerAgente().leer("SELECT * FROM usuarios WHERE user LIKE '%" + obj.Nombre + "%';");

            foreach (List<String> user in arrayCarUsuarios)
            {
                Usuario p = new Usuario(Int32.Parse(user[0]), user[1], user[2], DateTime.Parse(user[3]));
                usuarios.Add(p);
            }
            return usuarios;
        }

        public Usuario leerId(Usuario obj)
        {
            List<List<String>> arrayCarUsuarios = AgenteDB.obtenerAgente().leer("SELECT * FROM usuarios WHERE user='" + obj.Nombre + "' and password='" + obj.Password + "';");

            foreach (List<String> user in arrayCarUsuarios)
            {
                Usuario p = new Usuario(Int32.Parse(user[0]), user[1], user[2], DateTime.Parse(user[3]));
                usuarios.Add(p);
            }
            if (usuarios.Count != 0)
            {
                return usuarios[0];
            }
            else return null;
        }

        public int insertar(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public int actualizar(Usuario obj)
        {
            return AgenteDB.obtenerAgente().modificar("UPDATE usuarios SET ultimaConexion= '" + obj.FechaUltimaConex.ToString() + "' WHERE Id = " + obj.Id.ToString() + "; ");
        }

        public int eliminar(Usuario obj)
        {
            throw new NotImplementedException();
        }
    }
}
