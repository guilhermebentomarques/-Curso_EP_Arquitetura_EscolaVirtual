using EscolaVirtual.Cadastro.Data.Context;
using EscolaVirtual.Cadastro.Data.Interfaces;

namespace EscolaVirtual.Cadastro.Data.UoW
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private AlunosContext _context;

        public UnitOfWork(AlunosContext context)
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
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}