using System;

namespace EscolaVirtual.Vendas.Application.ViewModels
{
    public class PedidoItemViewModel
    {
        public PedidoItemViewModel()
        {
            PedidoItemId = Guid.NewGuid();
        }

        public Guid PedidoItemId { get; set; }
        public Guid CursoId { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public Guid PedidoId { get; set; }
    }
}