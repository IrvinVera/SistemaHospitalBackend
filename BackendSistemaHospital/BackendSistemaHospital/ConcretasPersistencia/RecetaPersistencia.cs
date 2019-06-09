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
        public AReceta ObtenerRecetaDeConsultaBD(int idConsulta)
        {
            Consulta consultaBD;
            Receta receta;
            AReceta recetaEncontrada = new Concretas.Receta();
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(Startup.urlConexion);
            using (var context = new ApplicationContext(optionsBuilder.Options))
            {
                try
                {
                    consultaBD = context.Consulta.Find(idConsulta);
                    receta = context.Receta.Find(consultaBD.RecetaForeignKey);
                    recetaEncontrada.IdReceta = receta.IdReceta;
                    recetaEncontrada.Observaciones = receta.Observaciones;
                }
                catch(DbUpdateException)
                {

                }
            }
            return recetaEncontrada;
        }

        public int RegistrarBD(AReceta receta)
        {
            int idRecetaCreada = 0;
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(Startup.urlConexion);
            using (var context = new ApplicationContext(optionsBuilder.Options))
            {
                try
                {
                    Receta recetaBD = new Receta(receta);
                    context.Add(recetaBD);
                    context.SaveChanges();
                    idRecetaCreada = recetaBD.IdReceta;
                }
                catch (DbUpdateException)
                {
                    
                }

            }
            return idRecetaCreada;
        }
    }
}
