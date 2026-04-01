using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using weeek10.Data;

var builder = WebApplication.CreateBuilder(args);
Env.Load();
var connString = Environment.GetEnvironmentVariable("SCAFFOLD_CONN_STR");
builder.Services.AddDbContext<FinDbContext>(options => options.UseSqlServer(connString));
// Add services to the container.
builder.Services.AddControllersWithViews();
var app = builder.Build();
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
app.MapControllerRoute(name: "default", pattern: "{controller=Accounts}/{action=Index}/{id?}");
app.Run();