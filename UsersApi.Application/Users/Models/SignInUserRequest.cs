using System;
using System.Collections.Generic;
using System.Text;

namespace UsersApi.Application.Users.Models
{
    public class SignInUserRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
