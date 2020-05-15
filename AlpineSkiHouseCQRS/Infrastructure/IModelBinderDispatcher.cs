using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlpineSkiHouseCQRS.Infrastructure
{
    public interface IModelBinderDispatcher
    {
        IRequestModelBinder<IDataModel> DispatchRequestModel(Type type);

        IResponseModelBinder DispatchResponseModel(Type type);
    }
}
