using Microsoft.IdentityModel.SecurityTokenService;
using ProductWebAPI.Exceptions;
using Serilog.Context;
using System.Globalization;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace ProductWebAPI.Middlewares
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var username = context.User?.Identity?.Name ?? "Anonymous";

            try
            {
                LogContext.PushProperty("user_name", username);
                LogContext.PushProperty("machine_name", Environment.MachineName);

                await next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception, username);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception, string username)
        {
            var code = HttpStatusCode.InternalServerError;
            string result = string.Empty;

            switch (exception)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.UnprocessableEntity;
                    if (validationException.Errors.Any())
                        result = JsonSerializer.Serialize(validationException.Errors);
                    break;

                case ForbiddenException:
                    code = HttpStatusCode.Forbidden;
                    break;

                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;

                case ConflictException:
                    code = HttpStatusCode.Conflict;
                    break;

                case UnauthorizedException:
                    code = HttpStatusCode.Unauthorized;
                    break;

                case BadRequestException:
                    code = HttpStatusCode.BadRequest;
                    break;
            }

            if (string.IsNullOrEmpty(result))
            {
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.Local);

                var data = new
                {
                    status = (int)code,
                    title = exception.Message,
                    user = username,
                    date = localTime.ToString("dd-MM-yyyy HH:mm:ss.fff", CultureInfo.CurrentCulture),
                    machine = Environment.MachineName,
                };

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                result = JsonSerializer.Serialize(data, options);
            }

            context.Response.ContentType = "application/json; charset=utf-8";
            context.Response.StatusCode = (int)code;

            _logger.LogError(exception, "Error occurred: {ErrorMessage}", result);

            await context.Response.WriteAsync(result);
        }
    }
}
