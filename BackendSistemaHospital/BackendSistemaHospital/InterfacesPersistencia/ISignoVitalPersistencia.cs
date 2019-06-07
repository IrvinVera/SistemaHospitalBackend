using BackendSistemaHospital.Abstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.InterfacesPersistencia
{
    public interface ISignoVitalPersistencia
    {

        bool RegistrarBD(ASignoVital SignoVital);
        List<ASignoVital> ConsultarPorIdBD(int idPersona);

    }
}
