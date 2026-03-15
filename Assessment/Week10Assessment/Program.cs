using Microsoft.EntityFrameworkCore;
using Week10Assessment.Data;
using DotNetEnv;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Fetch the string from Environment Variables instead of appsettings.json
var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AccountContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Index}/{id?}");

app.Run();