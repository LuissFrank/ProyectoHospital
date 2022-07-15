using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace NewApp.Model
{
    public partial class HospitalDbContext : DbContext
    {
        public HospitalDbContext()
        {
        }
            public virtual DbSet<Medico> Medicos {get;set;}
            public virtual DbSet<Paciente> Pacientes {get;set;}
            public virtual DbSet<Departamento> Departamentos {get;set;}
            public virtual DbSet<Cobertura> Coberturas {get;set;}
            public virtual DbSet<SexoPersona> SexoPersonas {get;set;}
            public virtual DbSet<EstadoPersona> EstadoPersonas {get;set;}
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
