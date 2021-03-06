using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using BusinessLogic.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RazorPages
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IConfigurationService, ConfigurationService>();
            services.AddBusinessLogicServices();
            services.AddRazorPages()
                    .AddRazorPagesOptions(options =>
                                          {
                                              options.Conventions.AddPageRoute("/Order/Detail", "/Order/Detail/{Id}");
                                              options.Conventions.AddPageRoute("/Order/Edit", "/Order/Edit/{Id}");
                                          });
            services.AddControllers();

            // 防止 CSRF 攻擊
            // services.AddAntiforgery();
        }

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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
                             {
                                 endpoints.MapRazorPages();
                                 endpoints.MapControllers();
                             });
        }
    }
}
