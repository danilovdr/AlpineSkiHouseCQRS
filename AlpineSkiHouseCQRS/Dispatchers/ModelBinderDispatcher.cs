using AlpineSkiHouseCQRS.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlpineSkiHouseCQRS.Dispatchers
{
    public class ModelBinderDispatcher : IModelBinderDispatcher
    {
        readonly IDictionary<string, Type> _responseBinderMap = new Dictionary<string, Type>();
        readonly IDictionary<string, Type> _requestBinderMap = new Dictionary<string, Type>();

        readonly IRequestModelBinder<IDataModel> _defaultRequestModelBinder;
        readonly IResponseModelBinder _defaultResponseModelBinder;
        readonly IServiceProvider _services;

        public ModelBinderDispatcher(
            IRequestModelBinder<IDataModel> defaultRequestModelBinder, 
            IResponseModelBinder defaultResponseModelBinder,
            IServiceProvider services)
        {
            _defaultRequestModelBinder = defaultRequestModelBinder;
            _defaultResponseModelBinder = defaultResponseModelBinder;
            _services = services;
        }
        public IRequestModelBinder<IDataModel> DispatchRequestModel(string requestPath)
        {
            if (!_requestBinderMap.ContainsKey(requestPath)) return _defaultRequestModelBinder;

            var binderType = _responseBinderMap[requestPath];
            return _services.GetService(binderType) as IRequestModelBinder<IDataModel>;
        }

        public IResponseModelBinder DispatchResponseModel(string requestPath)
        {
            if (!_responseBinderMap.ContainsKey(requestPath)) return _defaultResponseModelBinder;

            var binderType = _responseBinderMap[requestPath];
            return _services.GetService(binderType) as IResponseModelBinder;
        }

        public void RegisterRequestBinder(string request, Type binderType)
        {
            _requestBinderMap.Add(request, binderType);
        }

        public void RegisterResponseBinder(string request, Type binderType)
        {
            _responseBinderMap.Add(request, binderType);
        }
    }
}
