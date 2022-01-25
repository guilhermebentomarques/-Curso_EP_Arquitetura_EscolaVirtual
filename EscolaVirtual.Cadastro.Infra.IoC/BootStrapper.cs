using EscolaVirtual.Cadastro.Application;
using EscolaVirtual.Cadastro.Application.Interfaces;
using EscolaVirtual.Cadastro.Data.Context;
using EscolaVirtual.Cadastro.Data.Interfaces;
using EscolaVirtual.Cadastro.Data.Repository;
using EscolaVirtual.Cadastro.Data.UoW;
using EscolaVirtual.Cadastro.Domain.Alunos.Events;
using EscolaVirtual.Cadastro.Domain.Alunos.Handlers;
using EscolaVirtual.Cadastro.Domain.Alunos.Interfaces;
using EscolaVirtual.Cadastro.Domain.Alunos.Services;
using EscolaVirtual.Cadastro.Infra.Identity.Configuration;
using EscolaVirtual.Cadastro.Infra.Identity.Context;
using EscolaVirtual.Cadastro.Infra.Identity.Model;
using EscolaVirtual.Core.Domain.Events;
using EscolaVirtual.Core.Domain.Handlers;
using EscolaVirtual.Core.Domain.Interfaces;
using EscolaVirtual.Core.Infra.Email;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleInjector;

namespace EscolaVirtual.Cadastro.Infra.IoC
{
    public class BootStrapper
    {
        public static Container MyContainer { get; set; }

        public static void Register(Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe;
            // Lifestyle.Scoped => Uma instancia unica para o request;

            MyContainer = container;

            // APP
            container.Register<IAlunoAppService, AlunoAppService>(Lifestyle.Scoped);

            // Domain
            container.Register<IAlunoService, AlunoService>(Lifestyle.Scoped);

            // Infra Dados Repos
            container.Register<IAlunoRepository, AlunoRepository>(Lifestyle.Scoped);

            // Infra Dados
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<AlunosContext>(Lifestyle.Scoped);

            // Handlers
            container.Register<IHandler<DomainNotification>, DomainNotificationHandler>(Lifestyle.Scoped);
            container.Register<IHandler<AlunoCadastradoEvent>, AlunoCadastradoHandler>(Lifestyle.Scoped);

            // Infra Core
            container.Register<IEnvioEmail, EnvioEmail>(Lifestyle.Singleton);

            // Identity
            container.Register<ApplicationDbContext>(Lifestyle.Scoped);
            container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()), Lifestyle.Scoped);
            container.Register<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>(), Lifestyle.Scoped);
            container.Register<ApplicationRoleManager>(Lifestyle.Scoped);
            container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            container.Register<ApplicationSignInManager>(Lifestyle.Scoped);
        }
    }
}
