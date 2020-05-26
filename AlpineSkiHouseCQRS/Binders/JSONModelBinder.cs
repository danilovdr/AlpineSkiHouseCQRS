using AlpineSkiHouseCQRS.Infrastructure;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace AlpineSkiHouseCQRS.Binders
{
    public class JSONModelBinder : IRequestModelBinder<IDataModel>, IResponseModelBinder
    {
        
        public IDataModel Bind(HttpContext context)
        {
            throw new NotImplementedException();
        }

        public void Bind(object result, HttpContext context)
        {
            throw new NotImplementedException();
        }
    }
}
