global using OptiLoan.Models;
global using System.Net;
global using OptiLoan.Utils;
global using Microsoft.EntityFrameworkCore;
global using OptiLoan.Data;
global using Microsoft.AspNetCore.Mvc;
global using OptiLoan.Services;
global using System.ComponentModel.DataAnnotations;
global using System.Text.RegularExpressions;
global using OptiLoan.Services.Implementation;
global using System.Security.Claims;
global using Microsoft.IdentityModel.Tokens;
global using OptiLoan.enums;
global using OptiLoan.Dtos;
global using AutoMapper;
global using System.Text.Json.Serialization;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.OpenApi.Models;
global using Swashbuckle.AspNetCore.Filters;
global using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddSwaggerGen(c => {
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme {
        Description = """Standard Authorization header using bearer scheme. Example: bearer {token}""",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<AuthService, AuthImpl>();
builder.Services.AddScoped<OrganisationService, OrganizationImpl>();
builder.Services.AddScoped<MasterAgentService, MasterAgentImpl>();
builder.Services.AddScoped<StaffService, StaffImpl>();
builder.Services.AddScoped<SuperAgentService, SuperAgentImpl>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    options => {
        options.TokenValidationParameters = new TokenValidationParameters{
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSetting:Token").Value!)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    }
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
