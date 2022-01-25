using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EscolaVirtual.Vendas.Application.ViewModels;
using EscolaVirtual.Vendas.Domain.Pedidos;

namespace EscolaVirtual.Vendas.Application.Adapters
{
    public class PedidoAdapter
    {
        public static PedidoItemViewModel ToPedidoItemViewModel(PedidoItem pedidoItem)
        {
            var pedidoViewModel = new PedidoItemViewModel()
            {
                CursoId = pedidoItem.CursoId,
                Descricao = pedidoItem.Descricao,
                Quantidade = pedidoItem.Quantidade,
                Valor = pedidoItem.Valor
            };

            return pedidoViewModel;
        }

        public static PedidoItem ToPedidoItem(PedidoItemViewModel pedidoItemViewModel)
        {
            var pedidoItem = PedidoItem.PedidoItemFactory.NovoPedido(
                pedidoItemViewModel.PedidoItemId,
                pedidoItemViewModel.CursoId,
                pedidoItemViewModel.Descricao,
                pedidoItemViewModel.Quantidade,
                pedidoItemViewModel.Valor,
                pedidoItemViewModel.PedidoId);

            return pedidoItem;
        }

        public static PedidoViewModel ToPedidoViewModel(Pedido pedido)
        {
            if (pedido == null) return new PedidoViewModel();

            ICollection<PedidoItemViewModel> pedidoItems= new List<PedidoItemViewModel>();

            if(pedido.PedidoItems != null)
            pedidoItems = pedido.PedidoItems.Select(ToPedidoItemViewModel).ToList();

            var pedidoViewModel = new PedidoViewModel()
            {
                AlunoId = pedido.AlunoId,
                PedidoId = pedido.PedidoId,
                PedidoItems = pedidoItems
            };

            return pedidoViewModel;
        }
    }
}