using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Abstractas
{
    public class AReceta
    {
        public int IdReceta { get; set; }

        public string Observaciones { get; set; }

        public AConsulta Consulta { get; set; }

        public List<ATratamiento> Tratamientos { get; set; }

    }
}
