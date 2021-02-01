using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UsersApi.Application;
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
                            .SingleAsync(x => x.UserName.Equals(userName));

            return user;
        }

    }
}
