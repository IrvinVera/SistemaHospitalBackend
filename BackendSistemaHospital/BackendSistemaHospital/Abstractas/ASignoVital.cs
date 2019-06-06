using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Abstractas
{
    public class ASignoVital
    {

        public int IdSignoVital { get; set; }

        public Double Estatura { get; set; }

        public Double Peso { get; set; }

        public DateTime Fecha { get; set; }

        public Double Presion { get; set; }

        public Double Temperatura { get; set; }

        public APersona Persona { get; set; }
    }
}
