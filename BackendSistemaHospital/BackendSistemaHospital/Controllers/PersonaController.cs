using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BackendSistemaHospital.Concretas;
using BackendSistemaHospital.ConcretasPersistencia;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendSistemaHospital.Controllers
{
    [Route("Persona")]
    [ApiController]
    public class PersonaController : ControllerBase
    {

        [HttpPost]
        [Route("registrar")]
        public ActionResult Registrar([FromBody] Persona persona)
        {
            if (!persona.validarDatos())
            {
                return BadRequest();
            }
            PersonaImp personaImp = new PersonaImp(new PersonaPersistencia());
            bool seGuardo =  personaImp.Registar(persona);
            if (seGuardo)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("prueba")]
        public ActionResult<Persona> Hola()
        {
            Persona persona = new Persona();

            return persona;
        }





    }
}