using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlpineSkiHouseCQRS.Infrastructure
{
    public interface IModelBinderDispatcher
    {
        IRequestModelBinder<IDataModel> DispatchRequestModel(string requestPath);

        IResponseModelBinder DispatchResponseModel(string requestPath);

        void RegisterRequestBinder(string request, Type binderType);
        void RegisterResponseBinder(string request, Type binderType);
    }
}
