using DocumentAccessApproval.Application.Common;
using System.Net;
using System.Security.Authentication;
using System.Text.Json;

namespace DocumentAccessApproval.Api.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, "An unhandled exception has occurred.");

            HttpStatusCode code;
            string result;

            switch (exception)
            {
                case NotFoundException notFoundException:
                    code = HttpStatusCode.NotFound;
                    result = JsonSerializer.Serialize(new { error = notFoundException.Message });
                    break;
                case AuthenticationException authException:
                    code = HttpStatusCode.Unauthorized;
                    result = JsonSerializer.Serialize(new { error = authException.Message });
                    break;
                case InvalidOperationException invalidOpException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(new { error = invalidOpException.Message });
                    break;
                default:
                    code = HttpStatusCode.InternalServerError;
                    result = JsonSerializer.Serialize(new { error = "An unexpected error occurred. Please try again." });
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            await context.Response.WriteAsync(result);
        }
    }
}
