using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using EmployeeManagement.Models;

namespace EmployeeManagement
{
    public class Startup
    {
        private IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });


            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapGet("/", async context =>
            //     {
            //         await context.Response
            //         .WriteAsync("");
            //     });
            // });

            // app.Run(async (context) =>{
            //     throw new Exception("Some error processing the request");
            //     await context.Response.WriteAsync("Hello world");
            // });



            // app.Use(async(context, next) =>
            // {
            //     logger.LogInformation("MW1: Incoming request");
            //     await next();
            //     logger.LogInformation("MW1: Outgoing response");
            // });
            // app.Use(async(context, next) =>
            // {
            //     logger.LogInformation("MW2: Incoming request");
            //     await next();
            //     logger.LogInformation("MW2: Outgoing response");
            // });
            // app.Use(async(context, next) =>
            // {
            //     await context.Response.WriteAsync("MW3: Request handled and response produced");
            //     logger.LogInformation("MW3: Outgoing response");
            // });

        }
    }
}
