using System;
using Microsoft.Extensions.DependencyInjection;
using Provider.interfaces;

namespace Provider
{
    public class Provider<T> : IProvider<T>
    {
        private readonly IServiceProvider _serviceProvider;

        public Provider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T Get()
        {
            return ActivatorUtilities.CreateInstance<T>(_serviceProvider);
        }

        public T Get(params object[] parameters)
        {
            return ActivatorUtilities.CreateInstance<T>(_serviceProvider, parameters);
        }
    }
}
