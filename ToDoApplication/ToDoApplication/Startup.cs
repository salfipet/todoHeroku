using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApplication.Database;
using ToDoApplication.Services;

namespace ToDoApplication
{
    public class Startup
    {
        private IConfiguration AppConfig { get; }
        public Startup(IConfiguration config)
        {
            AppConfig = config; // nactu ten appsettings.json
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllersWithViews();
            services.AddTransient<TodoService>();
            services.AddTransient<AssigneeService>();
            ConfigureDb(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
          

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureDb(IServiceCollection services)
        {
            var connectionString = AppConfig.GetConnectionString("DefaultConnection"); //najdi sekci connecctionstring a vrat hodnotu s defaultConnection
            var serverVersion = new MySqlServerVersion(new Version(8, 0)); //infomuje o verzi sql

            services.AddDbContext<ApplicationDbContext>( //pridani jako DI
                options => options
                .UseMySql(connectionString, serverVersion) //pouzij mysql, kam posilat, verze
                // The following three options help with debugging
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors());
        }
    }
}
