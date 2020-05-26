using AlpineSkiHouseCQRS.Infrastructure;
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
            var handlers = GetGenericTypes(serviceInterfaces);

            foreach(var handler in handlers)
            {
                services.AddScoped(handler.GetInterfaces().First(t => t.IsGenericType && t.GetGenericTypeDefinition() == serviceInterfaces), handler);
            }
        }

        public static void RegisterCommandHandlers(this IServiceCollection services)
        {
            var serviceInterfaces = typeof(ICommandHandler<>);
            var handlers = GetGenericTypes(serviceInterfaces);
            var dispatcher = services.BuildServiceProvider().GetService<ICommandDispatcher>();


            foreach(var handler in handlers)
            {
                var interfaceForDI = handler.GetInterfaces().First(t => t.IsGenericType && t.GetGenericTypeDefinition() == serviceInterfaces);
                var command = Activator.CreateInstance(interfaceForDI.GenericTypeArguments.First()) as ICommand;
                dispatcher.RegisterHandler(command, handler);
            }
        }

        public static void RegisterQueryHandlers(this IServiceCollection services)
        {
            var serviceInterfaces = typeof(IQueryHandler<>);
            var handlers = GetGenericTypes(serviceInterfaces);
            var dispatcher = services.BuildServiceProvider().GetService<IQueryDispatcher>();


            foreach (var handler in handlers)
            {
                var interfaceForDI = handler.GetInterfaces().First(t => t.IsGenericType && t.GetGenericTypeDefinition() == serviceInterfaces);
                var command = Activator.CreateInstance(interfaceForDI.GenericTypeArguments.First()) as IQuery;
                dispatcher.RegisterHandler(command, handler);
            }
        }

        private static Type[] GetAssemblyTypes() => typeof(Startup).Assembly.GetTypes();

        private static IEnumerable<Type> GetGenericTypes(Type serviceInterfaces) =>
            GetAssemblyTypes()
                .Where(x => x.GetInterfaces().Any(t => t.IsGenericType && t.GetGenericTypeDefinition() == serviceInterfaces));

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
