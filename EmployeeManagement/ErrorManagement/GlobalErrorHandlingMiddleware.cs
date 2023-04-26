using EmployeeManagementAPI.LogError;
using System.Net;
using System.Text.Json;
using static EmployeeManagementAPI.ExceptionHandling.ExceptionModel;

namespace EmployeeManagementAPI.ErrorManagement
{
    // Creating Global Middlware Error with Handling process
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        
        public GlobalErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
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
                status = HttpStatusCode.BadRequest;
                stackTrace = exception.StackTrace;
            }
            else if (exceptionType == typeof(EmployeeNotFoundException))
            {
                message = exception.Message;
                status = HttpStatusCode.NotFound;
            }
            else if (exceptionType == typeof(IdNotFoundException))
            {
                status = HttpStatusCode.NotFound;
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
