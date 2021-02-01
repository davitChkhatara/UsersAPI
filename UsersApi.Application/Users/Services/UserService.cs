using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApi.Application.Exceptions;
using UsersApi.Application.Extensions;
using UsersApi.Application.Users.Interfaces;
using UsersApi.Application.Users.Models;
using UsersApi.Domain.Entities.UserAggregate;

namespace UsersApi.Application.Users.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserRepository _userRepository;
        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IUserRepository userRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userRepository = userRepository;
        }

        public async Task<CreateUserResponse> CreateUser(CreateUserRequest request)
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
                throw new UserUnableToCreateException(request.UserName, result.Errors.GetErrorList());
            }
            var userSigned = await _userManager.FindByNameAsync(request.UserName);
            await _signInManager.SignInAsync(userSigned,false);
            return new CreateUserResponse
            {
                UserId = userSigned.Id
            };
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
            var user = await _userRepository.GetUserByUserName(userName);
            if (user == null)
            {
                throw new UserNotFoundException(userName);
            }
            var res = await _userManager.DeleteAsync(user);
            if (!res.Succeeded)
            {
                throw new UserUnableToDeleteException(userName, res.Errors.GetErrorList());
            }
            await _userRepository.DeleteAddress(user.Address);
        }

        public async Task UpdateUser(UpdateUserRequest request)
        {
            var user = await _userRepository.GetUserByUserName(request.UserName);
            if (user == null)
            {
                throw new UserNotFoundException(request.UserName);
            }

            user.UpdateUserInfo(request.Married, request.HasJob, request.MonthlySalary, request.PhoneNumber);
            if(request.Address != null)
            {
                user.UpdateUserAddress(request.Address.City, request.Address.Street, request.Address.Country);
            }
            var res = await _userManager.UpdateAsync(user);
            if (!res.Succeeded)
            {
                throw new UserUnableToUpdateException(request.UserName, res.Errors.GetErrorList());
            }
        }

        public async Task<User> GetUser(string userName)
        {
            var user = await _userRepository.GetUserByUserName(userName);
            if (user == null)
            {
                throw new UserNotFoundException(userName);
            }

            return user;
        }
    }
}
