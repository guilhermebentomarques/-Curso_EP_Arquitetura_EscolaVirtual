using System.Data.Entity.ModelConfiguration;
using EscolaVirtual.Vendas.Domain.Pedidos;

namespace EscolaVirtual.Vendas.Data.EntityConfig
{
    public class PedidoItemConfig : EntityTypeConfiguration<PedidoItem>
    {
        public PedidoItemConfig()
        {
            HasKey(p => p.PedidoItemId);

            Property(p => p.PedidoId)
                .IsRequired();

            HasRequired(p => p.Pedido)
                .WithMany(p => p.PedidoItems)
                .HasForeignKey(p => p.PedidoId);

            ToTable("PedidoItems");
        } 
    }
}