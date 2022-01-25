using System;

namespace EscolaVirtual.Vendas.Domain.Pedidos
{
    public class Curso
    {
        public Guid CursoId { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; } 
    }
}