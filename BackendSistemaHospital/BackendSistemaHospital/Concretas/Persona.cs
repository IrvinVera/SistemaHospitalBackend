﻿using BackendSistemaHospital.Abstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Concretas
{
    public class Persona: APersona
    {

        public bool validarDatos()
        {
            return true;
        }
    }
}
