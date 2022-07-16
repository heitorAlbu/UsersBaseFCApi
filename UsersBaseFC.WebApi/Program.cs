using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UsersBaseFC.Application.DTOs;
using UsersBaseFC.Application.Interfaces;
using UsersBaseFC.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EFContext>
        (option => option.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

builder.Services.AddTransient<IEFContext, EFContext>();


builder.Services.AddTransient<Response>();


var mapper = new MapperConfiguration(config =>
{
    config.AddMaps(typeof(Program).Assembly);
});

mapper.AssertConfigurationIsValid();
var map = mapper.CreateMapper();
builder.Services.AddSingleton(map);
var assembly = AppDomain.CurrentDomain.GetAssemblies();
builder.Services.AddMediatR(assembly);

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
