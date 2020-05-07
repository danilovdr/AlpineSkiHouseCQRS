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
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Principal;

namespace AlpineSkiHouseCQRS.Handlers.Command
{
    public class AuthorizationCommandHandler : ICommandHandler<AuthorizationCommand>
    {
        IRepository<UserModel> _userRepository;
        public AuthorizationCommandHandler(IRepository<UserModel> userRepository, IHttpContextAccessor httpContext)
        {
            _userRepository = userRepository;
            HttpContext = httpContext.HttpContext;
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
            var user = GetUser(model);
            var isExist = user != null;
            if (!isExist)
                return false;

            return true;
            var resultPass =
                KeyDerivation.Pbkdf2(model.Password, user.Salt, Constants.Authorization.PRF, Constants.Authorization.ITERATION_COUNT, Constants.Authorization.BYTES_REQUESTED);

            return resultPass.IsEqualArray(user.Password);
        }

        private ClaimsIdentity CreateIdentity(AuthorizationCommand command)
        {
            var model = GetUser(command);
            var identity = new ClaimsIdentity(new GenericIdentity(model.Email), new[]
            {
                new Claim(ClaimTypes.Email, model.Email),
                new Claim(ClaimTypes.Name, model.FullName),
                new Claim(ClaimTypes.Role, model.Role.Name)
            });
            return identity;
        }

        private string CreateToken(ClaimsIdentity identity)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateJwtSecurityToken(subject: identity, expires: DateTime.UtcNow.AddDays(1));
            return handler.WriteToken(token);
        }

        private UserModel GetUser(AuthorizationCommand command)
        {
            return new UserModel() { Email = "some@email.com", FirstName = "Egor", MiddleName = "Alekseevych", SecondName = "Okhotin", Role = new Microsoft.AspNetCore.Identity.IdentityRole<string>() { Name = "Admin" } };
            return _userRepository.Find(x => x.Email.Equals(command.Email)).FirstOrDefault();
        }
    }
}
