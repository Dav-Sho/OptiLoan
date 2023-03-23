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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<AuthService, AuthImpl>();
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
