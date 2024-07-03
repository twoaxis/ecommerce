using API.EmailSetting;
using Core.Interfaces.EmailSetting;
using Core.Interfaces.Services;
using Service;

namespace API.ServicesExtension
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // --- Bad Way To Register Dependancy Injection Of Generic Repositories
            //builder.Services.AddScoped<IGenericRepositories<Product>, GenericRepositories<Product>>();
            //builder.Services.AddScoped<IGenericRepositories<ProductBrand>, GenericRepositories<ProductBrand>>();
            //builder.Services.AddScoped<IGenericRepositories<ProductCategory>, GenericRepositories<ProductCategory>>();
            // --- Right Way To Register Dependancy Injection Of Generic Repositories
            //services.AddScoped(typeof(IGenericRepositories<>), typeof(GenericRepositories<>));
            // --- but I commented this line because i used unit-of-work then
            // --- I at all time create instance in unit-of-work then instead of dependency injection

            // Register AuthService
            services.AddScoped(typeof(IAuthService), typeof(AuthService));

            services.AddTransient(typeof(IEmailSettings), typeof(EmailSettings));

            return services;
        }
    }
}