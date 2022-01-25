using System.Data.Entity.ModelConfiguration;
using EscolaVirtual.Cadastro.Domain.Alunos;

namespace EscolaVirtual.Cadastro.Data.EntityConfig
{
    public class AlunoUsuarioConfig : EntityTypeConfiguration<AlunoUsuario>
    {
        public AlunoUsuarioConfig()
        {
            HasKey(u => u.Id);

            Property(u => u.Id)
                .IsRequired()
                .HasMaxLength(128);
            
            Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(256);

            Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(256);

            ToTable("AspNetUsers");
        }
    }
}