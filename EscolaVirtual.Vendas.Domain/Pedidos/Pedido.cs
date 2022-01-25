using System;
using System.Collections.Generic;
using System.Linq;
using DomainValidation.Validation;
using EscolaVirtual.Vendas.Domain.Pagamentos;

namespace EscolaVirtual.Vendas.Domain.Pedidos
{
    public class Pedido
    {
        public Guid PedidoId { get; private set; }
        public Guid AlunoId { get; private set; }
        public ICollection<PedidoItem> PedidoItems { get; private set; }
        public StatusPedido StatusPedido { get; private set; }
        public DateTime DataPedido { get; private set; }
        public decimal Valor { get; private set; }
        public virtual Pagamento Pagamento { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        // Construtor necessário para o EF retornar resultado.
        protected Pedido(){}

        public Pedido(Guid alunoId)
        {
            PedidoId = Guid.NewGuid();
            AlunoId = alunoId;
            StatusPedido = StatusPedido.Iniciado;
            DataPedido = DateTime.Now;
            PedidoItems = new List<PedidoItem>();
        }

        public void AlterarStatusPedido(StatusPedido statusPedido)
        {
            StatusPedido = statusPedido;
        }

        public void AdicionarItem(PedidoItem item)
        {
            // Adiciona o Id do Pedido ao Item do Pedido
            item.AssociarPedido(PedidoId);

            // Verifica se o curso já não foi adicionado no pedido
            if (PedidoItems.Any(p => p.CursoId == item.CursoId))
            {
                if(ValidationResult == null) ValidationResult = new ValidationResult();
                ValidationResult.Add(new ValidationError("O item '"+ item.Descricao + "' já foi adicionado anteriormente"));
                return;
            }

            PedidoItems.Add(item);
            Valor = PedidoItems.Sum(p => p.Valor);
        }
    }
}