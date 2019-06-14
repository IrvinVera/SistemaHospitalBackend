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
    public class MedicamentoPersistencia : IMedicamentoPersistencia
    {
        public bool editarBD(AMedicamento medicamento)
        {
            bool seActualizo = true;
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(Startup.urlConexion);
            using (var context = new ApplicationContext(optionsBuilder.Options))
            {
                try
                {
                    Medicamento MedicamentoBD = new Medicamento(medicamento);
                    context.Update(MedicamentoBD);
                    context.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    seActualizo = false;
                }
            }
            return seActualizo;
        }

        public bool eliminarBD(int idMedicamento)
        {
            bool seElimino = true;
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(Startup.urlConexion);
            using (var context = new ApplicationContext(optionsBuilder.Options))
            {
                try
                {

                    Medicamento medicamento = context.Medicamento.Find(idMedicamento);
                    context.Remove(medicamento);
                    context.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    seElimino = false;
                }
            }
            return seElimino;
        }

        public List<AMedicamento> obtenerMedicamentosBD()
        {
            List<Medicamento> medicamentos;
            List<AMedicamento> medicamentosEncontrados = new List<AMedicamento>();
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(Startup.urlConexion);
            using (var context = new ApplicationContext(optionsBuilder.Options))
            {
                try
                {
                    medicamentos = context.Medicamento.ToList();
                    foreach (Medicamento medicamento in medicamentos)
                    {
                        AMedicamento medicamentoEncontrado = new AMedicamento();
                        medicamentoEncontrado.IdMedicamento = medicamento.IdMedicamento;
                        medicamentoEncontrado.Nombre = medicamento.Nombre;
                        medicamentoEncontrado.Presentacion = medicamento.Presentacion;
                        medicamentoEncontrado.Cantidad = medicamento.Cantidad;
                        medicamentoEncontrado.Compuesto = medicamento.Compuesto;

                        medicamentosEncontrados.Add(medicamentoEncontrado);

                    }
                }
                catch (DbUpdateException)
                {

                }
            }
            return medicamentosEncontrados;
        }

        public AMedicamento registrarBD(AMedicamento medicamento)
        {
            bool seRegistro = true;
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(Startup.urlConexion);
            using (var context = new ApplicationContext(optionsBuilder.Options))
            {
                try
                {
                    Medicamento medicamentoBD = new Medicamento(medicamento);
                    context.Add(medicamentoBD);
                    context.SaveChanges();
                    medicamento.IdMedicamento = medicamentoBD.IdMedicamento;
                }
                catch(DbUpdateException)
                {
                    seRegistro = false;
                }
            }
            return medicamento;
        }
    }
}
