using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(EscolaVirtual.Site.Startup))]
namespace EscolaVirtual.Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
