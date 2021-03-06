﻿using BackendSistemaHospital.Abstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Interfaces
{
    interface IReceta
    {
        int Registrar(AReceta receta);
        AReceta buscarRecetaDeConsulta(int idConsulta);
    }
}
