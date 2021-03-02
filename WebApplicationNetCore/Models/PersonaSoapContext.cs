using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace WebApplicationNetCore.Models
{
    public class PersonaSoapContext : DbContext
    {
        public PersonaSoapContext()
        {

        }

        public PersonaSoapContext(DbContextOptions<PersonaSoapContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PersonasEjercicio> PersonasEjercicio { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=PLX135101050379\\SQLEXPRESS;Database=PersonaSoap;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonasEjercicio>(entity =>
            {
                entity.Property(e => e.Nif)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Apellidos).IsUnicode(false);

                entity.Property(e => e.Ciudad).IsUnicode(false);

                entity.Property(e => e.CodigoPostal).IsUnicode(false);

                entity.Property(e => e.Direccion).IsUnicode(false);

                entity.Property(e => e.EstadoCivil).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.Property(e => e.Provincia).IsUnicode(false);

                entity.Property(e => e.Sexo).IsUnicode(false);
            });
        }
    }
}
