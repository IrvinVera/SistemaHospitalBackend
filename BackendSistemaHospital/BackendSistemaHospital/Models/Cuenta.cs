using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Models
{
    [Table("Cuenta")]
    public class Cuenta
    {


        [Key]
        [Required]
        [Display(Name = "idCuenta")]
        public int IdCuenta { get; set; }

        [Required(ErrorMessage = "Ingresa el {0}")]
        [Display(Name = "nombreUsuario")]
        public string NombreUsuario { get; set; }


        [Required(ErrorMessage = "Ingresa el {0}")]
        [Display(Name = "contrasena")]
        public string Contrasena { get; set; }

       public int PersonaForeignKey { get; set; }
        public Persona Persona { get; set; }


    }
}
