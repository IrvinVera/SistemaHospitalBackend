using BackendSistemaHospital.Abstractas;
using BackendSistemaHospital.InterfacesPersistencia;
using BackendSistemaHospital.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BackendSistemaHospital.ConcretasPersistencia
{
    public class PersonaPersistencia : IPersonaPersistencia
    {

        public bool EliminarBD(int idPersona)
        {

            bool seElimino = true;
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(Startup.urlConexion);
            using (var context = new ApplicationContext(optionsBuilder.Options))
            {
                try { 
     
                  Persona persona =  context.Persona.Find(idPersona);
                  context.Remove(persona);
                  context.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    seElimino = false;
                }
            }
            return seElimino;

        }

        public bool EditarBD(APersona persona)
        {
            bool seActualizo = true;
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(Startup.urlConexion);
            using (var context = new ApplicationContext(optionsBuilder.Options))
            {
                try
                {
                    Persona personaBD = new Persona(persona);
                    context.Update(personaBD);
                    context.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    seActualizo = false;
                }
            }
            return seActualizo;
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

        public List<APersona> ObtenerPersonas()
        {
            throw new NotImplementedException();
        }

        public APersona BuscarPersonaNombre(string Nombre)
        {
            throw new NotImplementedException();
        }

        public APersona BuscarPersonaIdBD(int IdPersona)
        {
            Persona persona;
            APersona personaEncontrada = new Concretas.Persona();
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(Startup.urlConexion);
            using (var context = new ApplicationContext(optionsBuilder.Options))
            {
                try
                {
                    persona = context.Persona.Find(IdPersona);

                    personaEncontrada.Nombre = persona.Nombre;
                    personaEncontrada.Apellidos = persona.Apellidos;
                    personaEncontrada.FechaNacimiento = persona.FechaNacimiento;
                    personaEncontrada.Correo = persona.Correo;
                    personaEncontrada.IdPersona = persona.IdPersona;
                    personaEncontrada.Genero = persona.Genero;
                    personaEncontrada.Rol = persona.Rol;
                    personaEncontrada.Telefono = persona.Telefono;

                }
                catch (DbUpdateException)
                {
                    
                }
            }

            return personaEncontrada;
        }
    }
}
