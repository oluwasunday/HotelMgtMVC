using HotelMgtServices.implementations;
using HotelMgtServices.interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HotelMgtMVC.extensions
{
    public static class ServicesExtension
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {

            // Add Repository Injections Here 
            services.AddSingleton<IHttpRequestFactory, HttpRequestFactory>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();


            // Add Fluent Validator Injections Here
            //services.AddTransient<IValidator<RegisterDto>, RegisterDtoValidator>();

        }
    }
}
