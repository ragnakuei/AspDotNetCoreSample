using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AngularWithAspNetCoreWebApiDemo
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
            AddBusinessLogicServices(services);
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
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
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
        
        public static void AddBusinessLogicServices(IServiceCollection services)
        {
            var serviceTypes = Assembly.Load("BusinessLogic")
                                       .GetTypes()
                                       .Where(i => i.Name.EndsWith("Service", StringComparison.OrdinalIgnoreCase))
                                       .ToArray();

            foreach (var interfaceType in serviceTypes.Where(t => t?.IsInterface ?? false))
            {
                var implementClassType = serviceTypes.FirstOrDefault(t => t.IsInterface == false
                                                                       && interfaceType.IsAssignableFrom(t)
                                                                       && !t.IsInterface && !t.IsAbstract);
                if (implementClassType != null)
                {
                    typeof(ServiceCollectionServiceExtensions)
                       .GetMethods()
                       .FirstOrDefault(m => m.Name.Equals("AddTransient", StringComparison.CurrentCultureIgnoreCase)
                                         && m.IsGenericMethod
                                         && m.GetParameters().Length == 1)
                      ?.MakeGenericMethod(interfaceType, implementClassType)
                       .Invoke(null, new object[] { services });
                }
            }
        }
    }
}
