using BackendSistemaHospital.Abstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Concretas
{
    public class SignoVital: ASignoVital
    {
        public bool validarDatos()
        {
            return true;
        }

    }
}
