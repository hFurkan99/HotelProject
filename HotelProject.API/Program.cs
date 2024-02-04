using System.ComponentModel.DataAnnotations;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
using HotelProject.API.Filters;
using HotelProject.API.Middlewares;
using HotelProject.Core.Repositories;
using HotelProject.Core.Services;
using HotelProject.Core.UnitOfWorks;
using HotelProject.Repository;
using HotelProject.Repository.Repositories;
using HotelProject.Repository.UnitOfWorks;
using HotelProject.Service.Mapping;
using HotelProject.Service.Services;
using HotelProject.Service.Validations;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.API.Modules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(option => option.Filters.Add(new ValidateFilterAttribute()));

//Fluent Validation
builder
    .Services
    .AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters()
    .AddValidatorsFromAssemblyContaining<RoomDtoValidator>();
builder
    .Services
    .Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

//Dependency Injections
builder.Services.AddScoped(typeof(NotFoundFilter<>));
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder
    .Host
    .ConfigureContainer<ContainerBuilder>(
        containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule())
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCustomException();
app.UseAuthorization();

app.MapControllers();

app.Run();
