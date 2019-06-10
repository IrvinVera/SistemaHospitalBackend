using BackendSistemaHospital.Abstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Models
{
    [Table("Receta")]
    public class Receta
    {

        [Key]
        [Required]
        [Display(Name = "idReceta")]
        public int IdReceta { get; set; }

        [Required(ErrorMessage = "Ingresa el {0}")]
        [Display(Name = "observaciones")]
        public string Observaciones { get; set; }

        public Consulta Consulta { get; set; }

        public List<Tratamiento> Tratamientos { get; set; }

        public Receta(AReceta receta)
        {
            this.IdReceta = receta.IdReceta;
            this.Observaciones = receta.Observaciones;

        }

        public Receta()
        {

        }



    }
}
