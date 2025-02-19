using FluentValidation;
using Microsoft.AspNetCore.Http; 
using System.Net;
using System.Text.Json; 

namespace GlobalExceptionHandlerLibrary
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next)
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
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(ex.Message);
                Console.BackgroundColor = ConsoleColor.Black;


                var statusCode = HttpStatusCode.InternalServerError;
                var errorCode = "InternalServerError";
                 
                if (ex is ArgumentException)
                {
                    statusCode = HttpStatusCode.BadRequest;
                    errorCode = "ArgumentException";
                }  
                else if (ex is UnauthorizedAccessException)
                {
                    statusCode = HttpStatusCode.Unauthorized;
                    errorCode = "UnauthorizedAccessException";
                } 
                else if (ex is ValidationException)
                {
                    statusCode = HttpStatusCode.BadRequest;
                    errorCode = "ValidationException";
                } 

                context.Response.StatusCode = (int)statusCode;
                context.Response.ContentType = "application/json";

                var errorResponse = new
                {
                    Message = ex.Message,
                    ErrorCode = errorCode
                };

                var result = JsonSerializer.Serialize(errorResponse);
                await context.Response.WriteAsync(result);
            }
        }
    }
}
