using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Transactions;
using BackendSistemaHospital.Abstractas;
using BackendSistemaHospital.Concretas;
using BackendSistemaHospital.ConcretasPersistencia;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendSistemaHospital.Controllers
{
    [Route("api/Persona")]
    [ApiController]

    public class PersonaController : ControllerBase
    {

        [HttpPost]
        [Route("registrar")]
        public ActionResult<APersona> Registrar([FromBody] Cuenta cuenta)
        {
            PersonaImp personaImp = new PersonaImp(new PersonaPersistencia());
            APersona personaRegistrada;
            if (!personaImp.validarNombreUsuarioRepetido(cuenta.NombreUsuario))
            {
                using (TransactionScope tran = new TransactionScope())
                {           
                    personaRegistrada = personaImp.Registar(cuenta.Persona);

                    CuentaImp cuentaImp = new CuentaImp(new CuentaPersistencia());
                    cuenta.Persona.IdPersona = personaRegistrada.IdPersona;
                    cuentaImp.Registar(cuenta);

                    tran.Complete();
                }
            }
            else {
                return BadRequest();
            }
            return personaRegistrada;
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
        public ActionResult Eliminar([FromBody]int idPersona)
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
        [Route("obtenerPersonas")]
        public ActionResult<List<APersona>> ObtenerPersonas()
        {

            List<APersona> personas;

            PersonaImp personaImp = new PersonaImp(new PersonaPersistencia());
            personas = personaImp.ObtenerPersonas();

            return personas;

        }

        [HttpGet]
        [Route("obtenerMedicos")]
        public ActionResult<List<APersona>> ObtenerMedicos()
        {
            List<APersona> personas;

            PersonaImp personaImp = new PersonaImp(new PersonaPersistencia());
            personas = personaImp.ObtenerMedicos();

            return personas;

        }

    }
}