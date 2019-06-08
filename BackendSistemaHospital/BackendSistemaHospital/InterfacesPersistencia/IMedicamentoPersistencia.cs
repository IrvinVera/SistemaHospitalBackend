using BackendSistemaHospital.Abstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.InterfacesPersistencia
{
    public interface IMedicamentoPersistencia
    {
        bool registrarBD(AMedicamento medicamento);
        bool eliminarBD(int idMedicamento);

        bool editarBD(AMedicamento medicamento);
        List<AMedicamento> obtenerMedicamentosBD();
    }
}
