using System.Reflection;
using System.Web;
using System.Web.Mvc;
using EscolaVirtual.Cadastro.Infra.IoC;
using EscolaVirtual.Conteudo.Infra.IoC;
using EscolaVirtual.Core.Domain.Events;
using EscolaVirtual.Site.App_Start;
using EscolaVirtual.Vendas.Infra.IoC;
using Microsoft.Owin;
using SimpleInjector;
using SimpleInjector.Advanced;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using WebActivator;

[assembly: PostApplicationStartMethod(typeof (SimpleInjectorInitializer), "Initialize")]

namespace EscolaVirtual.Site.App_Start
{
    public static class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(container);

            // Necessário para registrar o ambiente do Owin que é dependência do Identity
            // Feito fora da camada de IoC para não levar o System.Web para fora
            container.RegisterPerWebRequest(() =>
            {
                if (HttpContext.Current != null && HttpContext.Current.Items["owin.Environment"] == null && container.IsVerifying())
                {
                    return new OwinContext().Authentication;
                }
                return HttpContext.Current.GetOwinContext().Authentication;

            });

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            // Não utilizar o Verify devido a solicitação dinamica de dependências.
            //container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            DomainEvent.Container = new DomainEventsContainer(DependencyResolver.Current);
        }

        private static void InitializeContainer(Container container)
        {
            BootStrapper.Register(container);
            BootStrapperConteudo.Register(container);
            BootStrapperVendas.Register(container);
        }
    }
}