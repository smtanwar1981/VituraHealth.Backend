using System.Net;
using System.Text.Json;

namespace VituraHealth.Api.Middleware
{
    public class GlobalExceptionHandlingMiddleware (RequestDelegate _next, ILogger<GlobalExceptionHandlingMiddleware> _logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "An unhandled exception occurred: {Message}", ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var errorResponse = new
            {
                context.Response.StatusCode,
                Message = "An unhandled error occurred. Please try again later.",
                Details = context.RequestServices.GetRequiredService<IWebHostEnvironment>().IsDevelopment() ? exception.ToString() : null
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        }
    }
}
