using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudyingOnline.Helpers;
using StudyingOnline.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
if (builder.Environment.IsDevelopment())
{

    builder.Services.AddDbContext<StudyingOnlineContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("StudyingOnlineContext")));
}
else
{
    builder.Services.AddDbContext<StudyingOnlineContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("StudyingOnlineContext")));
}

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllersWithViews();

//authentication with cookies
builder.Services.AddAuthentication("CookieAuth")
.AddCookie("CookieAuth", config =>
{
    config.Cookie.Name = "Auth.Cookie";
    config.LoginPath = "/User/Login";
    config.AccessDeniedPath = "/User/Denied";
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdmin", policy => policy.RequireClaim(CustomClaimTypes.Admin, "1"));
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
