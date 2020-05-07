using AlpineSkiHouseCQRS.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlpineSkiHouseCQRS
{
    public class QueryDispatcher : IQueryDispatcher
    {
        IServiceProvider _services;
        public QueryDispatcher(IServiceProvider services)
        {
            _services = services;
        }
        public IQueryHandler<IQuery<TResult>, TResult> Dispatch<TResult>(IQuery<TResult> parametr)
        {
            return _services.CreateScope().ServiceProvider.GetRequiredService<IQueryHandler<IQuery<TResult>, TResult>>();
        }
    }
}
