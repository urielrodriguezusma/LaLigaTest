using Catalog.Api.Middleware;
using Catalog.Api.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using LaLiga.Application;
using LaLiga.Application.Contracts;
using LaLiga.Application.Services;
using LaLiga.Infrastructure;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.Configure<ApiBehaviorOptions>(opt =>
{
    opt.InvalidModelStateResponseFactory = actionContext =>
    {
        var errors = actionContext.ModelState.Where(d => d.Value.Errors.Count > 0)
                                             .SelectMany(d => d.Value.Errors)
                                             .Select(d => d.ErrorMessage).ToList();

        return new BadRequestObjectResult(errors);
    };
});

builder.Services.AddScoped<ICatalogService, CatalogService>();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<ProductToCreateValidator>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.

app.UseStatusCodePagesWithReExecute("/error/{0}");
app.UseAuthorization();

app.MapControllers();

app.Run();
