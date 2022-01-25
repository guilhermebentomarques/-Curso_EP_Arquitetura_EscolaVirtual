using System;
using System.Collections;
using System.Collections.Generic;

namespace EscolaVirtual.Vendas.Domain.Pedidos.Interfaces.Repository
{
    public interface IPedidoRepository : IDisposable
    {
        Pedido ObterPedidoPendente(Guid alunoId);
        Pedido ObterPedidoPorId(Guid pedidoId);
        IEnumerable<Pedido> ObterPedidosPagos(Guid alunoId);
        Pedido AdicionarPedido(Pedido pedido);
        void AtualizarPedido(Pedido pedido);
        void AdicionarPedidoItem(PedidoItem pedidoItem);
    }
}