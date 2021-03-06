﻿using BackendSistemaHospital.Abstractas;
using BackendSistemaHospital.Interfaces;
using BackendSistemaHospital.InterfacesPersistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Concretas
{
    public class ConsultorioImp : IConsultorio
    {

        IConsultorioPersistencia ConsultorioPersistencia;

        public ConsultorioImp(IConsultorioPersistencia ConsultorioPersistencia) {
            this.ConsultorioPersistencia = ConsultorioPersistencia;
        }

        public AConsultorio Registrar(AConsultorio Consultorio)
        {
            return this.ConsultorioPersistencia.RegistrarBD(Consultorio);
        }

        public bool EditarEstado(int idConsultorio) {
            return this.ConsultorioPersistencia.EditarEstadoBD(idConsultorio);
        }

        public bool Eliminar(int idConsultorio)
        {
            return this.ConsultorioPersistencia.EliminarBD(idConsultorio);
        }

        public bool AsignarDoctor(int idConsultorio, int idPersona)
        {
            return this.ConsultorioPersistencia.AsignarDoctorBD(idConsultorio, idPersona);
        }

        public bool QuitarDoctor(int idConsultorio)
        {
            return this.ConsultorioPersistencia.QuitarDoctorBD(idConsultorio);
        }

        public List<AConsultorio> obtenerTodosLosConsultorios()
        {
            return this.ConsultorioPersistencia.obtenerTodosLosConsultoriosBD();
        }
    }
}
