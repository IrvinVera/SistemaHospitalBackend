using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Models
{
    public class ApplicationContext : DbContext
    {

        
       public virtual DbSet<Consultorio> Consultorio { get; set; }
        public virtual DbSet<Consulta> Consulta { get; set; }
        public virtual DbSet<Cuenta> Cuenta { get; set; }
        public virtual DbSet<Medicamento> Medicamento { get; set; }
         public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Receta> Receta { get; set; }
        public virtual DbSet<SignoVital> SignoVital { get; set; }
        public virtual DbSet<Tratamiento> Tratamiento { get; set; }
        

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicamentoTratamiento>().HasKey(t => new { t.MedicamentoId, t.TratamientoId });
            modelBuilder.Entity<MedicamentoTratamiento>().HasOne(pt => pt.Medicamento).WithMany(p => p.MedicamentoTratamientos).HasForeignKey(pt => pt.MedicamentoId);
            modelBuilder.Entity<MedicamentoTratamiento>().HasOne(pt => pt.Tratamiento).WithMany(p => p.MedicamentoTratamientos).HasForeignKey(pt => pt.TratamientoId);
           modelBuilder.Entity<Persona>().HasOne(s => s.Cuenta).WithOne(a => a.Persona).HasForeignKey<Cuenta>(b => b.PersonaForeignKey);
            modelBuilder.Entity<Persona>().HasMany(s => s.SignosVitales).WithOne(a => a.Persona);
            
            modelBuilder.Entity<Receta>().HasOne(s => s.Consulta).WithOne(a => a.Receta).HasForeignKey<Consulta>(b => b.RecetaForeignKey); ;
            modelBuilder.Entity<Receta>().HasMany(s => s.Tratamientos).WithOne(a => a.Receta);
            modelBuilder.Entity<Persona>().HasMany(s => s.Consultas).WithOne(a => a.Persona);
            modelBuilder.Entity<Consultorio>().HasMany(s => s.Consultas).WithOne(a => a.Consultorio);

        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)

    : base(options)
        {

        }
    }
}
