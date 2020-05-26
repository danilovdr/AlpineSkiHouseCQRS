using AlpineSkiHouseCQRS.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlpineSkiHouseCQRS.Dispatchers
{
    public class QueryDispatcher : IQueryDispatcher
    {
        IServiceProvider _services;
        static readonly IDictionary<Guid, Type> _queryHandlersMap = new Dictionary<Guid, Type>();
        public QueryDispatcher(IServiceProvider services)
        {
            _services = services;
        }
        public IQueryHandler<IQuery> Dispatch(IQuery parametr)
        {
            var id = parametr.ModelType.GUID;
            var type = _queryHandlersMap[id];
            return _services.CreateScope().ServiceProvider.GetRequiredService(type) as IQueryHandler<IQuery>;
        }

        public void RegisterHandler(IQuery dataModel, Type handlerType)
        {
            var code = dataModel.ModelType.GUID;
            _queryHandlersMap.TryAdd(code, handlerType);
        }
    }
}
