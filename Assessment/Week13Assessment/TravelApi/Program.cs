using Microsoft.EntityFrameworkCore;
using TravelApi.Data;
using DotNetEnv;
using TravelApi.Repository;
using TravelApi.Services;

var builder = WebApplication.CreateBuilder(args);
Env.Load();
var connString = Environment.GetEnvironmentVariable("SCAFFOLD_CONN_STR");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connString));

builder.Services.AddScoped<IDestinationRepository, DestinationRepository>();
builder.Services.AddScoped<IDestinationService, DestinationService>();

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();

app.Run();