using BackendSistemaHospital.Abstractas;
using BackendSistemaHospital.InterfacesPersistencia;
using BackendSistemaHospital.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BackendSistemaHospital.ConcretasPersistencia
{
    public class PersonaPersistencia : IPersonaPersistencia
    {        
       
        public bool EditarBD(APersona persona)
        {
            throw new NotImplementedException();
        }

        public bool EliminarBD(int idPersona)
        {
            throw new NotImplementedException();
        }

        public bool RegistrarBD(APersona persona)
        {
            bool seRegistro = true;            
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();    
            optionsBuilder.UseSqlServer(Startup.urlConexion);
            using (var context = new ApplicationContext(optionsBuilder.Options))
            {
                try
                {
                    Persona personaBD = new Persona(persona);
                    context.Add(personaBD);
                    context.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    seRegistro = false;
                }
            }
            return seRegistro;

        }
    }
}
