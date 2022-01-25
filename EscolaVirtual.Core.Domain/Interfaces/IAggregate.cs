using System;

namespace EscolaVirtual.Core.Domain.Interfaces
{
    public interface IAggregate
    {
        Guid Id { get; }
    }
}