using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using BusinessLogic.Exceptions;


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
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleError(httpContext, ex);
            }
        }

        private static int getCode(Exception ex)
        {

            int code = 500;
            //Agarra el tipo de exception 
            if (ex.GetType() == typeof(EmptyorNullNameException))
                code = ((EmptyorNullNameException)ex).Code;
            if (ex.GetType() == typeof(EmptyOrNullTypeException))
                code = ((EmptyOrNullTypeException)ex).Code;
            if (ex.GetType() == typeof(StockBetweenException))
                code = ((StockBetweenException)ex).Code;
            if (ex.GetType() == typeof(NameLengthException))
                code = ((NameLengthException)ex).Code;
            if (ex.GetType() == typeof(CodeNullorEmptyException))
                code = ((CodeNullorEmptyException)ex).Code;
            if (ex.GetType() == typeof(NotFoundCodeException))
                code = ((NotFoundCodeException)ex).Code;
            if (ex.GetType() == typeof(InvalidTypeException))
                code = ((InvalidTypeException)ex).Code;

            return code;
        }
        private static Task HandleError(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            var errorObj = new
            {
                code = getCode(ex),
                message = ex.Message
            };

            string jsonObj = JsonConvert.SerializeObject(errorObj);
            context.Response.StatusCode = getCode(ex);
            return context.Response.WriteAsync(jsonObj);
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
