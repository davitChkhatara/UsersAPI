using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using UsersApi.Models;

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
            switch (ex)
            {
                //case ValidationException e:
                //    context.Response.ContentType = "application/json"; ;
                //    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //    var response = new ErrorResponse
                //    {
                //        Error = new Error { Errors = new List<string>() }
                //    };
                //    response.Error.Code = (int)HttpStatusCode.BadRequest;
                //    response.Error.Message = "validation failure";
                //    foreach (var error in e.Errors)
                //    {
                //        response.Error.Errors.Add(error.ErrorMessage);
                //    }
                //    return context.Response.WriteAsync(JsonSerializer.Serialize(response, SerilizerOptions.SnakeNameSerializerOptions()));


                default:
                    context.Response.ContentType = "application/json"; ;
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                    return context.Response.WriteAsync(JsonSerializer.Serialize(new ErrorResponse
                    {
                        Code = HttpStatusCode.InternalServerError.ToString(),
                        Message = ex.Message
                    }));

            }
        }




        }
    }
