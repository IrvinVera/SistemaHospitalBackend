using BackendSistemaHospital.Abstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Interfaces
{
    interface IConsulta
    {
        bool Registrar(AConsulta consulta);
        List<AConsulta> ObtenerConsultasPorPaciente(int idPaciente);
    }
}
