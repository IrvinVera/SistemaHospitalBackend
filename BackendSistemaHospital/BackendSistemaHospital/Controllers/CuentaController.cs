using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BackendSistemaHospital.Abstractas;
using BackendSistemaHospital.Concretas;
using BackendSistemaHospital.ConcretasPersistencia;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BackendSistemaHospital.Controllers
{
    [Route("api/Cuenta")]
    [ApiController]
    public class CuentaController : ControllerBase
    {

        [HttpPost]
        [Route("login")]
        public ActionResult Login([FromBody]ACuenta cuenta)
        {

            string rol;
            var secretKey = Startup.cadenaToken;
            var key = Encoding.ASCII.GetBytes(secretKey);
            CuentaImp cuentaImp = new CuentaImp(new CuentaPersistencia());
            rol = cuentaImp.Login(cuenta);
            if (rol == null)
            {
                return NotFound();
            }

            var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, cuenta.NombreUsuario),
            new Claim(ClaimTypes.Actor, rol)
        };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,                
                Expires = DateTime.UtcNow.AddHours(8),                
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            var token = tokenHandler.WriteToken(createdToken);

            return Ok(new { rol, token });
        }
    }
}