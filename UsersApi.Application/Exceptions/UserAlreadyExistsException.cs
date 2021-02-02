using System;
using System.Collections.Generic;
using System.Text;

namespace UsersApi.Application.Exceptions
{
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException(string userName) : base($"UserName ,Email or PersonalId already exists. UserName : {userName}.")
        {

        }
    }
}
