﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BackendSistemaHospital.Abstractas;
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


        [HttpPost]
        [Route("editar")]
        public ActionResult Editar([FromBody] Persona persona)
        {
            if (!persona.validarDatos())
            {
                return BadRequest();
            }
            PersonaImp personaImp = new PersonaImp(new PersonaPersistencia());
            bool seActualizo = personaImp.Editar(persona);
            if (seActualizo)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("eliminar")]
        public ActionResult Eliminar(int idPersona)
        {
            if (idPersona < 0)
            {
                return BadRequest();
            }
            PersonaImp personaImp = new PersonaImp(new PersonaPersistencia());
            bool seElimino = personaImp.Eliminar(idPersona);
            if (seElimino)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("buscarPersonaId")]
        public ActionResult<APersona> BuscarPersonaId(int idPersona)
        {
            APersona persona;

            if (idPersona < 0)
            {
                return BadRequest();
            }

            PersonaImp personaImp = new PersonaImp(new PersonaPersistencia());
            persona = personaImp.BuscarPersonaId(idPersona);

            return persona;

        }

        [HttpGet]
        [Route("buscarPersonaNombre")]
        public ActionResult<APersona> BuscarPersonaNombre(string nombrePersona)
        {
            APersona persona;

            if (nombrePersona == null)
            {
                return BadRequest();
            }

            PersonaImp personaImp = new PersonaImp(new PersonaPersistencia());
            persona = personaImp.BuscarPersonaNombre(nombrePersona);

            return persona;

        }


        [HttpGet]
        [Route("obtenerPersonas")]
        public ActionResult<List<APersona>> ObtenerPersonas()
        {

            List<APersona> personas;

            PersonaImp personaImp = new PersonaImp(new PersonaPersistencia());
            personas = personaImp.ObtenerPersonas();

            return personas;

        }

    }
}