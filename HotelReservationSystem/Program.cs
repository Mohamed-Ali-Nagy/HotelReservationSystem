using Autofac.Extensions.DependencyInjection;
using Autofac;
using Hotel;
using HotelReservationSystem.Profiles;
using HotelReservationSystem.Helpers;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using HotelReservationSystem.Data;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("Default")).
    LogTo(log => Debug.WriteLine(log), LogLevel.Information).
    EnableServiceProviderCaching();

});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
    builder.RegisterModule(new AutoFacModule()));


builder.Services.AddAutoMapper(typeof(RoomProfile));
builder.Services.AddAutoMapper(typeof(ReservationProfile));



var app = builder.Build();

MappHelper.Mapper = app.Services.GetService<IMapper>();

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
