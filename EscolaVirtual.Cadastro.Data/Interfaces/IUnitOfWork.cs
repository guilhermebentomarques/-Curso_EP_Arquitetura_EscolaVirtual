using System;

namespace EscolaVirtual.Cadastro.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}