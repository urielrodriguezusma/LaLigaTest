using Catalog.Api.Errors;
using System.Text.Json;

namespace Catalog.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;
        private readonly IHostEnvironment env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger,IHostEnvironment env)
        {
            this.next = next;
            this.logger = logger;
            this.env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                string json = string.Empty;
                if (env.IsDevelopment())
                {
                    json = JsonSerializer.Serialize(new ApiException(StatusCodes.Status500InternalServerError, ex.Message, ex.StackTrace.ToString()),options);
                }
                else
                {
                    json = JsonSerializer.Serialize(new ApiResponse(StatusCodes.Status500InternalServerError),options);
                }

                await context.Response.WriteAsync(json);
            }
        }
    }
}
