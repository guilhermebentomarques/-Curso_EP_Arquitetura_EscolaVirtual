
using EscolaVirtual.Core.Domain.Events;
using EscolaVirtual.Core.Domain.Handlers;
using EscolaVirtual.Core.Domain.Interfaces;
using EscolaVirtual.Vendas.Application;
using EscolaVirtual.Vendas.Application.Interfaces;
using EscolaVirtual.Vendas.Data.Context;
using EscolaVirtual.Vendas.Data.Interfaces;
using EscolaVirtual.Vendas.Data.Repository;
using EscolaVirtual.Vendas.Data.UoW;
using EscolaVirtual.Vendas.Domain.Pagamentos.Events;
using EscolaVirtual.Vendas.Domain.Pagamentos.Handlers;
using EscolaVirtual.Vendas.Domain.Pagamentos.Interfaces.Repository;
using EscolaVirtual.Vendas.Domain.Pagamentos.Interfaces.Service;
using EscolaVirtual.Vendas.Domain.Pagamentos.Services;
using EscolaVirtual.Vendas.Domain.Pedidos.Interfaces.Repository;
using EscolaVirtual.Vendas.Domain.Pedidos.Interfaces.Services;
using EscolaVirtual.Vendas.Domain.Pedidos.Services;
using SimpleInjector;

namespace EscolaVirtual.Vendas.Infra.IoC
{
    public class BootStrapperVendas
    {
        public static void Register(Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe;
            // Lifestyle.Scoped => Uma instancia unica para o request;

            container.Register<IPedidoAppService, PedidoAppService>(Lifestyle.Scoped);
            container.Register<IPagamentoAppService, PagamentoAppService>(Lifestyle.Scoped);

            container.Register<IPedidoService, PedidoService>(Lifestyle.Scoped);
            container.Register<IPagamentoService, PagamentoService>(Lifestyle.Scoped);

            container.Register<IPedidoRepository, PedidoRepository>(Lifestyle.Scoped);
            container.Register<IPagamentoRepository, PagamentoRepository>(Lifestyle.Scoped);

            container.Register<IHandler<AlunoPremiumEvent>, AlunoPremiumHandler>(Lifestyle.Scoped);

            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<VendasContext>(Lifestyle.Scoped);
        }
    }
}
