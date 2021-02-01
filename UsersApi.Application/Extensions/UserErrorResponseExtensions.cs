using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UsersApi.Application.Extensions
{
    public static class UserErrorResponseExtensions
    {
        public static List<Error> GetErrorList(this IEnumerable<IdentityError> errors)
        {
            try
            {
                return errors.Select(x => new Error
                {
                    Code = x.Code,
                    Description = x.Description
                }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
