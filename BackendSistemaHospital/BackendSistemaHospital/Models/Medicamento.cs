using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Models
{
    [Table("Medicamento")]
    public class Medicamento
    {

        [Key]
        [Required]
        [Display(Name = "idMedicamento")]
        public int IdMedicamento { get; set; }

        [Required]
        [Display(Name = "cantidad")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Ingresa el {0}")]
        [Display(Name = "compuesto")]
        public string Compuesto { get; set; }

        [Required(ErrorMessage = "Ingresa el {0}")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingresa el {0}")]
        [Display(Name = "Presentacion")]
        public string Presentacion { get; set; }

        
        public List<MedicamentoTratamiento> MedicamentoTratamientos { get; set; }
    }
}