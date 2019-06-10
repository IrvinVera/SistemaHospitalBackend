using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BackendSistemaHospital.Abstractas;
using BackendSistemaHospital.Concretas;
using BackendSistemaHospital.ConcretasPersistencia;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendSistemaHospital.Controllers
{
    [Route("Persona")]
    [ApiController]

    public class PersonaController : ControllerBase
    {

        [HttpPost]
        [Route("api/registrar")]
        public ActionResult<APersona> Registrar([FromBody] Persona persona)
        {
            if (!persona.validarDatos())
            {
                return BadRequest();
            }

            PersonaImp personaImp = new PersonaImp(new PersonaPersistencia());
            APersona personaRegistrada;
            personaRegistrada =  personaImp.Registar(persona);

            return persona;

        }


        [HttpPost]
        [Route("api/editar")]
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
        [Route("api/eliminar")]
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
        [Route("api/buscarPersonaId")]
        public ActionResult<APersona> BuscarPersonaId([FromBody]int idPersona)
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
        [Route("api/buscarPersonaNombre")]
        public ActionResult<APersona> BuscarPersonaNombre([FromBody]string nombrePersona)
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
        [Route("buscarPersonaNombreUsuario")]
        public ActionResult<APersona> BuscarPersonaNombreUsuario(string nombreUsuarioPersona)
        {
            APersona persona;

            if (nombreUsuarioPersona == null)
            {
                return BadRequest();
            }

            PersonaImp personaImp = new PersonaImp(new PersonaPersistencia());
            persona = personaImp.BuscarPersonaNombreUsuario(nombreUsuarioPersona);

            return persona;

        }


        [HttpGet]
        [Route("api/obtenerPersonas")]
        public ActionResult<List<APersona>> ObtenerPersonas()
        {

            List<APersona> personas;

            PersonaImp personaImp = new PersonaImp(new PersonaPersistencia());
            personas = personaImp.ObtenerPersonas();

            return personas;

        }

        [HttpGet]
        [Route("api/obtenerMedicos")]
        public ActionResult<List<APersona>> ObtenerMedicos()
        {
            List<APersona> personas;

            PersonaImp personaImp = new PersonaImp(new PersonaPersistencia());
            personas = personaImp.ObtenerMedicos();

            return personas;

        }

    }
}