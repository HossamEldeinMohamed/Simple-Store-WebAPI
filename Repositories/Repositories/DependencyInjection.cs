using DataAccess.Data;
using DataAccess.Entities;
using Microsoft.Extensions.DependencyInjection;
using Repositories.InterfaceGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IOrderDetails, OrderDetailRepository>();
            services.AddTransient<IGenericRepository<Product>, ProductRepository>();
            services.AddTransient<IGenericRepository<Order>, OrderRepository>();
            return services;
        }
    }
}
