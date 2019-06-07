using BackendSistemaHospital.Abstractas;
using BackendSistemaHospital.Interfaces;
using BackendSistemaHospital.InterfacesPersistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Concretas
{
    public class SignoVitalImp : ISignoVital
    {
        private ISignoVitalPersistencia SignoVitalPersistencia;

        public SignoVitalImp(ISignoVitalPersistencia SignoVitalPersistencia)
        {
          this.SignoVitalPersistencia = SignoVitalPersistencia;
        }

        public bool Registar(ASignoVital SignoVital)
        {
            return this.SignoVitalPersistencia.RegistrarBD(SignoVital);
        }

        public List<ASignoVital> ConsultarPorId(int idPersona) {

            return this.SignoVitalPersistencia.ConsultarPorIdBD(idPersona);

        }

    }
}
