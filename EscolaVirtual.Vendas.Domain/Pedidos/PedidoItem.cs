using System;

namespace EscolaVirtual.Vendas.Domain.Pedidos
{
    public class PedidoItem
    {
        public Guid PedidoItemId { get; private set; }
        public Guid CursoId { get; private set; }
        public string Descricao { get; private set; }
        public int Quantidade { get; private set; }
        public decimal Valor { get; private set; }
        public Guid PedidoId { get; private set; }
        public virtual Pedido Pedido { get; private set; }

        protected PedidoItem()
        {
            
        }

        public PedidoItem(Curso curso, int quantidade = 1)
        {
            PedidoItemId = Guid.NewGuid();
            CursoId = curso.CursoId;
            Descricao = curso.Nome;
            Quantidade = quantidade;
            Valor = curso.Valor * Quantidade;
        }

        public void AssociarPedido(Guid pedidoId)
        {
            PedidoId = pedidoId;
        }

        public static class PedidoItemFactory
        {
            public static PedidoItem NovoPedido(Guid pedidoItemId, Guid cursoId, string descricao, int quantidade, decimal valor,Guid pedidoId)
            {
                return new PedidoItem()
                {
                    PedidoItemId = pedidoItemId,
                    CursoId = cursoId,
                    Descricao = descricao,
                    Quantidade = quantidade,
                    Valor = valor,
                    PedidoId = pedidoId
                };
            }
        }
    }
}