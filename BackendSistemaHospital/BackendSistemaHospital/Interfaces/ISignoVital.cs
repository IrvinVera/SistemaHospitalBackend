using BackendSistemaHospital.Abstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Interfaces
{
    interface ISignoVital
    {

        bool Registar(ASignoVital SignoVital);
        List<ASignoVital> ConsultarPorId(int idPersona);
    }
}
