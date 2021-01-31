using System;
using System.Collections.Generic;
using System.Text;

namespace UsersApi.Application.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string userName) : base($"User not found. UserName : {userName}")
        {

        }
    }
}
