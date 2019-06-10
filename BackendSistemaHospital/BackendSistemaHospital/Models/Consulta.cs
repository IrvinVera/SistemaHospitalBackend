using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BackendSistemaHospital.Abstractas;

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

        public int PersonaIdPersona { get; set; }


        public Consultorio Consultorio { get; set; }

        public int ConsultorioIdConsultorio {get; set;}

        public int RecetaForeignKey { get; set; }
        public Receta Receta { get; set; }

        public Consulta() { }

        public Consulta(AConsulta consulta)
        {
            this.HoraInicio = consulta.HoraInicio;
            this.HoraFin = consulta.HoraFin;
            this.IdConsulta = consulta.IdConsulta;
            this.ConsultorioIdConsultorio = consulta.Consultorio.IdConsultorio;
            this.PersonaIdPersona = consulta.Persona.IdPersona;
            this.Persona.IdPersona = consulta.Persona.IdPersona;
            this.RecetaForeignKey = consulta.Receta.IdReceta;
        }


    }
}
