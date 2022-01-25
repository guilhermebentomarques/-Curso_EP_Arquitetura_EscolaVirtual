using EscolaVirtual.Vendas.Data.Context;
using EscolaVirtual.Vendas.Data.Interfaces;

namespace EscolaVirtual.Vendas.Data.UoW
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private VendasContext _context;

        public UnitOfWork(VendasContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (_context == null) return;

            _context.Dispose();
            _context = null;
        }
    }
}