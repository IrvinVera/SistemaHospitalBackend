using BackendSistemaHospital.Abstractas;
using BackendSistemaHospital.Interfaces;
using BackendSistemaHospital.InterfacesPersistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Concretas
{
    public class MedicamentoImp : IMedicamento
    {
        private IMedicamentoPersistencia medicamentoPersistencia;

        public MedicamentoImp(IMedicamentoPersistencia medicamentoPersistencia)
        {
            this.medicamentoPersistencia = medicamentoPersistencia;
        }

        public bool editar(AMedicamento medicamento)
        {
            return this.medicamentoPersistencia.editarBD(medicamento);
        }

        public bool eliminar(int idMedicamento)
        {
            return this.medicamentoPersistencia.eliminarBD(idMedicamento);
        }

        public List<AMedicamento> obtenerMedicamentos()
        {
            return this.medicamentoPersistencia.obtenerMedicamentosBD();
        }

        public bool registrar(AMedicamento medicamento)
        {
            return this.medicamentoPersistencia.registrarBD(medicamento);
        }
    }
}
