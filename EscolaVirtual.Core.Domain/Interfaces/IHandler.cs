using System;
using System.Collections.Generic;
using EscolaVirtual.Core.Domain.Events;

namespace EscolaVirtual.Core.Domain.Interfaces
{
    public interface IHandler<T> : IDisposable where T : IDomainEvent
    {
        void Handle(T args);
        IEnumerable<T> Notify();
        bool HasNotifications();
        List<T> GetValues();
    }
}