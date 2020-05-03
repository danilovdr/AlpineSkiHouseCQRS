using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlpineSkiHouseCQRS.Infrastructure
{
    public interface ICommandHandler<T> where T:ICommand
    {
        HttpContext HttpContext { get; }
        Task Handle(T parametrs);
        void SetHttpContext(HttpContext context);
    }
}
