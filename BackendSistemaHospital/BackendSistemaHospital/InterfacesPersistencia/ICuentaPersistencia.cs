using BackendSistemaHospital.Abstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.InterfacesPersistencia
{
    public interface ICuentaPersistencia
    {
        string LoginBD(ACuenta cuenta);
        bool RegistrarBD(ACuenta cuenta);
    }
}
