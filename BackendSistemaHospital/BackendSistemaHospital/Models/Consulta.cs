using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Models
{
    [Table("Consulta")]
    public class Consulta
    {

        [Key]
        [Required]
        [Display(Name = "idConsulta")]
        public int IdConsulta { get; set; }

        [Required(ErrorMessage = "Ingresa el {0}")]
        [Display(Name = "horaInicio")]
        public DateTime HoraInicio { get; set; }


        [Required(ErrorMessage = "Ingresa el {0}")]
        [Display(Name = "horaFin")]
        public DateTime HoraFin { get; set; }

        
        public Persona Persona { get; set; }

        
        public Consultorio Consultorio { get; set; }

        public int RecetaForeignKey { get; set; }
        public Receta Receta { get; set; }


    }
}
