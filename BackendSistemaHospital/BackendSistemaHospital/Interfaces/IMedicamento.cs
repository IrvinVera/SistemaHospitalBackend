using BackendSistemaHospital.Abstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Interfaces
{
    interface IMedicamento
    {
        AMedicamento registrar(AMedicamento medicamento);
        bool eliminar(int idMedicamento);

        bool editar(AMedicamento medicamento);
        List<AMedicamento> obtenerMedicamentos();
    }
}
