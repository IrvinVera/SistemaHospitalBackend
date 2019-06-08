using BackendSistemaHospital.Abstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Models
{
    [Table("Consultorio")]
    public class Consultorio
    {


        [Key]
        [Required]
        [Display(Name = "idConsultorio")]
        public int IdConsultorio { get; set; }

        [Required(ErrorMessage = "Ingresa el {0}")]
        [Display(Name = "numeroConsultorio")]
        public string NumeroConsultorio { get; set; }


        [Required(ErrorMessage = "Ingresa el {0}")]
        [Display(Name = "estado")]
        public string Estado { get; set; }

        public int PersonaidPersona { get; set; }
        

        public List<Consulta> Consultas { get; set; }


        public Consultorio() {}

        public Consultorio(AConsultorio consultorio) {

            this.IdConsultorio = consultorio.IdConsultorio;
            this.NumeroConsultorio = consultorio.NumeroConsultorio; 
            this.Estado = consultorio.Estado;


        }
    }
}
