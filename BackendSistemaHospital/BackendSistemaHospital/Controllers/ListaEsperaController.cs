using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendSistemaHospital.Abstractas;
using BackendSistemaHospital.Concretas;
using BackendSistemaHospital.ConcretasPersistencia;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendSistemaHospital.Controllers
{
    [Route("api/ListaEspera")]
    [ApiController]
    [Authorize]
    public class ListaEsperaController : ControllerBase
    {

        [HttpPost]
        [Route("agregar")]
        public ActionResult Agregar(int idPersona)
        {
            if (idPersona < 0)
            {
                return BadRequest();
            }

            if (Startup.listaEspera.Contains(idPersona))
            {

                return BadRequest();
            }
            else
            {

                PersonaImp personaImp = new PersonaImp(new PersonaPersistencia());
                APersona personaRegistrada;
                personaRegistrada = personaImp.BuscarPersonaId(idPersona);

                if (personaRegistrada != null)
                {
                    Startup.listaEspera.Add(idPersona);
                }
                else
                {
                    return BadRequest();
                }


            }

            return Ok();
        }


        [HttpPost]
        [Route("remover")]
        public ActionResult Remover(int idPersona)
        {
            Startup.listaEspera.Remove(idPersona);

            return Ok();
        }


        [HttpGet]
        [Route("obtenerTotalPacientes")]
        public ActionResult ObtenerTotalPacientes()
        {
            return Ok(new { NoPacientesEspera = Startup.listaEspera.Count() });
        }

        [HttpGet]
        [Route("obtenerPosicionPaciente")]
        public ActionResult ObtenerPosicionPaciente(int idPaciente)
        {
            if(Startup.listaEspera.IndexOf(idPaciente) >= 0)
            {
               return Ok(new { NoPacientesPrevios = Startup.listaEspera.IndexOf(idPaciente) });
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("obtenerTodosLosPacientes")]
        public ActionResult<List<APersona>> ObtenerTodosLosPacientes()
        {
            List<APersona> personasEnFila = new List<APersona>();

            foreach (int element in Startup.listaEspera)
            {
                PersonaImp personaImp = new PersonaImp(new PersonaPersistencia());
                APersona personaRegistrada;
                personaRegistrada = personaImp.BuscarPersonaId(element);

                personasEnFila.Add(personaRegistrada);
            }
            return personasEnFila;
        }


        [HttpGet]
        [Route("posponerCita")]
        public ActionResult PosponerCita()
        {
            int numeroACambiar = Startup.listaEspera[0];
            int nuevoNumeroPrimero = Startup.listaEspera[1];
            int nuevoNumeroSegundo = Startup.listaEspera[2];


            Startup.listaEspera[0] = nuevoNumeroPrimero;
            Startup.listaEspera[1] = nuevoNumeroSegundo;
            Startup.listaEspera[2] = numeroACambiar;

            return Ok();


        }
    }
}