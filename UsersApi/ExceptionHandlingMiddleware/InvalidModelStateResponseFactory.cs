﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersApi.Application;

namespace UsersApi.ExceptionHandlingMiddleware
{
    public static class InvalidModelStateResponseFactory
    {
        public static IActionResult ProduceErrorResponse(ActionContext context)
        {
            string messages = string.Join("; ", context.ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
            var response = new ErrorResponse 
            { 
                Code = "Validation Failure",
                Message = messages ,
                Errors = new List<Error>
                {
                    new Error
                    {
                        Code = "Validation Failure",
                        Description = "Validation Failure"
                    }
                }
            };

            return new BadRequestObjectResult(response);
        }
    }
}
