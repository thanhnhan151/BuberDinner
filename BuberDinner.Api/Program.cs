using BuberDinner.Api;
using BuberDinner.Api.Startups;
using BuberDinner.Application;
using BuberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddPresentation();

var app = builder.Build();

app.ConfigureSwagger();

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

