using BusinessLayer.IServices;
using DataAccess.Entities;
using Microsoft.Extensions.DependencyInjection;
using Repositories.InterfaceGeneric;


namespace BusinessLayer.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderDetailService, OrderDetailsService>();
            services.AddScoped<IOrder, OrderService>();
            services.AddScoped<IProduct, ProductService>();
            return services;
        }
    }
}
