using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlpineSkiHouseCQRS.Infrastructure
{
    public interface IQueryDispatcher
    {
        IQueryHandler<IQuery> Dispatch(IQuery parametr);
        void RegisterHandler(IQuery query, Type handlerType);
    }
}
