using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersApi.Application;
using UsersApi.Domain.Enums;

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
                Code = ErrorResponseCodesEnum.VALIDATION_ERROR.Value,
                Message = messages ,
                Errors = new List<Error>
                {
                    new Error
                    {
                        Code = ErrorResponseCodesEnum.VALIDATION_ERROR.Value,
                        Description = messages
                    }
                }
            };

            return new BadRequestObjectResult(response);
        }
    }
}
