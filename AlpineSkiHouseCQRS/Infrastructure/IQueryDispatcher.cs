using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlpineSkiHouseCQRS.Infrastructure
{
    public interface IQueryDispatcher
    {
        IQueryHandler<IQuery<TResult>, TResult> Dispatch<TResult>(IQuery<TResult> parametr);
    }
}
