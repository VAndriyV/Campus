using Campus.WebUI.Identity.Jwt.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Campus.WebUI.Identity.Jwt.Extensions
{
    public static class SecureJwtMiddlewareExtensions
    {
        public static IApplicationBuilder UseSecureJwt(this IApplicationBuilder builder) => builder.UseMiddleware<SecureJwtMiddleware>();
    }
}
