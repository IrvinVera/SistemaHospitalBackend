using BackendSistemaHospital.Abstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Interfaces
{
    interface IPersona
    {
        APersona Registar(APersona persona);
        bool Editar(APersona persona);
        bool Eliminar(int idPersona);
        APersona BuscarPersonaId(int idPersona);
        APersona BuscarPersonaNombre(string nombrePersona);
        List<APersona> ObtenerMedicos();
    }
}
