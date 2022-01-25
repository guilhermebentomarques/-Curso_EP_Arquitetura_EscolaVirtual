using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using EscolaVirtual.Vendas.Data.EntityConfig;
using EscolaVirtual.Vendas.Domain.Pagamentos;
using EscolaVirtual.Vendas.Domain.Pedidos;

namespace EscolaVirtual.Vendas.Data.Context
{
    public class VendasContext : DbContext
    {
        public VendasContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidoItems { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Where(p => !p.ReflectedType.Name.Contains(("AlunoUsuario")))
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Where(p => !p.ReflectedType.Name.Contains(("AlunoUsuario")))
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new PedidoConfig());
            modelBuilder.Configurations.Add(new PedidoItemConfig());
            modelBuilder.Configurations.Add(new PagamentoConfig());


            base.OnModelCreating(modelBuilder);
        }
    }
}