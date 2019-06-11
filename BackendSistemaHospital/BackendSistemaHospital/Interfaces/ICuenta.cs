using BackendSistemaHospital.Abstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Interfaces
{
    interface ICuenta
    {

        bool Registar(ACuenta cuenta);
        APersona Login(ACuenta cuenta);

    }
}
