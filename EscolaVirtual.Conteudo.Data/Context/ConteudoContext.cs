using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using EscolaVirtual.Conteudo.Domain.Cursos;

namespace EscolaVirtual.Conteudo.Data.Context
{
    public class ConteudoContext : DbContext
    {
        public ConteudoContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Curso>().ToTable("Cursos");
            modelBuilder.Entity<Matricula>().ToTable("Matriculas");
        }
    }
}