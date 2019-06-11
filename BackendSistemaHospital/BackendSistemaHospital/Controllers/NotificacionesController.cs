using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendSistemaHospital.HubConfig;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace BackendSistemaHospital.Controllers
{
    [Route("notificaciones")]
    [ApiController]
    public class NotificacionesController : ControllerBase
    {
        private IHubContext<Notificaciones> _hub;

        public NotificacionesController(IHubContext<Notificaciones> hub)
        {
            _hub = hub;
        }

        [HttpPost]
        [Route("solicitarPaciente")]
        public ActionResult SolicitarPaciente()
        {
            _hub.Clients.All.SendAsync("solicitarPaciente", 1);
            return Ok();
        }
    }
}