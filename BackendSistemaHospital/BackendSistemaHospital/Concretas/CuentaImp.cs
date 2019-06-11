using BackendSistemaHospital.Abstractas;
using BackendSistemaHospital.Interfaces;
using BackendSistemaHospital.InterfacesPersistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Concretas
{
    public class CuentaImp : ICuenta
    {

        private ICuentaPersistencia cuentaPersistencia;

        public CuentaImp(ICuentaPersistencia cuentaPersistencia) {
            this.cuentaPersistencia = cuentaPersistencia;
        }

        public bool Registar(ACuenta cuenta)
        {
            return this.cuentaPersistencia.RegistrarBD(cuenta);
        }

        public string Login(ACuenta cuenta) {
            return cuentaPersistencia.LoginBD(cuenta);
        }


    }
}
