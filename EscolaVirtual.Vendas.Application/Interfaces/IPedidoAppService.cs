using System;
using EscolaVirtual.Vendas.Application.ViewModels;

namespace EscolaVirtual.Vendas.Application.Interfaces
{
    public interface IPedidoAppService : IDisposable
    {
        PedidoViewModel ObterPedidoPendente(Guid alunoId);
        PedidoViewModel AdicionarPedidoItem(PedidoItemViewModel pedidoItemViewModel, Guid alunoId);
        void RemoverPedidoItem(Guid id);
    }
}