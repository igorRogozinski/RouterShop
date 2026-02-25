using RouterShop.Repositories.Abstractions;
using RouterShop.Repositories.Interfaces;
using RouterShop.Services.Abstractions;
using RouterShop.Services.Interfaces;

namespace RouterShop
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            return services;
        }
    }
}
