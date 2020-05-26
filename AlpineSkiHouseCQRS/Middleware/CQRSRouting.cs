using AlpineSkiHouseCQRS.Infrastructure;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Text.RegularExpressions;
using Microsoft.Extensions.ObjectPool;

namespace AlpineSkiHouseCQRS.Middleware
{
    //TODO: переделать на zero alloc
    public class CQRSRouting
    {
        IQueryDispatcher _queryDispatcher;
        ICommandDispatcher _commandDispatcher;
        IModelBinderDispatcher _modelBinderDispatcher;
        RequestDelegate _next;
        const string COMMAND_REQUEST_PATTERN = @"[\/]command[\/]([\w]*)";
        const string QUERY_REQUEST_PATTERN = @"[\/]query[\/]([\w]*)";
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
            var match = Regex.Match(context.Request.Path, COMMAND_REQUEST_PATTERN);
            if (!match.Success) throw new InvalidOperationException(); //заменить на другой тип экспшена чтобы bad request кидало

            var commandRequestPath = match.Value;
            var binder = _modelBinderDispatcher.DispatchRequestModel(commandRequestPath);

            var command = binder.Bind(context) as ICommand;

            IsActionExecutionValid(command, context); // переместить валидацию перед биндингом для оптимизации обработки

            var handler = _commandDispatcher.Dispatch(command);

            await handler.Handle(command);
        }

        private async Task HandleQueryRequest(HttpContext context)
        {
            var match = Regex.Match(context.Request.Path, QUERY_REQUEST_PATTERN);
            if (!match.Success) throw new InvalidOperationException(); //заменить на другой тип экспшена чтобы bad request кидало

            var queryRequestPath = match.Value;
            var binder = _modelBinderDispatcher.DispatchRequestModel(queryRequestPath);
            var query = binder.Bind(context) as IQuery;

            IsActionExecutionValid(query, context); // переместить валидацию перед биндингом для оптимизации обработки

            var handler = _queryDispatcher.Dispatch(query);

            await handler.Handle(query);
            var result = query.Result;

            var resultBinder = _modelBinderDispatcher.DispatchResponseModel(queryRequestPath);
            resultBinder.Bind(result, context);
        }

        private bool IsActionExecutionValid(IDataModel command, HttpContext context)
        {
            var attribute = command.ModelType.GetCustomAttribute<AuthorizeAttribute>();
            if (attribute == null) return true;

            if (!context.User.Identity.IsAuthenticated) return false;

            var userRole = context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;

            return attribute.Roles.Contains(userRole);
        }
    }
}
