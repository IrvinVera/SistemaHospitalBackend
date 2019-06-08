using BackendSistemaHospital.Abstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.InterfacesPersistencia
{
    public interface IConsultorioPersistencia
    {

        bool RegistrarBD(AConsultorio Consultorio);
        bool EditarEstadoBD(int idConsultorio);
        bool EliminarBD(int idConsultorio);
    }
}
