using Microsoft.AspNetCore.Mvc;

namespace EcoScope.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public GlobalExceptionMiddleware(RequestDelegate _next)
        {
            next = _next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);

            }
            catch (Exception)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "Internal server error",
                    Detail = "Unexpected error"
                };

                await context.Response.WriteAsJsonAsync(problemDetails);
            }

        }
    }
}
