using static EmployeeManagementAPI.ExceptionHandling.UpdateException;
using System.Net;
using System.Text.Json;

namespace EmployeeManagementAPI.ErrorManagement
{
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
                //stackTrace = exception.StackTrace;
            }
            else if (exceptionType == typeof(EmployeeNotFoundException))
            {
                message = exception.Message;
                status = HttpStatusCode.NotFound;
                //stackTrace = exception.StackTrace;
            }else
            {
                message = exception.Message;
                status = HttpStatusCode.InternalServerError;
            }
            var exceptionResult = JsonSerializer.Serialize(new { Error = message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            return context.Response.WriteAsync(exceptionResult);
        }

    }
}
