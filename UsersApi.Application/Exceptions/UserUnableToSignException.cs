using System;
using System.Collections.Generic;
using System.Text;

namespace UsersApi.Application.Exceptions
{
    public class UserUnableToSignException : Exception
    {
        public UserUnableToSignException(string userName) : base($"Username or password is incorrect. UserName : {userName}")
        {

        }
    }
}
