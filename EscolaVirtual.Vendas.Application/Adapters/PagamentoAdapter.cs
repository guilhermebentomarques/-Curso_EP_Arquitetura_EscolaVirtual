using EscolaVirtual.Vendas.Application.ViewModels;
using EscolaVirtual.Vendas.Domain.Pagamentos;

namespace EscolaVirtual.Vendas.Application.Adapters
{
    public class PagamentoAdapter
    {
        public static Pagamento ToPagamento(PagamentoViewModel pagamentoViewModel)
        {
            var pagamento = new Pagamento(
                    pagamentoViewModel.PagamentoId,
                    pagamentoViewModel.Valor,
                    pagamentoViewModel.AlunoId,
                    pagamentoViewModel.PedidoId);

            return pagamento;
        }

        public static PagamentoCartao ToPagamentoCartao(PagamentoViewModel pagamentoViewModel)
        {
            var pagamentoCartao = new PagamentoCartao(
                    pagamentoViewModel.NumeroCartao,
                    pagamentoViewModel.NomeCartao,
                    pagamentoViewModel.MesVencimento,
                    pagamentoViewModel.AnoVencimento,
                    pagamentoViewModel.CodigoSeguranca);

            return pagamentoCartao;
        }

        public static PagamentoViewModel ToPagamentoViewModel(Pagamento pagamento)
        {
            var pagamentoViewModel = new PagamentoViewModel()
            {
                PagamentoId = pagamento.PagamentoId,
                AlunoId = pagamento.AlunoId,
                DataPagamento = pagamento.DataPagamento,
                MeioPagamento = pagamento.MeioPagamento,
                Valor = pagamento.Valor,
                PedidoId = pagamento.PedidoId,
                Pedido = PedidoAdapter.ToPedidoViewModel(pagamento.Pedido)
            };

            return pagamentoViewModel;
        }
    }
}