using System;

namespace EscolaVirtual.Vendas.Domain.Pedidos.Interfaces.Services
{
    public interface IPedidoService : IDisposable
    {
        Pedido AdicionarPedidoItem(PedidoItem pedidoItem, Guid alunoId);
    }
}