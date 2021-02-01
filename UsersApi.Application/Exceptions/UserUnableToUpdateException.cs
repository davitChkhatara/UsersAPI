using System;
using System.Collections.Generic;
using System.Text;

namespace UsersApi.Application.Exceptions
{
    public class UserUnableToUpdateException : Exception
    {
        public UserUnableToUpdateException(string userName, List<Error> errors) : base($"User was not updated. UserName : {userName}")
        {
            Data["Errors"] = errors;
        }
    }
}
