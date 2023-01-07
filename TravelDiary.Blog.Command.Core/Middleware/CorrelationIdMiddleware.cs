using Microsoft.AspNetCore.Http;

namespace TravelDiary.Blog.Command.Core.Middleware
{
    public class CorrelationIdMiddleware
    {

        private readonly RequestDelegate _next;
        public CorrelationIdMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            if (context != null && !context.Request.Headers.ContainsKey("X-Correlation-Id"))
            {
                context.Response.Headers.Add("X-Correlaion-Id", Guid.NewGuid().ToString());
            }
            else
            {
                if (string.IsNullOrWhiteSpace(context?.Request.Headers["X-Correlation-Id"]))
                {
                    context?.Response.Headers.Add("X-Correlaion-Id", Guid.NewGuid().ToString());
                }
                else
                    context?.Response.Headers.Add("X-Correlaion-Id", context.Request.Headers["X-Correlation-Id"]);
            }

            await _next(context);

        }

    }

}
