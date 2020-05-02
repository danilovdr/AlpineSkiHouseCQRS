using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlpineSkiHouseCQRS.Infrastructure
{
    public interface ICommandDispatcher
    {
        ICommandHandler<T> Dispatch<T>(T command) where T:ICommand;
    }
}
