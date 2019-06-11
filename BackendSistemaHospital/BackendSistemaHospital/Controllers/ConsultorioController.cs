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
    [Route("api/Consultorio")]
    [ApiController]
    [Authorize]
    public class ConsultorioController : ControllerBase
    {

        [HttpPost]
        [Route("registrar")]
        public ActionResult<AConsultorio> Registrar([FromBody] Consultorio Consultorio)
        {
            if (!Consultorio.validarDatos())
            {
                return BadRequest();
            }

            ConsultorioImp consultorioImp = new ConsultorioImp(new ConsultorioPersistencia());
            AConsultorio consultorio;
            consultorio = consultorioImp.Registrar(Consultorio);

            return Consultorio;
        }


        [HttpPost]
        [Route("editarEstado")]
        public ActionResult EditarEstado([FromBody]int idConsultorio)
        {
            if (idConsultorio < 0)
            {
                return BadRequest();
            }

            ConsultorioImp consultorioImp = new ConsultorioImp(new ConsultorioPersistencia());
            bool seActualizo = consultorioImp.EditarEstado(idConsultorio);

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
        [Route("asignarDoctor")]
        public ActionResult AsignarDoctor(int idConsultorio, int idPersona)
        {
            if (idConsultorio < 0 && idPersona < 0)
            {
                return BadRequest();
            }

            ConsultorioImp consultorioImp = new ConsultorioImp(new ConsultorioPersistencia());
            bool seActualizo = consultorioImp.AsignarDoctor(idConsultorio, idPersona);

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
        [Route("quitarDoctor")]
        public ActionResult QuitarDoctor([FromBody]int idConsultorio)
        {
            if (idConsultorio < 0 )
            {
                return BadRequest();
            }

            ConsultorioImp consultorioImp = new ConsultorioImp(new ConsultorioPersistencia());
            bool seActualizo = consultorioImp.QuitarDoctor(idConsultorio);

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
        public ActionResult Eliminar([FromBody]int idConsultorio)
        {
            if (idConsultorio < 0)
            {
                return BadRequest();
            }

            ConsultorioImp consultorioImp = new ConsultorioImp(new ConsultorioPersistencia());
            bool seElimino = consultorioImp.Eliminar(idConsultorio);

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
        [Route("obtenerTodosLosConsultorios")]
        public ActionResult<List<AConsultorio>> ObtenerTodosLosConsultorios()
        {
            List<AConsultorio> consultorios = new List<AConsultorio>();

            ConsultorioImp consultorioImp = new ConsultorioImp(new ConsultorioPersistencia());
            consultorios = consultorioImp.obtenerTodosLosConsultorios();

            return consultorios;
        }

    }
}