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

        public static bool IsEqualArray(this byte[] arr1, byte[] arr2)
        {
            if (arr2 == null) return false;

            if (arr1.Length != arr2.Length) return false;

            for(int i=arr1.Length-1; i>=0; i--)
            {
                if (arr1[i] != arr2[i]) return false;
            }

            return true;
        }
    }
}
