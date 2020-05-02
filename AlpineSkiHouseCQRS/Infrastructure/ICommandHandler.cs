using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlpineSkiHouseCQRS.Infrastructure
{
    public interface ICommandHandler<T> where T:ICommand
    {
        Task Handle(T parametrs);
    }
}
