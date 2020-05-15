using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlpineSkiHouseCQRS.Infrastructure
{
    public interface IRequestModelBinder<TRequest>
    {
        TRequest Bind(Microsoft.AspNetCore.Http.HttpContext context);
    }
}
