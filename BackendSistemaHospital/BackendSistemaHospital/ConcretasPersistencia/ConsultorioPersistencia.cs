using BackendSistemaHospital.Abstractas;
using BackendSistemaHospital.InterfacesPersistencia;
using BackendSistemaHospital.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.ConcretasPersistencia
{
    public class ConsultorioPersistencia : IConsultorioPersistencia
    {
        public bool RegistrarBD(AConsultorio Consultorio)
        {
            bool seRegistro = true;
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(Startup.urlConexion);
            using (var context = new ApplicationContext(optionsBuilder.Options))
            {
                try
                {
                    Persona persona = context.Persona.Where(x => x.Rol.Equals("Consultorio")).ToList().First();
                    Consultorio consultorioBD = new Consultorio(Consultorio);
                    consultorioBD.PersonaForeignKey = persona.IdPersona;
                    
                   
                    context.Add(consultorioBD);
                    context.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    seRegistro = false;
                }

            }
            return seRegistro;
        }


        public bool EditarEstadoBD(int idConsultorio) {
            bool seActualizoEstado = true;

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(Startup.urlConexion);
            using (var context = new ApplicationContext(optionsBuilder.Options))
            {
                try
                {
                    Consultorio consultorio;

                    consultorio = context.Consultorio.Find(idConsultorio);

                    if (consultorio.Estado != "Ocupado")
                    {
                        consultorio.Estado = "Ocupado";
                    }
                    else {
                        consultorio.Estado = "Disponible";
                    }
                    

                    context.Update(consultorio);
                    context.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    seActualizoEstado = false;
                }
            }

            return seActualizoEstado;
        }


        public bool EliminarBD(int idConsultorio) {
            bool seElimino = true;

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(Startup.urlConexion);
            using (var context = new ApplicationContext(optionsBuilder.Options))
            {
                try
                {

                    Consultorio consultorio = context.Consultorio.Find(idConsultorio);
                    context.Remove(consultorio);
                    context.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    seElimino = false;
                }
            }
            return seElimino;

        }

    }
}
