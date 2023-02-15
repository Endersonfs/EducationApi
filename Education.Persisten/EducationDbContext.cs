using Education.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Persistence
{
    public class EducationDbContext : DbContext
    {
        public EducationDbContext(DbContextOptions <EducationDbContext> options) : base(options)
        {

        }
        public DbSet<Curso> Cursos { get; set; }

        #region inicializar valores de prueba para entidadad Cursos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>().Property(c => c.Precio).HasPrecision(14,2); //colocando la cantidad permitida de precio
            modelBuilder.Entity<Curso>().HasData(
                new Curso
                {
                    CursoId = Guid.NewGuid(),
                    Descripcion = "Curso de C# basico 1",
                    Titulo = "C# desde cero hasta avanzado",
                    FechaCreacion = DateTime.Now,
                    FechaPublicacion = DateTime.Now.AddYears(1),
                    Precio = 200

                }
            );
            modelBuilder.Entity<Curso>().HasData(
                new Curso
                {
                    CursoId = Guid.NewGuid(),
                    Descripcion = "Curso de C# basico 2",
                    Titulo = "C# desde cero hasta avanzado",
                    FechaCreacion = DateTime.Now,
                    FechaPublicacion = DateTime.Now.AddYears(2),
                    Precio = 400

                }
            );
            modelBuilder.Entity<Curso>().HasData(
                new Curso
                {
                    CursoId = Guid.NewGuid(),
                    Descripcion = "Curso de C# basico3",
                    Titulo = "C# desde cero hasta avanzado",
                    FechaCreacion = DateTime.Now,
                    FechaPublicacion = DateTime.Now.AddYears(3),
                    Precio = 600

                }
            );
            modelBuilder.Entity<Curso>().HasData(
               new Curso
               {
                   CursoId = Guid.NewGuid(),
                   Descripcion = "Master en Java",
                   Titulo = "Java",
                   FechaCreacion = DateTime.Now,
                   FechaPublicacion = DateTime.Now.AddYears(3),
                   Precio = Convert.ToDecimal(1000.50)
               }
           );
        }
        #endregion

    }
}
