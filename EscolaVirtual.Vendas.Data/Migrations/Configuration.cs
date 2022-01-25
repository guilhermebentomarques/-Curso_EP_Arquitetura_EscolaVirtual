using System.Data.Entity.Migrations;
using EscolaVirtual.Vendas.Data.Context;

namespace EscolaVirtual.Vendas.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<VendasContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(VendasContext context)
        {

        }
    }
}
