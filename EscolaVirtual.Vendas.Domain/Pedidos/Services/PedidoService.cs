using System;
using System.Linq;
using DomainValidation.Validation;
using EscolaVirtual.Core.Domain.Events;
using EscolaVirtual.Vendas.Domain.Pedidos.Interfaces.Repository;
using EscolaVirtual.Vendas.Domain.Pedidos.Interfaces.Services;

namespace EscolaVirtual.Vendas.Domain.Pedidos.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public Pedido AdicionarPedidoItem(PedidoItem pedidoItem, Guid alunoId)
        {
            var pedido = _pedidoRepository.ObterPedidoPendente(alunoId);
            bool novoPedido = false;

            if (pedido == null)
            {
                novoPedido = true;
                pedido = new Pedido(alunoId);
                pedido.AdicionarItem(pedidoItem);
            }
            else
            {
                pedido.AdicionarItem(pedidoItem);
            }

            if (!PossuiConformidade(pedido.ValidationResult))
                return pedido;

            if (novoPedido)
            {
                _pedidoRepository.AdicionarPedido(pedido);
                return pedido;
            }
            else
            {
                _pedidoRepository.AdicionarPedidoItem(pedidoItem);
                _pedidoRepository.AtualizarPedido(pedido);
                return _pedidoRepository.ObterPedidoPendente(alunoId);
            }
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
            _pedidoRepository.Dispose();
        }
    }
}