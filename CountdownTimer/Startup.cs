using CountdownTimer.DataAccessLayer.Implemetation;
using CountdownTimer.DataAccessLayer.Interface;
using CountdownTimer.Entities;
using CountdownTimer.ServiceProviders.Implemetations;
using CountdownTimer.ServiceProviders.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace CountdownTimer
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
            services.AddScoped<IFlowObjectForHomePage, FlowObjectForHomePage>();
            services.AddScoped<IRemindersRepo, RemindersRepo>();

            services.AddDbContext<PluralsightProjectsDBContext>(
                options => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=PluralsightProjectsDB;Integrated Security = True"));
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Timer}/{id?}");
            });
            app.UseStaticFiles(new StaticFileOptions()
            {
                // Where the files are physicly located
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Scripts")),
                // What relative url to serve the files from
                RequestPath = new PathString("/scripts")
            });
        }
    }
}
