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
    public class TratamientoPersistencia : ITratamientoPersistencia
    {
        public bool RegistrarBD(ATratamiento tratamiento)
        {
            bool seRegistro = true;
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(Startup.urlConexion);
            using (var context = new ApplicationContext(optionsBuilder.Options))
            {
                try
                {
                    Tratamiento tratamientoBD = new Tratamiento(tratamiento);       
                    context.Add(tratamientoBD);
                    context.SaveChanges();
                    MedicamentoTratamiento medicamentoTratamiento = new MedicamentoTratamiento();
                    foreach (AMedicamento medicamento in tratamiento.Medicamentos)
                    {
                        medicamentoTratamiento.MedicamentoId = medicamento.IdMedicamento;
                        medicamentoTratamiento.TratamientoId = tratamientoBD.IdTratamiento;
                        context.Add(medicamentoTratamiento);
                        context.SaveChanges();
                    }
                }
                catch (DbUpdateException)
                {
                    seRegistro = false;
                }
                return seRegistro;
            }


        }
    }
}
