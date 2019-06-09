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
    public class ConsultaPersistencia : IConsultaPersistencia
    {
        public List<AConsulta> obtenerConsultasDePacienteBD(int IdPersona)
        {
            List<Consulta> consultas;
            List<AConsulta> consultasEncontradas = new List<AConsulta>();
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(Startup.urlConexion);
            using (var context = new ApplicationContext(optionsBuilder.Options))
            {
                try
                {
                    consultas = context.Consulta.Where(x => x.PersonaIdPersona.Equals(IdPersona)).ToList();
                    
                    foreach(Consulta consulta in consultas)
                    {
                        AConsulta consultaEncontrada = new AConsulta();
                        consultaEncontrada.IdConsulta = consulta.IdConsulta;
                        consultaEncontrada.HoraInicio = consulta.HoraInicio;
                        consultaEncontrada.HoraFin = consulta.HoraFin;

                        AReceta receta = new AReceta();
                        Receta recetaBD = new Receta();
                        receta.IdReceta = consulta.RecetaForeignKey;
                        recetaBD = context.Receta.Find(consulta.RecetaForeignKey);
                        receta.Observaciones = recetaBD.Observaciones;

                        List<Tratamiento> tratamientosDeRecetaBD = new List<Tratamiento>();
                        tratamientosDeRecetaBD = context.Tratamiento.Where(x => x.RecetaIdReceta.Equals(receta.IdReceta)).ToList();
                        List<ATratamiento> tratamientosDeReceta = new List<ATratamiento>();
                        foreach(Tratamiento tratamiento in tratamientosDeRecetaBD)
                        {
                            ATratamiento tratamientoEncontrado = new ATratamiento();
                            tratamientoEncontrado.IdTratamiento = tratamiento.IdTratamiento;
                            tratamientoEncontrado.Tiempo = tratamiento.Tiempo;
                            tratamientoEncontrado.Cantidad = tratamiento.Cantidad;
                            tratamientoEncontrado.Frecuencia = tratamiento.Frecuencia;

                            List<AMedicamento> medicamentosDeTratamiento = new List<AMedicamento>();
                            List<MedicamentoTratamiento> medicamentoTratamientosBD = new List<MedicamentoTratamiento>();
                            medicamentoTratamientosBD = context.MedicamentoTratamiento.Where(x => x.TratamientoId.Equals(tratamientoEncontrado.IdTratamiento)).ToList();

                            foreach(MedicamentoTratamiento medicamentoTratamiento in medicamentoTratamientosBD){
                                AMedicamento medicamentoEncontrado = new AMedicamento();
                                Medicamento medicamentoBD = new Medicamento();
                                medicamentoBD = context.Medicamento.Find(medicamentoTratamiento.MedicamentoId);

                                medicamentoEncontrado.IdMedicamento = medicamentoBD.IdMedicamento;
                                medicamentoEncontrado.Nombre = medicamentoBD.Nombre;
                                medicamentoEncontrado.Cantidad = medicamentoBD.Cantidad;
                                medicamentoEncontrado.Compuesto = medicamentoBD.Compuesto;
                                medicamentoEncontrado.Presentacion = medicamentoBD.Presentacion;

                                medicamentosDeTratamiento.Add(medicamentoEncontrado);
                            }
                            tratamientoEncontrado.Medicamentos = medicamentosDeTratamiento;
                           
                            tratamientosDeReceta.Add(tratamientoEncontrado);
                        }
                        receta.Tratamientos = tratamientosDeReceta;

                        consultaEncontrada.Receta = receta;

                        APersona paciente = new APersona();
                        Persona personaBD = new Persona();
                        personaBD = context.Persona.Find(consulta.PersonaIdPersona);
                        paciente.IdPersona = personaBD.IdPersona;
                        paciente.Nombre = personaBD.Nombre;
                        paciente.Rol = personaBD.Rol;
                        paciente.Telefono = personaBD.Telefono;
                        paciente.FechaNacimiento = personaBD.FechaNacimiento;
                        paciente.Apellidos = personaBD.Apellidos;
                        paciente.Correo = personaBD.Correo;
                        paciente.Genero = personaBD.Genero;

                        consultaEncontrada.Persona = paciente;

                        consultasEncontradas.Add(consultaEncontrada);
                        

                    }
                }
                catch(DbUpdateException)
                {

                }
            }
            return consultasEncontradas;
        }

        public bool RegistrarBD(AConsulta consulta)
        {
            bool seRegistro = true;
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(Startup.urlConexion);
            using (var context = new ApplicationContext(optionsBuilder.Options))
            {
                try
                {
                    Consulta consultaBD = new Consulta(consulta);
                    context.Add(consultaBD);
                    context.SaveChanges();

                }
                catch(DbUpdateException)
                {
                    seRegistro = false;
                }
            }
            return seRegistro;
        }
    }
}
