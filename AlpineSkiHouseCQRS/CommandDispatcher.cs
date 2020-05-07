using AlpineSkiHouseCQRS.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlpineSkiHouseCQRS
{
    public class CommandDispatcher : ICommandDispatcher
    {
        IServiceProvider _services;
        public CommandDispatcher(IServiceProvider services)
        {
            _services = services;
        }
        public ICommandHandler<T> Dispatch<T>(T command) where T : ICommand
        {
            return _services.CreateScope().ServiceProvider.GetRequiredService<ICommandHandler<T>>();
        }
    }
}
