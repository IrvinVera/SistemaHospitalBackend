using BackendSistemaHospital.Abstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.InterfacesPersistencia
{
    public interface IRecetaPersistencia
    {
        int RegistrarBD(AReceta receta);
        AReceta ObtenerRecetaDeConsultaBD(int idConsulta);
    }
}
