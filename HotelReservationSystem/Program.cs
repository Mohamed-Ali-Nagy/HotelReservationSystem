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
using HotelReservationSystem.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Autofac.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

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
builder.Services.AddAuthentication(opts =>
{
    opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opts =>
{
    opts.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "UpSkilling",
        ValidAudience = "UpSkilling-Users",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Constants.SecretKey))
    };
});
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddAuthentication();
var app = builder.Build();
//app.UseAuthentication();
//app.UseAuthorization();
MappHelper.Mapper = app.Services.GetService<IMapper>();
app.UseMiddleware<GlobalErrorHandlerMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
