using AlpineSkiHouseCQRS.Data.Interfaces.Repositories;
using AlpineSkiHouseCQRS.Data.Models;
using AlpineSkiHouseCQRS.Exceptions;
using AlpineSkiHouseCQRS.Infrastructure;
using AlpineSkiHouseCQRS.Models;
using Microsoft.AspNetCore.Http;
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
        IRepository<UserModel> _userRepository;
        public AuthorizationCommandHandler(IRepository<UserModel> userRepository)
        {
            _userRepository = userRepository;
        }

        public HttpContext HttpContext { get; private set; }

        public void SetHttpContext(HttpContext context)
        {
            if (HttpContext != null) throw new InvalidOperationException("Context already set");

            HttpContext = context;
        }

        public async Task Handle(AuthorizationCommand parametrs)
        {
            if (!await IsUserValid(parametrs)) throw new UserNotFoundException();

            var identity = CreateIdentity(parametrs);
            var token = CreateToken(identity);

            HttpContext.Response.Cookies.Append(Constants.JWT_COOKIE, token);
        }


        private async Task<bool> IsUserValid(AuthorizationCommand model)
        {
        }

        private ClaimsIdentity CreateIdentity(AuthorizationCommand model)
        {
            throw new NotImplementedException();
        }

        private string CreateToken(ClaimsIdentity identity)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateJwtSecurityToken(subject: identity, expires: DateTime.UtcNow.AddDays(1));
            return handler.WriteToken(token);
        }
    }
}
