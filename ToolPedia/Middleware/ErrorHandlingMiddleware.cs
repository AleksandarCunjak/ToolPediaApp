using System.Net;
using Newtonsoft.Json;

namespace ToolPedia.Api.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ErrorHandlingMiddleware> logger;

        public ErrorHandlingMiddleware(
            RequestDelegate next,
            ILogger<ErrorHandlingMiddleware> logger
        )
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var (statusCode, message, errorCode) = exception switch
            {
                //NotFoundException notFoundException
                //    => ((int)HttpStatusCode.NotFound, notFoundException.Message, "NOT_FOUND"),
                //ValidationException
                //    => (
                //        (int)HttpStatusCode.BadRequest,
                //        "Validation failed. Please check the request.",
                //        "VALIDATION_ERROR"
                //    ),
                //QueryLengthException queryLengthException
                //    => (
                //        (int)HttpStatusCode.BadRequest,
                //        queryLengthException.Message,
                //        "VALIDATION_ERROR"
                //    ),

                _
                    => (
                        (int)HttpStatusCode.InternalServerError,
                        "Internal Server Error",
                        "INTERNAL_ERROR"
                    )
            };

            logger.LogError(
                exception,
                exception.Message,
                exception.GetType().Name,
                exception.InnerException,
                exception.StackTrace
            );

            var result = JsonConvert.SerializeObject(
                new
                {
                    error = new
                    {
                        code = errorCode,
                        message,
                        exception.GetType().Name
                    }
                }
            );
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            await context.Response.WriteAsync(result);
        }
    }
}
