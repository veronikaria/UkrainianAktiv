using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using UkrainianAktiv.Core.Models;
using UkrainianAktiv.Interfaces;
using Microsoft.Extensions.Logging;
using UkrainianAktiv.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using UkrainianAktiv.Models;

namespace UkrainianAktiv
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);
            //services.AddMvc();
            services.AddAutoMapper(typeof(Startup));
            services.AddTransient<DataSeeder>();
            services.AddScoped<SignInManager<ApplicationUser>>();
            services.AddScoped<ClubService>();
            //services.AddScoped<CourseService>();
            services.AddScoped<ICourseService, CourseService>();

            services.AddScoped<IClubService, ClubService>();
            services.AddScoped<IScheduleService, ScheduleService>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddEntityFrameworkSqlite().AddDbContext<DataContext>();
            services.AddIdentity<ApplicationUser, IdentityRole<Guid>> ().AddEntityFrameworkStores<DataContext>();

        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, DataSeeder seeder)
        {
            //loggerFactory.AddConsole(LogLevel.Information).AddDebug();

            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.UseStatusCodePagesWithRedirects("/error/{0}");
            app.ApplicationServices.GetService<DataContext>().Database.Migrate();
            seeder.Seed();

        }
    }
}
