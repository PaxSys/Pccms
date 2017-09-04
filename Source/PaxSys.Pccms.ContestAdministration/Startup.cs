using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PaxSys.Pccms.DataAccess.LiteDb;
using PaxSys.Pccms.DataAccess.Sql.Contexts;
using PaxSys.Pccms.DataAccess.Sql.Repositories;
using PaxSys.Pccms.Domain;

namespace PaxSys.Pccms.ContestAdministration
{
    public class Startup
    {   
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
                        
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddSingleton(Configuration);

            if (Configuration["DatabaseType"] == "litedb".ToLower() && Configuration["LiteDbDatabaseDirectoryPath"] != null)
            {
                services.AddSingleton<IContestRepository, LiteDbContestRepository>(x => new LiteDbContestRepository(Configuration["LiteDbDatabaseDirectoryPath"]));
            }
            else
            {
                services.AddSingleton<ContestAdministrationContext>();
                services.AddSingleton<IContestRepository, ContestRepository>();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

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
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}