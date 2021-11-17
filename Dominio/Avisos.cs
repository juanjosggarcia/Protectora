﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Protectora.Persistencia;

namespace Protectora.Dominio
{
    class Avisos
    {
        private int id;
        private String nombre;
        private String sexo;
        private String raza;
        private int tamanio;
        private String descripcionAnimal;
        private String descripcionLocalizacion;
        private String foto;
        private DateTime fechaPerdida;
        private String datosDuenios;

        public void set(int idR, String nR, String sexoR, String razaR
            , int tamanioR, String descripcionAnimalR, String descripcionLocalizacionR, 
            String fotoR , DateTime fechaPerdidaR, String datosDueniosR)
        {
            id = idR;
            nombre = nR;
            sexo = sexoR;
            raza = razaR;
            tamanio = tamanioR;
            descripcionAnimal = descripcionAnimalR;
            descripcionLocalizacion = descripcionLocalizacionR;
            foto = fotoR;
            fechaPerdida = fechaPerdidaR;
            datosDuenios = datosDueniosR;

        }


        public List<Avisos> LeerTodosAvisos()
        {
            List<Avisos> arrayAvisos = new List<Avisos>();
            
            AvisosDAO aviDao = new AvisosDAO();
            arrayAvisos = aviDao.LeerTodosAvisos();
            Console.Write(" ");

            return arrayAvisos;
        }
    }
}
