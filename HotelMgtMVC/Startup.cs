using HotelMgtMVC.extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelMgtMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddHttpContextAccessor(); // configure httpcontext to be accessible in other class
            services.AddHttpClient(); // configure httpclient for request to apis
            services.AddDistributedMemoryCache();
            services.AddSession(o => 
                {
                    o.IdleTimeout = TimeSpan.FromSeconds(1800);
                });

            // add dependecy injection
            services.AddDependencyInjection();


            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings  
                options.LoginPath = "/Authentication/Login";
                options.Cookie.Name = "HotelUser";
                options.Cookie.HttpOnly = true;
                options.LogoutPath = "/Authentication/Logout";
                options.AccessDeniedPath = "/Authentication/AccessDenied";
                //options.SlidingExpiration = true;
                options.ReturnUrlParameter = "/Home/Index";
                options.Cookie.Expiration = TimeSpan.FromDays(1);
                options.ExpireTimeSpan = TimeSpan.FromDays(1);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
