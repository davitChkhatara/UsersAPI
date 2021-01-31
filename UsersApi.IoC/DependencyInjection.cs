using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using UsersApi.Domain.Entities.UserAggregate;
using UsersApi.Infrastructure;

namespace UsersApi.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<ApplicationDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("UserDbConnetion"), b => b.MigrationsAssembly("UsersApi")));
            //services.AddIdentity<User, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;


        }
    }
}
