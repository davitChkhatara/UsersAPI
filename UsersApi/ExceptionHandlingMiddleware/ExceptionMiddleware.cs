using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using UsersApi.Application;
using UsersApi.Application.Exceptions;
using UsersApi.Domain.Enums;

namespace UsersApi.ExceptionHandlingMiddleware
{
    public class ExceptionMiddleware : ExceptionFilterAttribute
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            switch (ex)
            {
                case UserUnableToCreateException _:
                case UserNotFoundException _:
                case UserUnableToDeleteException _:
                case UserUnableToSignException _:
                case UserAlreadyExistsException _:
                    context.Response.ContentType = "application/json"; ;
                    context.Response.StatusCode = (int)HttpStatusCode.Conflict;

                    return context.Response.WriteAsync(JsonSerializer.Serialize(new ErrorResponse
                    {
                        Code = ErrorResponseCodesEnum.ERROR.Value,
                        Message = ex.Message,
                        Errors = GetErrors(ex, HttpStatusCode.Conflict)
                    }, options));
                default:
                    context.Response.ContentType = "application/json"; ;
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    return context.Response.WriteAsync(JsonSerializer.Serialize(new ErrorResponse
                    {
                        Code = ErrorResponseCodesEnum.UNKNOWN_ERROR.Value,
                        Message = ex.Message,
                        Errors = GetErrors(ex, HttpStatusCode.InternalServerError)
                    }, options));

            }
        }

        private static List<Error> GetErrors(Exception ex,HttpStatusCode statusCode)
        {
            if(ex.Data is object && ex.Data["Errors"] is object)
            {
                return (List<Error>)ex.Data["Errors"];
            }
            return new List<Error>
            {
                new Error
                {
                    Code = statusCode.ToString(),
                    Description = ex.Message
                }
            };
        }

    }
}
