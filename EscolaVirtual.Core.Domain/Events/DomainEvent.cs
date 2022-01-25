﻿using EscolaVirtual.Core.Domain.Interfaces;

namespace EscolaVirtual.Core.Domain.Events
{
    public static class DomainEvent
    {
        public static IContainer Container { get; set; }

        public static void Raise<T>(T args) where T : IDomainEvent
        {
            if (Container == null) return;

            var obj = Container.GetInstance(typeof (IHandler<T>));
            ((IHandler<T>) obj).Handle(args);
        }
    }
}