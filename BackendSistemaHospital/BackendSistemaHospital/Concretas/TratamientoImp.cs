using BackendSistemaHospital.Abstractas;
using BackendSistemaHospital.Interfaces;
using BackendSistemaHospital.InterfacesPersistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Concretas
{
    public class TratamientoImp : ITratamiento
    {
        private ITratamientoPersistencia tratamientoPersistencia;

        public TratamientoImp(ITratamientoPersistencia tratamientoPersistencia)
        {
            this.tratamientoPersistencia = tratamientoPersistencia;
        }
        public bool guardar(ATratamiento tratamiento)
        {
            return this.tratamientoPersistencia.RegistrarBD(tratamiento);
        }
    }
}
