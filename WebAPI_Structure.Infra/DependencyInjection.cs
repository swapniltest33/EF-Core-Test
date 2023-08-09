using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAPI_Structure.Core.Models;
using WebAPI_Structure.Infra;
using WebAPI_Structure.Infra.Services.Generic;
using WebAPI_Structure.Infra.Services.Products;
using WebAPI_Structure.Infra.Services.UserAdmin;

namespace WebAPI_Structure.Infra
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddSqlServer<DemoDBContext>(Configuration.GetConnectionString("DefaultConnection"));
            services.AddTransient<IProductsServices, ProductsServices>();
            //services.AddTransient<ICategoryServices, CategoryServices>();
            services.AddTransient<IUserAdminServices, UserAdminServices>();
            services.AddTransient<IGenericRepository<Category>, GenericRepository<Category>>();
            return services;
        }
        public static IServiceCollection AddInfrastructure1(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddSqlServer<TestDBContext>(Configuration.GetConnectionString("DefaultConnection1"));
            //services.AddTransient<IProductsServices, ProductsServices>();
            services.AddTransient<ICategoryServices, CategoryServices>();
            //services.AddScoped<ICategoryRepository, CategoryRepository>();
            // services.AddTransient<IUserAdminServices, UserAdminServices>();
            return services;
        }

    }
}