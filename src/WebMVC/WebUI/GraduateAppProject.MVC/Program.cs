using GraduateAppProject.WebMVC.Repositories;
using GraduateAppProject.WebMVC.Services.Mapping;
using GraduateAppProject.WebMVC.Services;
using GraduateAppProject.WebMVC.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using GraduateAppProject.MVC.Extensions;
using GraduateAppProject.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddHttpClient();



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
{
    opt.Cookie.Name = "NetCoreMvc.Auth";  // Sets the name of the cookie used for authentication
    opt.LoginPath = "/Home/Login";  // Sets the path for the login page
    opt.AccessDeniedPath = "/Home/AccessDeniedPage";  // Sets the path for the access denied page
});

builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(15);  // Sets the idle timeout duration for sessions
});


var connectionString = builder.Configuration.GetConnectionString("Database");

builder.Services.AddInjections(connectionString);

builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<GraduateAppDbContext>();
var configuration = services.GetRequiredService<IConfiguration>();
context.Database.EnsureCreated();
DbSeeding.SeedDatabase(context, configuration);

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
