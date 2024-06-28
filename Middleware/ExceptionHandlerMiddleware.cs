using Microsoft.AspNetCore.Http;
using OrchestratorServer.Exceptions;
using System;
using System.Net;
using System.Threading.Tasks;

namespace OrchestratorServer.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
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

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            var message = "An unexpected error occurred.";

            switch (ex)
            {
                case NotFoundException _:
                    statusCode = HttpStatusCode.NotFound;
                    message = ex.Message;
                    break;
                case ServiceException _:
                    statusCode = HttpStatusCode.BadRequest;
                    message = ex.Message;
                    break;
                    // Add more cases as needed
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(new
            {
                StatusCode = context.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }
}
