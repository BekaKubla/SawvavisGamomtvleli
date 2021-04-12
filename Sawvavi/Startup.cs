using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FuelProject.Data;
using FuelProject.Repositories;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FuelProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddRazorPages()
                .AddMvcOptions(options =>
                {
                    options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
                        _ => "ველის შევსება აუცილებელია");
                });
            services.AddDbContext<AppDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("FuelProject")));
            services.AddTransient<IFuel, Fuel>();
            services.AddHangfire(config =>
            config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseDefaultTypeSerializer()
            .UseMemoryStorage());
            services.AddHangfireServer();
            services.AddTransient<ITestJob, TestJob>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env , IBackgroundJobClient backgroundJobClient,IRecurringJobManager recurringJobManager,IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Scraping}/{action=Index}");
            });
            app.UseHangfireDashboard();
            backgroundJobClient.Enqueue(() => Console.WriteLine("Hello hangfire job"));
            recurringJobManager.AddOrUpdate("Run every minute", () => serviceProvider.GetService<ITestJob>().Job(), Cron.Minutely);

        }
    }
}
