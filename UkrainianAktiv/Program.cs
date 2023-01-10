using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using UkrainianAktiv;
using UkrainianAktiv.Core.Models;
using UkrainianAktiv.Interfaces;
using UkrainianAktiv.Services;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllersWithViews();
builder.Services.AddMvc();

builder.Services.AddAutoMapper(typeof(Startup));
builder.Services.AddTransient<DataSeeder>();
builder.Services.AddScoped<SignInManager<ApplicationUser>>();
builder.Services.AddScoped<ClubService>();
builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<IClubService, ClubService>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddEntityFrameworkSqlite().AddDbContext<DataContext>();
builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>().AddEntityFrameworkStores<DataContext>();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();


var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

host.Run();


app.Run();
