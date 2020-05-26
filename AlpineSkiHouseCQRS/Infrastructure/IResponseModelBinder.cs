using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlpineSkiHouseCQRS.Infrastructure
{
    public interface IResponseModelBinder
    {
        void Bind(object result, Microsoft.AspNetCore.Http.HttpContext context);
    }
}
