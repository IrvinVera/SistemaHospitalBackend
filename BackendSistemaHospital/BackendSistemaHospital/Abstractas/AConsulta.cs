using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Abstractas
{
    public class AConsulta
    {

        public int IdConsulta { get; set; }

        public DateTime HoraInicio { get; set; }

        public DateTime HoraFin { get; set; }

        public APersona Persona { get; set; }

        public AConsultorio Consultorio { get; set; }
        
        public AReceta Receta { get; set; }
    }
}
