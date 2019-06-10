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
    [Route("api/Tratamiento")]
    [ApiController]
    public class TratamientoController : ControllerBase
    {
        [HttpPost]
        [Route("registrar")]
        public ActionResult Registrar([FromBody] Tratamiento tratamiento)
        {
            if (!tratamiento.validarDatos())
            {
                return BadRequest();
            }
            TratamientoImp tratamientoImp = new TratamientoImp(new TratamientoPersistencia());
            bool seGuardo = tratamientoImp.guardar(tratamiento);
            if (seGuardo)
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