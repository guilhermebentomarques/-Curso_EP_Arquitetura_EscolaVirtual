using System.Data.Entity.ModelConfiguration;
using EscolaVirtual.Vendas.Domain.Pedidos;

namespace EscolaVirtual.Vendas.Data.EntityConfig
{
    public class PedidoConfig : EntityTypeConfiguration<Pedido>
    {
        public PedidoConfig()
        {
            HasKey(p => p.PedidoId);

            HasOptional(p => p.Pagamento)
                .WithRequired(p => p.Pedido);

            Ignore(p => p.ValidationResult);

            ToTable("Pedidos");
        } 
    }
}