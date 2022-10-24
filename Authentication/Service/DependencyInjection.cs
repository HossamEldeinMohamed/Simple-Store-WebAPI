using DataAccess.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Simple_Store.Auth.IService;
using Simple_Store.Simple_Store.Auth.IService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAuthentecationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuth, AuthService>();
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
            }
           ).AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }
    }
}
