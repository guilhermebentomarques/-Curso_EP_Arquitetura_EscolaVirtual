using System;
using DomainValidation.Validation;
using EscolaVirtual.Vendas.Domain.Pedidos;

namespace EscolaVirtual.Vendas.Domain.Pagamentos
{
    public class Pagamento
    {
        public Guid PagamentoId { get; private set; }
        public decimal Valor { get; private set; }
        public MeioPagamento MeioPagamento { get; private set; }
        public Guid AlunoId { get; private set; }
        public Guid PedidoId { get; private set; }
        public DateTime DataPagamento { get; private set; }
        public ValidationResult ValidationResult { get; set; }
        public virtual Pedido Pedido { get; private set; }
        public PagamentoCartao PagamentoCartao { get; private set; }

        protected Pagamento()
        {
            
        }

        public Pagamento(Guid pagamentoId, decimal valor, Guid alunoId, Guid pedidoId, MeioPagamento meioPagamento = MeioPagamento.Cartao)
        {
            PagamentoId = pagamentoId;
            Valor = valor;
            AlunoId = alunoId;
            PedidoId = pedidoId;
            DataPagamento = DateTime.Now;
            MeioPagamento = meioPagamento;
        }

        public void AssociarPedido(Pedido pedido)
        {
            PedidoId = pedido.PedidoId;
            AlunoId = pedido.AlunoId;
            Valor = pedido.Valor;
            Pedido = pedido;
        }

        public void AssociarCartao(PagamentoCartao pagamentoCartao)
        {
            PagamentoCartao = pagamentoCartao;
        }

        public void ValidarCartao()
        {
            if (!PagamentoCartao.NumeroCartao.Equals("1111222233334444"))
            {
                if (ValidationResult == null) ValidationResult = new ValidationResult();
                ValidationResult.Add(new ValidationError("A operadora recusou a transação para este cartao"));
            }
        }
    }
}