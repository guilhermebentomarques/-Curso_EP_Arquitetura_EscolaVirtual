using System.Data.Entity.Migrations;
using EscolaVirtual.Cadastro.Data.Context;

namespace EscolaVirtual.Cadastro.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<AlunosContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AlunosContext context)
        {
        }
    }
}
