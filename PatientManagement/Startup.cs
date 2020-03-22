using Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Services;
using System;

namespace PatientManagement
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            CurrentEnvironment = env;
        }

        public IConfiguration Configuration { get; }

        private IWebHostEnvironment CurrentEnvironment { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            if (!CurrentEnvironment.IsDevelopment())
            {
                services.AddSpaStaticFiles(configuration =>
                {
                    configuration.RootPath = "ClientApp/dist";
                });
            }

            services.AddDbContext<PatientDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")), 
                ServiceLifetime.Transient);

            services.AddScoped<IPatientService, PatientService>();
            //services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            DatabaseMigrate(app);

            app.UseHttpsRedirection();
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
                    //spa.UseProxyToSpaDevelopmentServer("http://localhost:64586");
                }
            });
        }

        /// <summary>
        /// deployment pipeline should include dotnet ef database update
        /// Startup includes Database.Migrate() Just in case if deployment step failed.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="loggerFactory"></param>
        private static void DatabaseMigrate(IApplicationBuilder app/*, ILoggerFactory loggerFactory*/)
        {
            try
            {
                //https://stackoverflow.com/questions/42355481/auto-create-database-in-entity-framework-core
                using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
                {
                    using (var context = serviceScope.ServiceProvider.GetRequiredService<PatientDbContext>())
                    {
                        //context.ConfigureLogging(DbContextExtensions.SqlTrace);
#if DEBUG
                        context.Database.SetCommandTimeout(600 * 60);//600=10 min
#endif
                        context.Database.Migrate();
                    }
                }
            }
            catch (Exception e)
            {
                // TODO: log exception properly
                //var logger = loggerFactory.CreateLogger(nameof(Startup));
                //logger.LogWarning(e, "DatabaseMigrate failed");
            }
        }
    }
}
