using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerOverflow.Data;
using BeerOverflow.Services;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.Providers;
using BeerOverflow.Services.Providers.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BeerOverflow
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
            services.AddDbContext<BeerOverflowContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddScoped<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IBreweryService, BreweryService>();
            services.AddScoped<IBeerTypeService, BeerTypesService>();
            services.AddScoped<IBeerService, BeerService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserBeersService, UserBeersService>();
            services.AddScoped<IReviewService, ReviewService>();
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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
