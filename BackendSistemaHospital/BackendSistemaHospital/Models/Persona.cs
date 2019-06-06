using BackendSistemaHospital.Abstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Models
{
    [Table("Persona")]
    public class Persona
    {
        [Key]
        [Required]
        [Display(Name = "idPersona")]
        public int IdPersona { get; set; }


        [Required(ErrorMessage = "Ingresa el {0}")]
        [Display(Name = "nombre")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "Ingresa el {0}")]
        [Display(Name = "apellidos")]
        public string Apellidos { get; set; }


        [Required(ErrorMessage = "Ingresa el {0}")]
        [Display(Name = "idPersona")]
        public string Correo { get; set; }


        [Required(ErrorMessage = "Ingresa el {0}")]
        [Display(Name = "telefono")]
        public string Telefono { get; set; }


        [Required(ErrorMessage = "Ingresa el {0}")]
        [Display(Name = "genero")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "Ingresa el {0}")]
        [Display(Name = "rol")]
        public string Rol { get; set; }

        [Required(ErrorMessage = "Ingresa el {0}")]
        [Display(Name = "fechaNaimiento")]
        public DateTime FechaNacimiento { get; set; }

        public Cuenta Cuenta { get; set; }

        public Consultorio Consultorio { get; set; }

        public List<Consulta> Consultas { get; set; }

        public List<SignoVital> SignosVitales { get; set; }

        public Persona() { }

        public Persona(APersona persona)
        {
            this.Nombre = persona.Nombre;
            this.Apellidos = persona.Apellidos;
            this.Correo = persona.Correo;
            this.Telefono = persona.Telefono;
            this.Genero = persona.Genero;
            this.Rol = persona.Rol;
            this.FechaNacimiento = persona.FechaNacimiento;
            this.IdPersona = persona.IdPersona;
        }

    }
}
