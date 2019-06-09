using BackendSistemaHospital.Abstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.InterfacesPersistencia
{
    public interface IConsultaPersistencia
    {
        bool RegistrarBD(AConsulta consulta);
        List<AConsulta> obtenerConsultasDePacienteBD(int IdPersona);
    }
}
