using AlpineSkiHouseCQRS.Infrastructure;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace AlpineSkiHouseCQRS.Middleware
{
    public class CQRSRouting
    {
        IQueryDispatcher _queryDispatcher;
        ICommandDispatcher _commandDispatcher;
        IModelBinderDispatcher _modelBinderDispatcher;
        RequestDelegate _next;
        public CQRSRouting(
            IQueryDispatcher queryDispatcher, 
            ICommandDispatcher commandDispatcher,
            IModelBinderDispatcher modelBinderDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
            _modelBinderDispatcher = modelBinderDispatcher;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var isCommand = context.Request.Path.StartsWithSegments("/command");
            var isQuery = context.Request.Path.StartsWithSegments("/query");

            if (isCommand)
            {
                await _next(context); //authorize
                await HandleCommandRequest(context);
                return;
            }

            if(isQuery)
            {
                await _next(context);
                await HandleQueryRequest(context);
                return;
            }
        }

        private async Task HandleCommandRequest(HttpContext context)
        {
            var commandTypeName = context.Request.Path.Value.Split('/').Last() + "command";
            var commandType = GetType().Assembly.GetType(commandTypeName);
            if (commandType == null)
                throw new InvalidOperationException(); //заменить на другой тип экспшена чтобы bad request кидало

            //! validation

            var binder = _modelBinderDispatcher.DispatchRequestModel(commandType);
            var command = binder.Bind(context) as ICommand;
            var handler = _commandDispatcher.Dispatch(command);

            await handler.Handle(command);
        }

        private async Task HandleQueryRequest(HttpContext context)
        {
            var queryTypeName = context.Request.Path.Value.Split('/').Last() + "command";
            var queryType = GetType().Assembly.GetType(queryTypeName);
            if (queryType == null)
                throw new InvalidOperationException(); //заменить на другой тип экспшена чтобы bad request кидало

            //! validation

            var binder = _modelBinderDispatcher.DispatchRequestModel(queryType);
            var query = binder.Bind(context) as IQuery;
            var handler = _queryDispatcher.Dispatch(query);

            await handler.Handle(query);
            var result = query.Result;

            var resultBinder = _modelBinderDispatcher.DispatchResponseModel(query.ResultType);
            resultBinder.Bind(result, context);
        }
    }
}
