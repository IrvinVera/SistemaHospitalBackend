using BackendSistemaHospital.Abstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.InterfacesPersistencia
{
    public interface IRecetaPersistencia
    {
        bool RegistrarBD(AReceta receta);
        //AReceta ObtenerReceta(AConsulta consulta);
    }
}
