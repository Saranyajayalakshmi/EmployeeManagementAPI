using EmployeeManagementAPI.LogError;
using System.Net;
using System.Text.Json;
using static EmployeeManagementAPI.ExceptionHandling.UpdateException;

namespace EmployeeManagementAPI.ErrorManagement
{
    // Creating Global Middlware Error with Handling process
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _logger;

        public GlobalErrorHandlingMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            _next = next;
            _logger = loggerService;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went Wrong:{ex}");
                await HandleExceptionAsync(context, ex);
            }
        }
        // with Http Statuscode, Exception Error
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode status;
            var stackTrace = string.Empty;
            string message;

            var exceptionType = exception.GetType();

            if (exceptionType == typeof(EmployeeBadRequestException))
            {
                message = exception.Message;
              //  message=exception.InnerException;
                status = HttpStatusCode.BadRequest;
                stackTrace = exception.StackTrace;
            }
            else if (exceptionType == typeof(EmployeeNotFoundException))
            {
                message = exception.Message;
                status = HttpStatusCode.NotFound;
                //stackTrace = exception.StackTrace;
            }
            else if (exceptionType == typeof(IdNotFoundException))
            {
                status = HttpStatusCode.Unauthorized;
                message = exception.Message;
                stackTrace = exception.StackTrace;
            }
            else
            {
                message = exception.Message;
                status = HttpStatusCode.InternalServerError;
            }
            var exceptionResult = JsonSerializer.Serialize(new { ErrorMessage = message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            return context.Response.WriteAsync(exceptionResult);
        }

    }
}
