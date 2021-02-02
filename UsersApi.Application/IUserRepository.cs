using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UsersApi.Application.Users.Models;
using UsersApi.Domain.Entities.UserAggregate;

namespace UsersApi.Application
{
    public interface IUserRepository
    {
        Task<User> GetUserByUserName(string userName);
        Task<User> GetUserById(string userId);
        Task DeleteAddress(Address address);
        Task<bool> ValidateUserCreate(CreateUserRequest request);
    }
}
