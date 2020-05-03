using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlpineSkiHouseCQRS
{
    public static class Extensions
    {
        public static void RegisterServices(this IServiceCollection services, Type serviceInterfaces)
        {
            var handlers = typeof(Startup).Assembly.GetTypes()
                .Where(x => x.GetInterfaces().Any(t => t.IsGenericType && t.GetGenericTypeDefinition() == serviceInterfaces));

            foreach(var handler in handlers)
            {
                services.AddScoped(handler.GetInterfaces().First(t => t.IsGenericType && t.GetGenericTypeDefinition() == serviceInterfaces), handler);
            }
        }
    }
}
