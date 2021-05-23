using Assets.Scripts.Game.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Scripts.Components.Core
{
    public class ServicesSystem
    {
        private Dictionary<Type, IService> _services = new Dictionary<Type, IService>();

        public T Get<T>() where T : IService
        {
            if (!_services.ContainsKey(typeof(T)))
                throw new Exception($"No service registered with this type {typeof(T).Name}");

            return (T)_services[typeof(T)];
        }

        public void Add(IService service)
        {
            if (service == null)
                throw new NullReferenceException("Service is null");

            if (_services.ContainsKey(service.GetType()))
                throw new Exception($"Service with this type already registered {service.GetType()}");

            _services.Add(service.GetType(), service);
        }

        public void Remove(IService service)
        {
            if (service == null)
                throw new NullReferenceException("Service is null");

            _services.Remove(service.GetType());
        }
    }
}
