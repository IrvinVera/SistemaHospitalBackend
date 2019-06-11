using BackendSistemaHospital.Abstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Concretas
{
    public class Medicamento: AMedicamento
    {
        public bool validarDatos()
        {
            return (this.Nombre != "" && this.Cantidad != 0 && this.Compuesto != "" && this.Presentacion != "");
        }
    }
}
