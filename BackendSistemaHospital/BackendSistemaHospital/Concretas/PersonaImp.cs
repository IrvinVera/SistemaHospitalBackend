﻿using BackendSistemaHospital.Abstractas;
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

        public bool Editar(APersona persona)
        {
            return this.PersonaPersistencia.EditarBD(persona);
        }

        public APersona Registar(APersona persona)
        {
            return this.PersonaPersistencia.RegistrarBD(persona);
        }

        public bool Eliminar(int idPersona)
        {
            return this.PersonaPersistencia.EliminarBD(idPersona);
        }

        public APersona BuscarPersonaId(int idPersona)
        {
            return this.PersonaPersistencia.BuscarPersonaIdBD(idPersona);
        }

        public APersona BuscarPersonaNombre(string nombrePersona)
        {
            return this.PersonaPersistencia.BuscarPersonaNombreBD(nombrePersona);
        }

        public List<APersona> ObtenerPersonas() {

            return this.PersonaPersistencia.ObtenerPersonasBD();

        }

        public List<APersona> ObtenerMedicos()
        {
            return this.PersonaPersistencia.ObtenerMedicosBD();
        }

        public APersona BuscarPersonaNombreUsuario(string nombreUsuarioPersona)
        {
            return this.PersonaPersistencia.BuscarPersonaNombreUsuarioBD(nombreUsuarioPersona);
        }

        public bool validarNombreUsuarioRepetido(string nombreUsuario)
        {
            return this.PersonaPersistencia.validarNombreUsuarioRepetidoBD(nombreUsuario);
        }
    }
}
