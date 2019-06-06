using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Abstractas
{
    public class ATratamiento
    {

        public int IdTratamiento { get; set; }

        public int Cantidad { get; set; }

        public string Frecuencia { get; set; }

        public string Tiempo { get; set; }

        public AReceta Receta { get; set; }

    }
}
