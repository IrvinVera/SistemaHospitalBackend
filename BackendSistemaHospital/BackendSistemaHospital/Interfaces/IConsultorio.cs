using BackendSistemaHospital.Abstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Interfaces
{
    interface IConsultorio
    {
        bool Registrar(AConsultorio Consultorio);
        bool EditarEstado(int idConsultorio);
        bool Eliminar(int idConsultorio);
    }
}
