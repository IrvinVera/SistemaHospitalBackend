using BackendSistemaHospital.Abstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Concretas
{
    public class Tratamiento: ATratamiento
    {
        public bool validarDatos()
        {
            return (this.Cantidad !=0 && this.Frecuencia !="" && this.Medicamentos.Count > 0 && this.Receta.IdReceta !=0 && this.Tiempo !="");
        }
    }
}
