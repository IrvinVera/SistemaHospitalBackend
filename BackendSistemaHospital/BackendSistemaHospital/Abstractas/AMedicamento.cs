using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Abstractas
{
    public class AMedicamento
    {

        public int IdMedicamento { get; set; }

        public int Cantidad { get; set; }

        public string Compuesto { get; set; }

        public string Nombre { get; set; }

        public string Presentacion { get; set; }


    }
}
