﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using EscolaVirtual.Core.Domain.Interfaces;

namespace EscolaVirtual.Site
{
    public class DomainEventsContainer : IContainer
    {
        private readonly IDependencyResolver _resolver;

        public DomainEventsContainer(IDependencyResolver resolver)
        {
            _resolver = resolver;
        }

        public object GetInstance(Type serviceType)
        {
            return _resolver.GetService(serviceType);
        }

        public T GetInstance<T>()
        {
            return (T)_resolver.GetService(typeof(T));
        }

        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _resolver.GetServices(serviceType);
        }

        public IEnumerable<T> GetAllInstances<T>()
        {
            return (IEnumerable<T>)_resolver.GetServices(typeof(T));
        }
    }
}