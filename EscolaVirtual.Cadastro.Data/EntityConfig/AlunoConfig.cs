using System.Data.Entity.ModelConfiguration;
using EscolaVirtual.Cadastro.Domain.Alunos;

namespace EscolaVirtual.Cadastro.Data.EntityConfig
{
    public class AlunoConfig : EntityTypeConfiguration<Aluno>
    {
        public AlunoConfig()
        {
            HasKey(c => new { c.AlunoId });

            Property(c => c.CPF.Codigo)
                .HasColumnName("CPF");

            Property(c => c.Email.Endereco)
                .HasColumnName("Email");

            Ignore(c => c.ValidationResult);
            Ignore(c => c.Endereco);

            ToTable("Alunos");
        }
    }
}