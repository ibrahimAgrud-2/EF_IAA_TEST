using EF_InternApplicationAutomator.DataAccess;
using EF_InternApplicationAutomator.DataAccess.User;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//Connection String
builder.Services.AddDbContext<IAADbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//PersonData Access'e PL nas?l eri?ebiliyor. Eri?memeli.
builder.Services.AddScoped<PersonDataAccess>();
builder.Services.AddScoped<EF_InternApplicationAutomator.Business.PersonBL>();


builder.Services.AddScoped<EF_InternApplicationAutomator.DataAccess.User.UserDataAccess>();
builder.Services.AddScoped<EF_InternApplicationAutomator.Business.User.UserBL>();

builder.Services.AddScoped<EF_InternApplicationAutomator.DataAccess.Application.ApplicationDataAccess>();
builder.Services.AddScoped<EF_InternApplicationAutomator.Business.Application.ApplicationBL>();

builder.Services.AddScoped<EF_InternApplicationAutomator.DataAccess.Intern.InternDataAccess>();
builder.Services.AddScoped<EF_InternApplicationAutomator.Business.Intern.InternBL>();

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
