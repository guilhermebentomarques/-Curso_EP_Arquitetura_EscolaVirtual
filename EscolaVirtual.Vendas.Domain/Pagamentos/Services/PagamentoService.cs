using System;
using System.Linq;
using DomainValidation.Validation;
using EscolaVirtual.Core.Domain.Events;
using EscolaVirtual.Vendas.Domain.Pagamentos.Interfaces.Repository;
using EscolaVirtual.Vendas.Domain.Pagamentos.Interfaces.Service;
using EscolaVirtual.Vendas.Domain.Pedidos;
using EscolaVirtual.Vendas.Domain.Pedidos.Interfaces.Repository;

namespace EscolaVirtual.Vendas.Domain.Pagamentos.Services
{
    public class PagamentoService : IPagamentoService
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IPedidoRepository _pedidoRepository;

        public PagamentoService(IPagamentoRepository pagamentoRepository, IPedidoRepository pedidoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
            _pedidoRepository = pedidoRepository;
        }

        public Pagamento Adicionar(Pagamento pagamento)
        {
            if (pagamento.MeioPagamento == MeioPagamento.Cartao)
            {
                // Pagamento na operadora
                pagamento.ValidarCartao();
                if (!PossuiConformidade(pagamento.ValidationResult))
                    return pagamento;

                // Obtendo detalhes do pedido
                var pedido = _pedidoRepository.ObterPedidoPorId(pagamento.PedidoId);

                // Alterando status para confirmacao do pagamento
                pedido.AlterarStatusPedido(StatusPedido.Pago);
                _pedidoRepository.AtualizarPedido(pedido);

                // Adicionando dados de pedido no pagamento
                pagamento.AssociarPedido(pedido);
            }

            return _pagamentoRepository.Adicionar(pagamento);
        }

        public Pagamento ObterPorId(Guid id)
        {
            return _pagamentoRepository.ObterPorId(id);
        }

        private static bool PossuiConformidade(ValidationResult validationResult)
        {
            if (validationResult == null) return true;
            var notifications = validationResult.Erros.Select(validationError => new DomainNotification(validationError.ToString(), validationError.Message)).ToList();
            if (!notifications.Any()) return true;
            notifications.ToList().ForEach(DomainEvent.Raise);
            return false;
        }

        public void Dispose()
        {
            _pagamentoRepository.Dispose();
        }
    }
}