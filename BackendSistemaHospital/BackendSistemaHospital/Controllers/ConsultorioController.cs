using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendSistemaHospital.Concretas;
using BackendSistemaHospital.ConcretasPersistencia;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendSistemaHospital.Controllers
{
    [Route("Consultorio")]
    [ApiController]
    public class ConsultorioController : ControllerBase
    {

        [HttpPost]
        [Route("registrar")]
        public ActionResult Registrar([FromBody] Consultorio Consultorio)
        {
            if (!Consultorio.validarDatos())
            {
                return BadRequest();
            }

            ConsultorioImp consultorioImp = new ConsultorioImp(new ConsultorioPersistencia());
            bool seGuardo = consultorioImp.Registrar(Consultorio);

            if (seGuardo) {
                return Ok();
            }
            else{
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("editarEstado")]
        public ActionResult EditarEstado(int idConsultorio)
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
        [Route("eliminar")]
        public ActionResult Eliminar(int idConsultorio)
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

    }
}