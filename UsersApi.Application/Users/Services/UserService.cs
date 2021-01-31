using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UsersApi.Application.Exceptions;
using UsersApi.Application.Users.Interfaces;
using UsersApi.Application.Users.Models;
using UsersApi.Domain.Entities.UserAggregate;

namespace UsersApi.Application.Users.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task CreateUser(CreateUserRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null)
            {
                throw new UserAlreadyExistsException(request.UserName);
            }

            var result = await _userManager.CreateAsync(new User(request.UserName,
                                                                request.Email,
                                                                request.PersonalId,
                                                                request.PhoneNumber,
                                                                request.Address == null ? null : 
                                                                new Address(request.Address.Street,
                                                                             request.Address.City,
                                                                            request.Address.Country),
                                                                request.Married,
                                                                request.HasJob,
                                                                request.MonthlySalary),
                                                                request.Password);

            if (!result.Succeeded)
            {
               
            }
        }

        public async Task SignIn(SignInUserRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if(user == null)
            {
                throw new UserNotFoundException(request.UserName);
            }
            var res = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);
            if (!res.Succeeded)
            {
                throw new UserUnableToSignException(request.UserName);
            }
        }

        public async Task DeleteUser(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                throw new UserNotFoundException(userName);
            }
            var res = await _userManager.DeleteAsync(user);
            if (!res.Succeeded)
            {
                throw new UserUnableToSignException(userName);
            }
        }

        public async Task UpdateUser(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                throw new UserNotFoundException(userName);
            }
            var res = await _userManager.UpdateAsync(user);
            if (!res.Succeeded)
            {
                throw new UserUnableToSignException(userName);
            }
        }
    }
}
