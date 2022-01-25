using System;
using EscolaVirtual.Vendas.Domain.Pagamentos;
using EscolaVirtual.Vendas.Domain.Pedidos;

namespace EscolaVirtual.Vendas.Application.ViewModels
{
    public class PagamentoViewModel
    {
        public PagamentoViewModel()
        {
            PagamentoId = Guid.NewGuid();
        }

        public Guid PagamentoId { get; set; }
        public decimal Valor { get; set; }
        public MeioPagamento MeioPagamento { get; set; }
        public Guid AlunoId { get; set; }
        public Guid PedidoId { get; set; }
        public DateTime DataPagamento { get; set; }
        public virtual PedidoViewModel Pedido { get; set; }

        public string NumeroCartao { get; set; }
        public string NomeCartao { get; set; }
        public int MesVencimento { get; set; }
        public int AnoVencimento { get; set; }
        public int CodigoSeguranca { get; set; }
    }
}