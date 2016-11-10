using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Rentals.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Rentals.Data;

namespace Rentals
{
    public class Startup
    {
        private IHostingEnvironment _env;
        private IConfigurationRoot _config;

        public Startup(IHostingEnvironment env)
        {
            _env = env;
            var builder = new ConfigurationBuilder()
                            .SetBasePath(_env.ContentRootPath)
                            .AddJsonFile("appsettings.json");

            _config = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_config);
            services.AddIdentity<RentalUser, IdentityRole>()
                .AddEntityFrameworkStores<RentalContext>();

            services.AddDbContext<RentalContext>();

            services.AddTransient<RentalContextSeedData>();

            services.AddMvc();

            services.AddLogging();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env, 
            ILoggerFactory loggerFactory,
            RentalContextSeedData rentalContextSeedData)
        {

            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                loggerFactory.AddDebug(LogLevel.Information);
            }
                        
            app.UseStaticFiles();
            app.UseIdentity();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );

            });

            rentalContextSeedData.EnsureSeedDataAsync().Wait();


            app.Run(async (context) =>
            {
               // throw new Exception("test Exception");
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
