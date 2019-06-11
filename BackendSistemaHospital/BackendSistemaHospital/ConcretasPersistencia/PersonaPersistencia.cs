using BackendSistemaHospital.Abstractas;
using BackendSistemaHospital.InterfacesPersistencia;
using BackendSistemaHospital.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public APersona RegistrarBD(APersona persona)
        {
                  
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();    
            optionsBuilder.UseSqlServer(Startup.urlConexion);
            using (var context = new ApplicationContext(optionsBuilder.Options))
            {
                try
                {
                    Persona personaBD = new Persona(persona);
                    context.Add(personaBD);
                    context.SaveChanges();
                    persona.IdPersona = personaBD.IdPersona;
                }
                catch (DbUpdateException)
                {

                }

            }
            return persona;

        }

        public List<APersona> ObtenerPersonasBD()
        {
            List<Persona> personas;
            List<APersona> personasEncontradas = new List<APersona>();
            

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(Startup.urlConexion);
            using (var context = new ApplicationContext(optionsBuilder.Options))
            {
                try
                {

                    personas = context.Persona.ToList();

                    foreach (Persona persona in personas)
                    {
                        APersona personaEncontrada = new APersona();

                        personaEncontrada.Nombre = persona.Nombre;
                        personaEncontrada.Apellidos = persona.Apellidos;
                        personaEncontrada.FechaNacimiento = persona.FechaNacimiento;
                        personaEncontrada.Correo = persona.Correo;
                        personaEncontrada.IdPersona = persona.IdPersona;
                        personaEncontrada.Genero = persona.Genero;
                        personaEncontrada.Rol = persona.Rol;
                        personaEncontrada.Telefono = persona.Telefono;
                        
                        personasEncontradas.Add(personaEncontrada);

                    }


                }
                catch (DbUpdateException)
                {

                }
            }



            return personasEncontradas;

        }

        public APersona BuscarPersonaNombreBD(string NombrePersona)
        {
            Persona persona;
            APersona personaEncontrada = new Concretas.Persona();
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(Startup.urlConexion);
            using (var context = new ApplicationContext(optionsBuilder.Options))
            {
                try
                {
                    persona = context.Persona.Where(x => x.Nombre.Equals(NombrePersona)).ToList().FirstOrDefault();

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

        public List<APersona> ObtenerMedicosBD()
        {
            List<Persona> personas;
            List<APersona> personasEncontradas = new List<APersona>();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(Startup.urlConexion);
            using (var context = new ApplicationContext(optionsBuilder.Options))
            {
                try
                {

                    personas = context.Persona.Where(x => x.Rol.Equals("Medico")).ToList();

                    foreach (Persona persona in personas)
                    {
                        APersona personaEncontrada = new APersona();

                        personaEncontrada.Nombre = persona.Nombre;
                        personaEncontrada.Apellidos = persona.Apellidos;
                        personaEncontrada.FechaNacimiento = persona.FechaNacimiento;
                        personaEncontrada.Correo = persona.Correo;
                        personaEncontrada.IdPersona = persona.IdPersona;
                        personaEncontrada.Genero = persona.Genero;
                        personaEncontrada.Rol = persona.Rol;
                        personaEncontrada.Telefono = persona.Telefono;
                        personasEncontradas.Add(personaEncontrada);

                    }


                }
                catch (DbUpdateException)
                {

                }
            }



            return personasEncontradas;


        }

        public APersona BuscarPersonaNombreUsuarioBD(string NombreUsuarioPersona)
        {
            Persona persona;
            APersona personaEncontrada = new Concretas.Persona();
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(Startup.urlConexion);
            using (var context = new ApplicationContext(optionsBuilder.Options))
            {
                try
                {
                    persona = context.Persona.Where(x => x.Cuenta.NombreUsuario.Equals(NombreUsuarioPersona)).ToList().First();

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

        public bool validarNombreUsuarioRepetidoBD(string nombreUsuario)
        {
            bool esUsuarioRepetido = false;
            Persona persona;
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(Startup.urlConexion);
            using (var context = new ApplicationContext(optionsBuilder.Options))
            {
                try
                {
                    persona = context.Persona.Where(x => x.Cuenta.NombreUsuario.Equals(nombreUsuario)).ToList().First();

                    if (persona != null){
                        esUsuarioRepetido = true;
                    };
                }
                catch (InvalidOperationException)
                {

                }
            }
              return esUsuarioRepetido;
        }
    }
}
