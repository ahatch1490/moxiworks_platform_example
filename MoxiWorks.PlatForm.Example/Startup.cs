using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoxiWorks.Platform;
using MoxiWorks.Platform.Interfaces;
using System.Configuration;
using Microsoft.AspNetCore.Razor.Language;

namespace MoxiWorksPlatForm.Example
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
            ConfigurationManager.AppSettings["Secret"] = Configuration["Secret"];
            ConfigurationManager.AppSettings["Identifier"] = Configuration["Identifier"];
            ConfigurationManager.AppSettings["MoxiWorksApiHost"] = Configuration["MoxiWorksApiHost"];
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
        
            services.AddSingleton<IMoxiWorksClient, MoxiWorksClient>();
            services.AddSingleton<IAgentService, AgentService>();
            services.AddSingleton<ICompanyService, CompanyService>();
            services.AddSingleton<IOfficeService, OfficeService>(); 
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Company}/{action=Index}/{id?}");
            });
        }
    }
}
