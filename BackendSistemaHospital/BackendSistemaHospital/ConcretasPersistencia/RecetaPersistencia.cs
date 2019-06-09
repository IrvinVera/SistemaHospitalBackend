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
    public class RecetaPersistencia : IRecetaPersistencia
    {
        public bool RegistrarBD(AReceta receta)
        {
            bool seRegistro = true;
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(Startup.urlConexion);
            using (var context = new ApplicationContext(optionsBuilder.Options))
            {
                try
                {
                    Receta recetaBD = new Receta(receta);
                    context.Add(recetaBD);
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
