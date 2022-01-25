using EscolaVirtual.Conteudo.Application;
using EscolaVirtual.Conteudo.Application.Interfaces;
using EscolaVirtual.Conteudo.Data.Context;
using EscolaVirtual.Conteudo.Data.Repository;
using EscolaVirtual.Conteudo.Domain.Cursos.Interfaces;
using EscolaVirtual.Conteudo.Domain.Cursos.Services;
using SimpleInjector;

namespace EscolaVirtual.Conteudo.Infra.IoC
{
    public class BootStrapperConteudo
    {
        public static void Register(Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe;
            // Lifestyle.Scoped => Uma instancia unica para o request;

            container.Register<ICursoAppService, CursoAppService>(Lifestyle.Scoped);

            container.Register<ICursoService, CursoService>(Lifestyle.Scoped);

            container.Register<ICursoRepository, CursoRepository>(Lifestyle.Scoped);
            container.Register<ConteudoContext>(Lifestyle.Scoped);
        }
    }
}