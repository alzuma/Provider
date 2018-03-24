using Microsoft.Extensions.DependencyInjection;
using Provider.interfaces;

namespace Provider.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddProviderInjection(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IProvider<>), typeof(Provider<>));
        }
    }
}