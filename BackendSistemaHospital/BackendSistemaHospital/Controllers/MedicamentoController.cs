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
    [Route("api/Medicamento")]
    [ApiController]
    public class MedicamentoController : ControllerBase
    {
        [HttpPost]
        [Route("registrar")]
        public ActionResult Registrar([FromBody] Medicamento medicamento)
        {
            if (!medicamento.validarDatos())
            {
                return BadRequest();
            }
            MedicamentoImp medicamentoImp = new MedicamentoImp(new MedicamentoPersistencia());
            bool seGuardo = medicamentoImp.registrar(medicamento);
            if (seGuardo)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("editar")]
        public ActionResult Editar([FromBody] Medicamento medicamento)
        {
            if (!medicamento.validarDatos())
            {
                return BadRequest();
            }
            MedicamentoImp medicamentoImp = new MedicamentoImp(new MedicamentoPersistencia());
            bool seActualizo = medicamentoImp.editar(medicamento);
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
        public ActionResult Eliminar(int idMedicamento)
        {
            if (idMedicamento < 0)
            {
                return BadRequest();
            }
            MedicamentoImp medicamentoImp = new MedicamentoImp(new MedicamentoPersistencia());
            bool seActualizo = medicamentoImp.eliminar(idMedicamento);
            if (seActualizo)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("obtenerMedicamentos")]
        public ActionResult<List<AMedicamento>> ObtenerMedicamentos()
        {
            List<AMedicamento> medicamentos;
            MedicamentoImp medicamentoImp = new MedicamentoImp(new MedicamentoPersistencia());
            medicamentos = medicamentoImp.obtenerMedicamentos();
            return medicamentos;
        }
    }
}