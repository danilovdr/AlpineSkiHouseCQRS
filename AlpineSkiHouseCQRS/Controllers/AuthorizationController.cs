using AlpineSkiHouseCQRS.Infrastructure;
using AlpineSkiHouseCQRS.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlpineSkiHouseCQRS.Controllers
{
    public class AuthorizationController : ControllerBase
    {
        ICommandDispatcher _commandDispatcher;
        public AuthorizationController(ICommandDispatcher dispatcher)
        {
            _commandDispatcher = dispatcher;
        }

        [HttpPost]
        public async Task<StatusCodeResult> Authorize(AuthorizationCommand command)
        {
            await _commandDispatcher.Dispatch(command, HttpContext).Handle(command);
            return new StatusCodeResult((int)System.Net.HttpStatusCode.OK);
        }
    }

}
