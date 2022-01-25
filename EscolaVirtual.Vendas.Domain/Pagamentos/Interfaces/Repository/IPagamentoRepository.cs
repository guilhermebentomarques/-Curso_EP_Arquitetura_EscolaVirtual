using System;

namespace EscolaVirtual.Vendas.Domain.Pagamentos.Interfaces.Repository
{
    public interface IPagamentoRepository : IDisposable
    {
        Pagamento Adicionar(Pagamento pagamento);
        Pagamento ObterPorId(Guid id);
    }
}