﻿using System;
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
    [Route("SignoVital")]
    [ApiController]
    public class SignoVitalController : ControllerBase
    {

        [HttpPost]
        [Route("registrar")]
        public ActionResult Registrar([FromBody] SignoVital signoVital)
        {
            if (!signoVital.validarDatos())
            {
                return BadRequest();
            }

            SignoVitalImp signoVitalImp = new SignoVitalImp(new SignoVitalPersistencia());

            bool seGuardo = signoVitalImp.Registar(signoVital);
            if (seGuardo)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("consultarPorId")]
        public ActionResult<List<ASignoVital>> ConsultarPorId(int idPersona)
        {

            List<ASignoVital> signosVitales;

            if (idPersona < 0)
            {
                return BadRequest();
            }

            SignoVitalImp signoVitalImp = new SignoVitalImp(new SignoVitalPersistencia());

            signosVitales = signoVitalImp.ConsultarPorId(idPersona);

            return signosVitales;

        }


    }
}