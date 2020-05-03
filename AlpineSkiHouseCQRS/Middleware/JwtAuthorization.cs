using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlpineSkiHouseCQRS.Middleware
{
    public class JwtAuthorization
    {
        RequestDelegate _next;
        public JwtAuthorization(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var jwtKey = context.Items["JWT"] as string;
            if (string.IsNullOrEmpty(jwtKey)) await _next(context);

            context.Request.Headers.Add("Authorization", $"Bearer {jwtKey}");

            await _next(context);
        }
    }
}
