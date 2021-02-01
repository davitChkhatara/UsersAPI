using System;
using System.Collections.Generic;
using System.Text;

namespace UsersApi.Application.Exceptions
{
    public class UserUnableToCreateException : Exception
    {
        public UserUnableToCreateException(string userName,List<Error> errors) : base($"Username or password is incorrect. UserName : {userName}")
        {
            Data["Errors"] = errors;
        }
    }
}
