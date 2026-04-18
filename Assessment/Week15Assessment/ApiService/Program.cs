using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using ApiService.Data;
using ApiService.Mapping;
using ApiService.Repositories;

var builder = WebApplication.CreateBuilder(args);

Env.Load();
var connString = Environment.GetEnvironmentVariable("SCAFFOLD_CONN_STR")
    ?? builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connString));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = "Week 15 Assessment – Northwind Catalog API",
        Version = "v1",
        Description = "Single unified API service for Categories and Products (DB First + Repository Pattern)"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Northwind Catalog API v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
