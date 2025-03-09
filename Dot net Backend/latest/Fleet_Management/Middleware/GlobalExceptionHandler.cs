
using System.ComponentModel.DataAnnotations;
using System.Net;
using Fleet_Management.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace Fleet_Management.Middleware
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;
        private readonly IHostEnvironment _environment;

        public GlobalExceptionHandler(
            ILogger<GlobalExceptionHandler> logger,
            IHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            // Initialize default values for unknown exceptions
            var statusCode = (int)HttpStatusCode.InternalServerError;
            var message = "An unexpected error occurred.";
            Dictionary<string, object>? data = null;

            switch (exception)
            {
                case ApiException ex:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    message = ex.Message;
                    break;
                // Authentication/Authorization
                case UnauthorizedAccessException:
                    statusCode = (int)HttpStatusCode.Unauthorized;
                    message = "Unauthorized access";
                    break;

                // Resource access
                case KeyNotFoundException:
                    statusCode = (int)HttpStatusCode.NotFound;
                    message = "Requested resource not found";
                    break;

                // Validation errors
                case ValidationException ex:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    message = "Validation failed";
                    data = new Dictionary<string, object>
                    {
                        ["errors"] = new[] { ex.ValidationResult.ErrorMessage }
                    };
                    break;

                // Business rule violations
                case InvalidOperationException ex:
                    statusCode = (int)HttpStatusCode.Conflict;
                    message = ex.Message;
                    break;

                // Request format issues
                case BadHttpRequestException:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    message = "Invalid request format";
                    break;
            }

            // Log based on error type
            if (statusCode >= 500)
            {
                _logger.LogError(exception, "Server Error: {Message}", exception.Message);
            }
            else
            {
                _logger.LogWarning(exception, "Client Error: {Message}", exception.Message);
            }

            // Build consistent response
            var response = new ExceptionResponse
            {
                StatusCode = statusCode,
                Message = message
            };

            // Write response
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
            return true;
        }
    }

    public class ExceptionResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
    }

}