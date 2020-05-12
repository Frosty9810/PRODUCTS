using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using BackingServices.Exceptions;


namespace PRODUCTS.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                Console.WriteLine("This is the exception Middleware");
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
            else if (ex is InvalidOperationException)
            {


                httpStatusCode = (int)HttpStatusCode.BadRequest;
                messageToShow = ex.Message;

            }
            else 
            {
                httpStatusCode = (int)HttpStatusCode.InternalServerError;
                messageToShow = "The server ocurrs an unexpected error.";
            }
            var errorModel = new
            {
                status = httpStatusCode,
                message = messageToShow
            };
            httpContext.Response.StatusCode = httpStatusCode;
            return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(errorModel));
    }
   }
    //Agarra y tener el middleware como parte de config
    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
