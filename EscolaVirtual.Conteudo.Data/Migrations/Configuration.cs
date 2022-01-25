using System.Data.Entity.Migrations;
using EscolaVirtual.Conteudo.Data.Context;

namespace EscolaVirtual.Conteudo.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ConteudoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ConteudoContext context)
        {

        }
    }
}
