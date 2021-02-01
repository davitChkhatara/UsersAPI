using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UsersApi.Application.Users.Models;

namespace UsersApi.Application.Users.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(CreateUserRequest request);
        Task SignIn(SignInUserRequest request);
        Task DeleteUser(string userName);
        Task UpdateUser(UpdateUserRequest request);
    }
}
