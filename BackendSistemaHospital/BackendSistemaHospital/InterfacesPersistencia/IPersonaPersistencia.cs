using BackendSistemaHospital.Abstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.InterfacesPersistencia
{
    public interface IPersonaPersistencia
    {

        bool RegistrarBD(APersona persona);

        bool EditarBD(APersona persona);

        bool EliminarBD(int idPersona);

    }
}
