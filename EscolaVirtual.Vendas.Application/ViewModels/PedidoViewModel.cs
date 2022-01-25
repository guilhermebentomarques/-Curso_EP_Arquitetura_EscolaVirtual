using System;
using System.Collections.Generic;

namespace EscolaVirtual.Vendas.Application.ViewModels
{
    public class PedidoViewModel
    {
        public Guid AlunoId { get; set; }
        public Guid PedidoId { get; set; }
        public ICollection<PedidoItemViewModel> PedidoItems { get; set; } 
    }
}