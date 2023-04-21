using EmployeeManagementAPI.Data;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using System;
using EmployeeManagementAPI.Fluent_Validation;
using EmployeeManagementAPI.Model;
using EmployeeManagementAPI.Behaviour;
using EmployeeManagementAPI.ExceptionHandling;
using Microsoft.Extensions.DependencyInjection;
using EmployeeManagementAPI.ErrorManagement;
using Serilog;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using EmployeeManagementAPI.LogError;
using NLog;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

//DataBase Configuration
builder.Services.AddDbContext<DataDbContext>(options=>options.UseSqlServer
(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<DataDbContext,DataDbContext>();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// Add services to the container.


builder.Services.AddControllers();

builder.Services.AddValidatorsFromAssembly(typeof(DataDbContext).Assembly);
builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

//Configuration for Serilog
var logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext().CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Automatic registration of validators in assembly

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//SwaggerDocumentation Configuring
builder.Services.AddSwaggerGen(c => {
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});
builder.Services.AddApiVersioningConfigured();
var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    var descriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    app.UseSwaggerUI(options =>
    {
        // Build a swagger endpoint for each discovered API version
        foreach (var description in descriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
    });
   
}
app.AddGlobalErrorHandler();

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
