using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Services;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using System;
using EmployeeManagementAPI.Fluent_Validation;
using EmployeeManagementAPI.Model;
using EmployeeManagementAPI.Behaviour;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataDbContext>(options=>options.UseSqlServer
(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// Add services to the container.


builder.Services.AddControllers();
//.AddFluentValidation(c =>
//c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddValidatorsFromAssembly(typeof(EmployeeRepository).Assembly);
builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));




// Automatic registration of validators in assembly



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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
