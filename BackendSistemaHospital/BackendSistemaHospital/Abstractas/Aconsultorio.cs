using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Abstractas
{
    public class AConsultorio
    {

        public int IdConsultorio { get; set; }

        public string NumeroConsultorio { get; set; }

        public string Estado { get; set; }

        public APersona Persona { get; set; }

      public List<AConsulta> Consultas { get; set; }
    }
}
