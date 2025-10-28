using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MiniBank.Security;

public class JwtAuthenticationMiddleware
{
    private readonly RequestDelegate _next;

    public JwtAuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Headers.TryGetValue("Authorization", out StringValues authHeader))
        {
            var token = authHeader.FirstOrDefault()?.Split(" ").Last();
            if (!string.IsNullOrEmpty(token))
            {
                var handler = new JwtSecurityTokenHandler();
                try
                {
                    var jwtToken = handler.ReadJwtToken(token);
                    var identity = new ClaimsIdentity(jwtToken.Claims, "jwt");
                    context.User = new ClaimsPrincipal(identity);
                    MinibankUserSession.BuildFromJWT(context.User);
                }
                catch
                {
                    // Invalid token, do nothing or log as needed
                }
            }
        }

        await _next(context);
    }
}