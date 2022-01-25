using System;

namespace EscolaVirtual.Vendas.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}