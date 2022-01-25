using System;

namespace EscolaVirtual.Core.Domain.Interfaces
{
    public interface IDomainEvent
    {
        int Versao { get; }
        DateTime DataOcorrencia { get; }
    }
}