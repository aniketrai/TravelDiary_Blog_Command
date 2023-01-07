using Microsoft.AspNetCore.Builder;
using TravelDiary.Blog.Command.Core.Middleware;

namespace TravelDiary.Blog.Command.Core.Extensions
{

    public static class CorrelationIdMiddlewareExtensions
    {
        public static IApplicationBuilder UseCorrelationId(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CorrelationIdMiddleware>();
        }
    }
}
