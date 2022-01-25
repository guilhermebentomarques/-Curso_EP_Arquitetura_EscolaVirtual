using System;
using EscolaVirtual.Core.Domain.Events;
using EscolaVirtual.Vendas.Application.Adapters;
using EscolaVirtual.Vendas.Application.Interfaces;
using EscolaVirtual.Vendas.Application.ViewModels;
using EscolaVirtual.Vendas.Data.Interfaces;
using EscolaVirtual.Vendas.Domain.Pagamentos;
using EscolaVirtual.Vendas.Domain.Pagamentos.Events;
using EscolaVirtual.Vendas.Domain.Pagamentos.Interfaces.Service;

namespace EscolaVirtual.Vendas.Application
{
    public class PagamentoAppService :ApplicationService, IPagamentoAppService
    {
        private readonly IPagamentoService _pagamentoService;

        public PagamentoAppService(IPagamentoService pagamentoService, IUnitOfWork unitOfWork)
            :base(unitOfWork)
        {
            _pagamentoService = pagamentoService;
        }

        public PagamentoViewModel Adicionar(PagamentoViewModel pagamentoViewModel)
        {
            var pagamento = PagamentoAdapter.ToPagamento(pagamentoViewModel);

            if (pagamento.MeioPagamento == MeioPagamento.Cartao)
            {
                pagamento.AssociarCartao(PagamentoAdapter.ToPagamentoCartao(pagamentoViewModel));
            }

            pagamento = _pagamentoService.Adicionar(pagamento);
            if (Commit())
            {
                // Evento para validar se o aluno atingiu categoria premium
                DomainEvent.Raise(new AlunoPremiumEvent(pagamento.AlunoId));
            }

            return pagamentoViewModel;
        }

        public PagamentoViewModel ObterPorId(Guid id)
        {
            return PagamentoAdapter.ToPagamentoViewModel(_pagamentoService.ObterPorId(id));
        }
    }
}