using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaHospital.Models
{
    public class Medicamento
    {
        [Key]
        [Required]
        [Display(Name = "idPersona")]
        public int IdMedicamentos;

        [Required(ErrorMessage = "Ingresa el {0}")]
        [Display(Name = "cantidad")]
        public int Cantidad;

        [Required(ErrorMessage = "Ingresa el {0}")]
        [Display(Name = "compuesto")]
        public string Compuesto;

        [Required(ErrorMessage = "Ingresa el {0}")]
        [Display(Name = "nombre")]
        public string Nombre;

        [Required(ErrorMessage = "Ingresa el {0}")]
        [Display(Name = "presentacion")]
        public string Presentacion;
    }
}
