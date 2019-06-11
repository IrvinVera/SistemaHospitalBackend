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
    [Route("api/Consulta")]
    [ApiController]
    [Authorize]
    public class ConsultaController : ControllerBase
    {
        [HttpPost]
        [Route("registrar")]
        public ActionResult Registrar([FromBody]Consulta consulta)
        {
            if (!consulta.validarDatos())
            {
                return BadRequest();
            }
            ConsultaImp consultaImp = new ConsultaImp(new ConsultaPersistencia());

            bool seGuardo = consultaImp.Registrar(consulta);

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
        [Route("obtenerConsultasPorIdPaciente")]
        public ActionResult<List<AConsulta>> ObtenerConsultasPorIdPaciente(int idPaciente)
        {
            List<AConsulta> consultasDePaciente;
            if(idPaciente <= 0)
            {
                return BadRequest();
            }

            ConsultaImp consultaImp = new ConsultaImp(new ConsultaPersistencia());
            consultasDePaciente = consultaImp.ObtenerConsultasPorPaciente(idPaciente);
            return consultasDePaciente;
        }
    }
}