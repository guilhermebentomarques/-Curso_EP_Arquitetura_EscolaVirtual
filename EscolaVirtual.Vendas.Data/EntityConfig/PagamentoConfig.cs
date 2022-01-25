using System.Data.Entity.ModelConfiguration;
using EscolaVirtual.Vendas.Domain.Pagamentos;

namespace EscolaVirtual.Vendas.Data.EntityConfig
{
    public class PagamentoConfig : EntityTypeConfiguration<Pagamento>
    {
        public PagamentoConfig()
        {
            HasKey(c => c.PagamentoId);

            Ignore(p => p.PagamentoCartao);
            Ignore(p => p.ValidationResult);

            ToTable("Pagamentos");
        }
    }
}