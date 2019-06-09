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
    [Route("Receta")]
    [ApiController]
    public class RecetaController : ControllerBase
    {
        [HttpPost]
        [Route("registrar")]
        public ActionResult Registrar([FromBody] Receta receta)
        {
            if (!receta.validarDatos())
            {
                return BadRequest();
            }
            RecetaImp recetaImp = new RecetaImp(new RecetaPersistencia());
            bool seGuardo = recetaImp.Registrar(receta);
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