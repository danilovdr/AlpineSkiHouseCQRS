using AlpineSkiHouseCQRS.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlpineSkiHouseCQRS
{
    public class CommandDispatcher : ICommandDispatcher
    {
        IServiceProvider _services;
        static readonly IDictionary<Guid, Type> _commandHandlerTypes = new Dictionary<Guid, Type>();
        public CommandDispatcher(IServiceProvider services)
        {
            _services = services;
        }
        public ICommandHandler<ICommand> Dispatch(ICommand command)
        {
            var id = command.ModelType.GUID;
            var type = _commandHandlerTypes[id];
            return _services.CreateScope().ServiceProvider.GetRequiredService(type) as ICommandHandler<ICommand>;
        }

        public void RegisterHandler(ICommand dataModel, Type handlerType)
        {
            var code = dataModel.ModelType.GUID;
            _commandHandlerTypes.TryAdd(code, handlerType);
        }
    }
}
