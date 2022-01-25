using System;
using EscolaVirtual.Vendas.Application.Adapters;
using EscolaVirtual.Vendas.Application.Interfaces;
using EscolaVirtual.Vendas.Application.ViewModels;
using EscolaVirtual.Vendas.Data.Interfaces;
using EscolaVirtual.Vendas.Domain.Pedidos.Interfaces.Repository;
using EscolaVirtual.Vendas.Domain.Pedidos.Interfaces.Services;

namespace EscolaVirtual.Vendas.Application
{
    public class PedidoAppService : ApplicationService, IPedidoAppService
    {
        private readonly IPedidoService _pedidoService;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoAppService(IPedidoService pedidoService, IPedidoRepository pedidoRepository, IUnitOfWork unitOfWork)
            :base(unitOfWork)
        {
            _pedidoService = pedidoService;
            _pedidoRepository = pedidoRepository;
        }

        public PedidoViewModel AdicionarPedidoItem(PedidoItemViewModel pedidoItemViewModel, Guid alunoId)
        {
            var pedidoReturn = _pedidoService.AdicionarPedidoItem(PedidoAdapter.ToPedidoItem(pedidoItemViewModel),alunoId);
            if (Commit())
            {
                //DomainEvent.Raise(new AlunoCadastradoEvent(aluno));
            }
            else
            {
                //
            }

            return PedidoAdapter.ToPedidoViewModel(pedidoReturn);
        }

        public PedidoViewModel ObterPedidoPendente(Guid alunoId)
        {
            return PedidoAdapter.ToPedidoViewModel(_pedidoRepository.ObterPedidoPendente(alunoId));
        }

        public void RemoverPedidoItem(Guid id)
        {
            throw new NotImplementedException();
        }


        public void Dispose()
        {
            _pedidoRepository.Dispose();
            _pedidoService.Dispose();
        }
    }
}