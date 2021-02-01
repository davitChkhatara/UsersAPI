using System;
using System.Collections.Generic;
using System.Text;

namespace UsersApi.Application.Exceptions
{
    public class UserUnableToDeleteException : Exception
    {
        public UserUnableToDeleteException(string userName, List<Error> errors) : base($"User can not be deleted. UserName : {userName}")
        {
            Data["Errors"] = errors;
        }
    }
}
