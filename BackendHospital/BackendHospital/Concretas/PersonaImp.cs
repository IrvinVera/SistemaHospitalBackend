using BackendHospital.Abstracta;
using BackendHospital.Interfaces;
using BackendHospital.InterfacesPersistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendHospital.Concretas
{
    public class PersonaImp : IPersona
    {
        private IPersonaPersistencia personaPersistencia;

        public bool Registar(APersona persona)
        {
            return personaPersistencia.registrarBD(persona);
        }

        PersonaImp(IPersonaPersistencia personaPersistencia) {
            this.personaPersistencia = personaPersistencia;
        }

    }
}