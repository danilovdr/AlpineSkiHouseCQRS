using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlpineSkiHouseCQRS.Infrastructure
{
    public interface IQueryHandler<TQuery, TResult>
        where TQuery: IQuery<TResult>
    {
        Task<TResult> Handle(TQuery parameters);
    }
}
