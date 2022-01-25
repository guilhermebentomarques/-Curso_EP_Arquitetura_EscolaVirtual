using System;
using System.Data.Entity;
using System.Linq;
using EscolaVirtual.Vendas.Data.Context;
using EscolaVirtual.Vendas.Domain.Pagamentos;
using EscolaVirtual.Vendas.Domain.Pagamentos.Interfaces.Repository;

namespace EscolaVirtual.Vendas.Data.Repository
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly VendasContext _db;

        public PagamentoRepository(VendasContext db)
        {
            _db = db;
        }

        public Pagamento Adicionar(Pagamento pagamento)
        {
            var pagamentoReturn = _db.Pagamentos.Add(pagamento);
            return pagamentoReturn;
        }

        public Pagamento ObterPorId(Guid id)
        {
            return _db.Pagamentos.Include("Pedido").FirstOrDefault(p => p.PagamentoId == id);
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}