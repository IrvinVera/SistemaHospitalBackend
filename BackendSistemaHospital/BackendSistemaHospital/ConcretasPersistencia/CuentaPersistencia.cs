using BackendSistemaHospital.Abstractas;
using BackendSistemaHospital.InterfacesPersistencia;
using BackendSistemaHospital.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BackendSistemaHospital.ConcretasPersistencia
{
    public class CuentaPersistencia : ICuentaPersistencia
    {
        public APersona LoginBD(ACuenta cuenta)
        {
            SHA256 mySHA256 = SHA256.Create();
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(Startup.urlConexion);
            using (var context = new ApplicationContext(optionsBuilder.Options))            
            {
                byte[] bytes = mySHA256.ComputeHash(Encoding.UTF8.GetBytes(cuenta.Contrasena));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                string contraseñasha = builder.ToString();
                Persona personaBD = context.Cuenta.Where(cuentaBD => cuentaBD.NombreUsuario == cuenta.NombreUsuario
                && cuentaBD.Contrasena == contraseñasha).Select(cuentadb => cuentadb.Persona).FirstOrDefault();
                APersona persona = null;
                if (personaBD != null)
                {
                    persona = new APersona()
                    {
                        IdPersona = personaBD.IdPersona,
                        Rol = personaBD.Rol
                    };
                }                
                return persona;
            }
            
        }

        public bool RegistrarBD(ACuenta cuenta)


        {
            SHA256 mySHA256 = SHA256.Create();
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(Startup.urlConexion);
            using (var context = new ApplicationContext(optionsBuilder.Options)) {
                byte[] bytes = mySHA256.ComputeHash(Encoding.UTF8.GetBytes(cuenta.Contrasena));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                string contraseñasha = builder.ToString();
                cuenta.Contrasena = contraseñasha;
                Cuenta cuentaNueva = new Cuenta() ;
                cuentaNueva.Contrasena = contraseñasha;
                cuentaNueva.NombreUsuario = cuenta.NombreUsuario;
                cuentaNueva.PersonaForeignKey = cuenta.Persona.IdPersona;
                context.Cuenta.Add(cuentaNueva);
                context.SaveChanges();

            }


            return true;
        }
    }
}
