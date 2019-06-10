using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendSistemaHospital.Abstractas;
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
        public ActionResult<int> Registrar([FromBody] Receta receta)
        {
            if (!receta.validarDatos())
            {
                return BadRequest();
            }
            RecetaImp recetaImp = new RecetaImp(new RecetaPersistencia());
            int idReceta = recetaImp.Registrar(receta);
            return idReceta;
        }

        [HttpGet]
        [Route("obtenerRecetaDeConsulta")]
        public ActionResult<AReceta> obtenerRecetaDeConsulta(int idConsulta)
        {
            AReceta receta;
            if(idConsulta < 0)
            {
                return BadRequest();
            }
            RecetaImp recetaImp = new RecetaImp(new RecetaPersistencia());
            receta = recetaImp.buscarRecetaDeConsulta(idConsulta);
            return receta;
        }
    }
}