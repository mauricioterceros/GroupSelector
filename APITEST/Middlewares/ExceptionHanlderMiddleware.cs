using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BackingServices.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace APITEST.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHanlderMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHanlderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                Console.WriteLine("This is the Exception Middleware");
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleError(httpContext, ex);
            }
        }

        private static Task HandleError(HttpContext httpContext, Exception ex)
        {
            int httpStatusCode;
            string messageToShow;
            if (ex is BackingServiceException)
            {
                httpStatusCode = (int)HttpStatusCode.ServiceUnavailable;
                messageToShow = ex.Message;
            }
            else
            {
                httpStatusCode = (int)HttpStatusCode.InternalServerError;
                messageToShow = "The server occurs an unexpected error.";
            }

            var errorModel = new
            {
                status = httpStatusCode,
                message = messageToShow
            };

            // httpContext.Response.StatusCode = httpStatusCode;
            return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(errorModel));
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHanlderMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHanlderMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHanlderMiddleware>();
        }
    }
}
