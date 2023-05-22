using Microsoft.EntityFrameworkCore;
using RampfyWebApi.Application.Interfaces;
using RampfyWebApi.Application;
using RampfyWebApi.Domain.Interfaces.Repositories;
using RampfyWebApi.Domain.Interfaces.Services;
using RampfyWebApi.Domain.Services;
using RampfyWebApi.Infra.Data.Context;
using RampfyWebApi.Infra.Data.Repositories;
using RampfyWebApi.Application.Helpers;
using RampfyWebApi.Application.Jwt;
using Microsoft.OpenApi.Models;
using RampfyWebApi.Application.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Rampfy", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."

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

builder.Services.AddDbContext<RampfyContext>(option =>
    option.UseMySQL(builder.Configuration.GetConnectionString("RampfyWebApi")));

// configure strongly typed settings object
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// configure DI for application services
builder.Services.AddScoped<IJwtUtils, JwtUtils>();

// Add a custom scoped service.
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IVendaService, VendaService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IVendaRepository, VendaRepository>();
builder.Services.AddScoped<IUsuarioAppService, UsuarioAppService>();
builder.Services.AddScoped<IVendaAppService, VendaAppService>();

AutoMapperConfig.RegisterMappings();
builder.Services.AddSingleton(AutoMapperConfig.Mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// global cors policy
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

// custom jwt auth middleware
app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();
