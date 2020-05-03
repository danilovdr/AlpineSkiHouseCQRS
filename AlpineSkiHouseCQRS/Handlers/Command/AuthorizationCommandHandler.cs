using AlpineSkiHouseCQRS.Exceptions;
using AlpineSkiHouseCQRS.Infrastructure;
using AlpineSkiHouseCQRS.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AlpineSkiHouseCQRS.Handlers.Command
{
    public class AuthorizationCommandHandler : ICommandHandler<AuthorizationCommand>
    {
        public AuthorizationCommandHandler()
        {

        }
        public async Task Handle(AuthorizationCommand parametrs)
        {
            if (!await IsUserValid(parametrs)) throw new UserNotFoundException();

            var identity = CreateIdentity(parametrs);

            throw new NotImplementedException();
        }


        private async Task<bool> IsUserValid(AuthorizationCommand model)
        {
            throw new NotImplementedException();
        }

        private ClaimsIdentity CreateIdentity(AuthorizationCommand model)
        {
            throw new NotImplementedException();
        }
    }
}
