using BackendSistemaHospital.Abstractas;
using BackendSistemaHospital.Interfaces;
using BackendSistemaHospital.InterfacesPersistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Concretas
{
    public class PersonaImp : IPersona
    {
        private IPersonaPersistencia PersonaPersistencia;

        public PersonaImp(IPersonaPersistencia PersonaPersistencia)
        {
            this.PersonaPersistencia = PersonaPersistencia;
        }

        public bool Registar(APersona persona)
        {
            return this.PersonaPersistencia.RegistrarBD(persona);
        }
    }
}
