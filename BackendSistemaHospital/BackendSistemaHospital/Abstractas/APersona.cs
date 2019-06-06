using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Abstractas
{
    public class APersona
    {

        public int IdPersona { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string Correo { get; set; }

        public string Telefono { get; set; }

        public string Genero { get; set; }

        public string Rol { get; set; }

        public DateTime FechaNacimiento { get; set; }

       // public ACuenta Cuenta { get; set; }

        //public AConsultorio Consultorio { get; set; }

        //public List<AConsulta> Consultas { get; set; }

        //public List<ASignoVital> SignosVitales { get; set; }


    }
}
