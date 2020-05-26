using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlpineSkiHouseCQRS.Infrastructure
{
    public interface ICommandDispatcher
    {
        ICommandHandler<ICommand> Dispatch(ICommand command);
        void RegisterHandler(ICommand command, Type handlerType);
    }
}
