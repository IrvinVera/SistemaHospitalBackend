using BackendSistemaHospital.Abstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Models
{
    [Table("SignoVital")]
    public class SignoVital
    {


        [Key]
        [Required]
        [Display(Name = "idSignoVital")]
        public int IdSignoVital { get; set; }

        [Required(ErrorMessage = "Ingresa el {0}")]
        [Display(Name = "estatura")]
        public Double Estatura { get; set; }

        [Required(ErrorMessage = "Ingresa el {0}")]
        [Display(Name = "peso")]
        public Double Peso { get; set; }


        [Required(ErrorMessage = "Ingresa el {0}")]
        [Display(Name = "fecha")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Ingresa el {0}")]
        [Display(Name = "presion")]
        public Double Presion { get; set; }

        [Required(ErrorMessage = "Ingresa el {0}")]
        [Display(Name = "temperatura")]
        public Double Temperatura { get; set; }

        public int PersonaidPersona { get; set; }

        public Persona Persona { get; set; }


        public SignoVital() { }

        public SignoVital(ASignoVital signoVital)
        {
            this.Estatura = signoVital.Estatura;
            this.Fecha = signoVital.Fecha;
            this.Peso = signoVital.Peso;
            this.Presion = signoVital.Presion;
            this.Temperatura = signoVital.Temperatura;
            this.PersonaidPersona = signoVital.Persona.IdPersona;

        }


    }
}
