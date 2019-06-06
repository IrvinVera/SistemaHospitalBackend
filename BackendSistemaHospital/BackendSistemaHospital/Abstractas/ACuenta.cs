using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Abstractas
{
    public class ACuenta
    {

        public int IdCuenta { get; set; }

        public string NombreUsuario { get; set; }

        public string Contrasena { get; set; }

        public APersona Persona { get; set; }
    }
}
