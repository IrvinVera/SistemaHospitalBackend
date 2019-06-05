using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Models
{
    [Table("Tratamiento")]
    public class Tratamiento
    {

        [Key]
        [Required]
        [Display(Name = "idTratamiento")]
        public int IdTratamiento { get; set; }

        [Required]
        [Display(Name = "cantidad")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Ingresa el {0}")]
        [Display(Name = "frecuencia")]
        public string Frecuencia { get; set; }

        [Required(ErrorMessage = "Ingresa el {0}")]
        [Display(Name = "tiempo")]
        public string Tiempo { get; set; }

        
        public Receta Receta { get; set; }

        public List<MedicamentoTratamiento> MedicamentoTratamientos { get; set; }



    }
}
