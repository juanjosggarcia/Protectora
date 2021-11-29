﻿using Protectora.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protectora.Dominio
{
    public class ClassPruebas
    {
        public static void Main(string[] args)
        {

            //Conexión BBDD
            AgenteDB agente = AgenteDB.obtenerAgente();

            agente.conectar();


            //Obtener todos usuarios
            Usuario usuAUX = new Usuario();

            //usuAUX.LeerUsuario("root", "root");

            //List<Usuario> arrayUsuarios = usuAUX.LeerTodosUsuarios();

            //Obtener todos los animales
            Perro aniAUX = new Perro();
            List<Perro> arrayAnimales = aniAUX.LeerTodosAnimales();

            //Obtener todos los voluntarios
            Voluntario volAUX = new Voluntario();
            List<Voluntario> arrayVoluntarios = volAUX.LeerTodosVoluntarios();

            //Obtener todos los socios
            Socio socAUX = new Socio();
            List<Socio> arraySocios = socAUX.LeerTodosSocios();

            //Obtener todos los padrinos
            Padrino padAUX = new Padrino();
            List<Padrino> arrayPadrino = padAUX.LeerTodosPadrino();

            //Obtener todos los avisos
            Aviso aviAUX = new Aviso();
            List<Aviso> arrayAvisos = aviAUX.LeerTodosAvisos();


            /*
            //                                                          ANIMAL  
               //Añadir animal

           Perro p = new Perro("Kora", "Macho", 72, 19, 7, DateTime.Now, "pastorDos.jpg", "www.youtube.com", "Perro lindo", "Libre", 0, "Pastor Aleman");
           p.InsertarPerro();


               //Eliminar animal

           Perro pElim = arrayAnimales[8];
           pElim.EliminarPerro();


               //Modificar animal

           Perro pMod = arrayAnimales[8];
           pMod.setNombre("Mara");
           pMod.setraza("Mestizo");
           pMod.ModificarPerro();

            //Obtener todos los animales
            arrayAnimales =  aniAUX.LeerTodosAnimales();

            */

            /*
            //                                                          VOLUNTARIOS  
            //Añadir voluntario

           Voluntario v = new Voluntario("Eva Luna", "evalun@gmail.com", "05239654L", 454368719,  "eva.jpg", "Por las noches", "d");
           v.InsertarVoluntario();
            
             //Modificar voluntario

           Voluntario vMod = arrayVoluntarios[2];
           vMod.setNombre("Macos Manuel");
           vMod.setzonaDisponibilidad("f");
           vMod.ModificarVoluntario();


               //Eliminar voluntario

           Voluntario vVol = arrayVoluntarios[0];
           vVol.EliminarVoluntario();

            //Obtener todos los voluntarios
            arrayVoluntarios =  volAUX.LeerTodosVoluntarios();

            */


            //                                                          SOCIOS  
            //Añadir socio
            /*
           Socio s = new Socio("Fernando Garcia", "fergb@gmail.com", "05259654N", 454536719,  "fer.jpg", 20 , "Cheque");
           s.InsertarSocio();
            
             //Modificar socio

           Socio sMod = arraySocios[2];
           sMod.setNombre("Marcos Heredia");
           sMod.setformaPago("efectivo");
           sMod.ModificarSocio();

            
            //Eliminar socio

            Socio eSoc = arraySocios[2];
           eSoc.EliminarSocio();
            
            //Obtener todos los socio
            arraySocios =  socAUX.LeerTodosSocios();
            */


            /*
            //                                                          PADRINOS  
            //Añadir padrino

            Padrino pa = new Padrino("Eva Luna", "evalun@gmail.com", "05239654L", 454368719,  "eva.jpg",5 , "d",DateTime.Now);
           pa.InsertarPadrino();
            
             //Modificar padrino

             Padrino paMod = arrayPadrino[2];
           paMod.setNombre("El alfa");
           paMod.setcuantiaAyuda(200);
           paMod.ModificarPadrino();
            

            //Eliminar padrino

            Padrino pVol = arrayPadrino[0];
            pVol.EliminarPadrino();

            //Obtener todos los padrino

            arrayPadrino =  padAUX.LeerTodosPadrino();
           
            */

            /*
            //                                                            AVISOS
               //Añadir aviso

           Aviso a = new Aviso("Pluto", "Macho", "Desconocido", 62, "Perro marron que habla", "Se encuentra por el centro", "pastorDos.jpg", DateTime.Now, "Luis Enrique 854323405");
           a.InsertarAviso();

           
            //Eliminar aviso

            Aviso aElim = arrayAvisos[2];
            aElim.EliminarAviso();


            //Modificar aviso
            
           Aviso aMod = arrayAvisos[2];
           aMod.setNombre("Makako");
           aMod.ModificarAviso();

            //Obtener todos los avisos
           arrayAvisos = aviAUX.LeerTodosAvisos();
             
            */


            Console.Write(" ");

        }
    }
}

