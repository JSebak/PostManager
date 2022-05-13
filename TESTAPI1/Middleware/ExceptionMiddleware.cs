using System.Net;
using TEST_API1.Middleware.Models.Response;
using TESTAPI1.Domain.Models;
using TESTAPI1.Infrastructure.Models;

namespace TEST_API1.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly ILoggerManager _logger;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (DomainException ex)
            {
                //_logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
            catch (InfrastructureException ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var message = ex switch
            {
                DomainException => $"Domain error from the middleware. {ex.Message}",
                InfrastructureException => $"Infrastructure error from the middleware. {ex.Message}",
                _ => $"Middleware error {ex.Message}"
            };
            var type = ex switch
            {
                DomainException => "Domain",
                InfrastructureException => "Infrastructure",
                _ => "Exception"
            };
            await context.Response.WriteAsync(new ResponseModel<bool?>()
            {
                ErrorMessage = message,
                StatusCode = (int)HttpStatusCode.InternalServerError,
                ErrorType = type,
                Result = null
            }.ToString());
        }
    }
}
