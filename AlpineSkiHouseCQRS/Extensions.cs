using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlpineSkiHouseCQRS
{
    public static class Extensions
    {
        public static void RegisterHandlers(this IServiceCollection services, Type handlerInterfaces)
        {
            var handlers = typeof(Startup).Assembly.GetTypes()
                .Where(x => x.GetInterfaces().Any(t => t.IsGenericType && t.GetGenericTypeDefinition() == handlerInterfaces));

            foreach(var handler in handlers)
            {
                services.AddScoped(handler.GetInterfaces().First(t => t.IsGenericType && t.GetGenericTypeDefinition() == handlerInterfaces), handler);
            }
        }
    }
}
