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
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IRoomTypeService, RoomTypeService>();
            services.AddScoped<IRatingService, RatingService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IUserService, UserService>();


            // Add Fluent Validator Injections Here
            //services.AddTransient<IValidator<RegisterDto>, RegisterDtoValidator>();

        }
    }
}
