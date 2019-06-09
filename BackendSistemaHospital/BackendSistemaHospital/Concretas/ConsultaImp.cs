using BackendSistemaHospital.Abstractas;
using BackendSistemaHospital.Interfaces;
using BackendSistemaHospital.InterfacesPersistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Concretas
{
    public class ConsultaImp : IConsulta
    {
        private IConsultaPersistencia consultaPersistencia;

        public ConsultaImp(IConsultaPersistencia consultaPersistencia)
        {
            this.consultaPersistencia = consultaPersistencia;
        }

        public List<AConsulta> ObtenerConsultasPorPaciente(int idPaciente)
        {
            return this.consultaPersistencia.obtenerConsultasDePacienteBD(idPaciente);
        }

        public bool Registrar(AConsulta consulta)
        {
            return this.consultaPersistencia.RegistrarBD(consulta);
        }
    }
}
