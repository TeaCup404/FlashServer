using System.Reflection;
using FlashServer.ManipulationLayer;
using Microsoft.Extensions.DependencyInjection;

namespace FlashServer.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddManipulationManagers(this IServiceCollection services, Assembly assembly)
        {
            var mms = assembly.GetTypes().Where(x => !x.IsAbstract && x.IsClass && typeof(IBasic).IsAssignableFrom(x));

            foreach (var m in mms)
            {
                services.AddSingleton(m);
            }

            return services;
        }
    }
}