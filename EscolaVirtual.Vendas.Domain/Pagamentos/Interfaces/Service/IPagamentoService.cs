using System;

namespace EscolaVirtual.Vendas.Domain.Pagamentos.Interfaces.Service
{
    public interface IPagamentoService : IDisposable
    {
        Pagamento Adicionar(Pagamento pagamento);
        Pagamento ObterPorId(Guid id);
    }
}