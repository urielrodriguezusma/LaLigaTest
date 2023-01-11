using LaLiga.Application;
using LaLiga.Application.Contracts;
using LaLiga.Application.Services;
using LaLiga.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ICatalogService, CatalogService>();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
