using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UsersApi.Application;
using UsersApi.Application.Users.Models;
using UsersApi.Domain.Entities.UserAggregate;

namespace UsersApi.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<User> _userManager;

        public UserRepository(ApplicationDbContext applicationDbContext, UserManager<User> userManager)
        {
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
        }

        public async Task<User> GetUserByUserName(string userName)
        {
            var user = await _userManager.Users
                            .Include(x => x.Address)
                            .FirstOrDefaultAsync(x => x.UserName.Equals(userName));

            return user;
        }

        public async Task DeleteAddress(Address address)
        {
             _applicationDbContext.Address.Remove(address);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserById(string userId)
        {
            var user = await _userManager.Users
                           .Include(x => x.Address)
                           .FirstOrDefaultAsync(x => x.Id.Equals(userId));

            return user;
        }

        public async Task<bool> ValidateUserCreate(CreateUserRequest request)
        {
            var userNameExists = await ExistsUserName(request.UserName);
            var emailExists = await ExistsEmail(request.Email);
            var personalIdExists = await ExistsPersonalId(request.PersonalId);

            return !userNameExists && !emailExists && !personalIdExists;
        }

        private async Task<bool> ExistsUserName(string userName)
        {
            return  await _userManager.Users
                            .AnyAsync(x => x.UserName.Equals(userName));
        }

        private async Task<bool> ExistsEmail(string email)
        {
            return await _userManager.Users
                            .AnyAsync(x => x.Email.Equals(email));
        }

        private async Task<bool> ExistsPersonalId(string personalId)
        {
            return await _userManager.Users
                            .AnyAsync(x => x.PersonalId.Equals(personalId));
        }
    }
}
