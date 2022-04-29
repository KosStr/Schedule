using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Schedule.Core.Exceptions;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Schedule.Core.Enums;

namespace Schedule.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IHostEnvironment env;
        private readonly ILogger<ExceptionMiddleware> logger;

        public ExceptionMiddleware(
            RequestDelegate next,
            IWebHostEnvironment env,
            ILogger<ExceptionMiddleware> logger)
        {
            this.next = next;
            this.env = env;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            logger.LogInformation("Handle error!");

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            string responseMessage = "Internal server error";
            string logMessage = exception.Message;

            Dictionary<Type, ResponseInformation> exceptions = GenerateExceptionsDictionary(exception);

            if (exceptions.TryGetValue(exception.GetType(), out ResponseInformation responseInformation))
            {
                logMessage = responseInformation.LogMessage;

                context.Response.ContentType = responseInformation.ContentType;
                context.Response.StatusCode = responseInformation.StatusCode;
                if (env.IsDevelopment())
                {
                    responseMessage = responseInformation.ResponseMessage;
                }
            }

            logger.LogError(exception, logMessage);
            return context.Response.WriteAsync(responseMessage);
        }

        private static Dictionary<Type, ResponseInformation> GenerateExceptionsDictionary(Exception exception)
        {
            var exceptionsDictionary = new Dictionary<Type, ResponseInformation>();
            var defaultApplicationException = exception as DefaultApplicationException;

            exceptionsDictionary.Add(
                typeof(DbUpdateConcurrencyException),
                new ResponseInformation()
                {
                    LogMessage = JsonConvert.SerializeObject(
                        new
                        {
                            StatusCode = 204,
                        }),
                    ResponseMessage = JsonConvert.SerializeObject(
                            new
                            {
                                StatusCode = 204,
                            }),
                    StatusCode = 204,
                });

            exceptionsDictionary.Add(
                typeof(DbUpdateException),
                new ResponseInformation()
                {
                    LogMessage = JsonConvert.SerializeObject(
                        new
                        {
                            StatusCode = 500,
                            exception.InnerException?.Message,
                            Severity = Severity.Error,
                        }),
                    ResponseMessage = JsonConvert.SerializeObject(
                        new
                        {
                            StatusCode = 500,
                            exception.InnerException?.Message,
                            Severity = Severity.Error,
                        }),
                    StatusCode = 500,
                    ContentType = "application/json",
                });

            exceptionsDictionary.Add(
                typeof(DefaultApplicationException),
                new ResponseInformation()
                {
                    LogMessage = JsonConvert.SerializeObject(
                        new
                        {
                            defaultApplicationException?.StatusCode,
                            defaultApplicationException?.Message,
                            defaultApplicationException?.Severity,
                        }),
                    ResponseMessage = JsonConvert.SerializeObject(
                        new
                        {
                            defaultApplicationException?.StatusCode,
                            defaultApplicationException?.Message,
                            defaultApplicationException?.Severity,
                        }),
                    StatusCode = (exception is DefaultApplicationException ex) ? ex.StatusCode : 200,
                    ContentType = "application/json",
                });

            return exceptionsDictionary;
        }
    }
}
