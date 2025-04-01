using System.Data;
using Application.Mappers;
using Data.Dapper.Extensions;
using Data.Mappers;
using Data.Repositories;
using Domain.Factories;
using Domain.Services;
using Domain.Validation;
using Npgsql;
using ZiggyCreatures.Caching.Fusion;
using ZiggyCreatures.Caching.Fusion.NullObjects;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddControllers();

builder.Services.RegisterApplicationServices();
builder.Services.RegisterRepositories();
builder.Services.RegisterDatabaseExtensions();
builder.Services.RegisterApplicationValidationServices();
builder.Services.RegisterApplicationMappers();
builder.Services.RegisterDataLayerMappers();
builder.Services.RegisterDomainFactories();

var cachingOptions = builder.Configuration.GetSection("Caching");

if (!cachingOptions.GetValue<bool>("UseCaching"))
{
    builder.Services.AddFusionCache(new NullFusionCache(new FusionCacheOptions())); // this is a null cache, will not cache
}

var connectionString = builder.Configuration.GetConnectionString("Database");
builder.Services.AddTransient<IDbConnection>(_ => new NpgsqlConnection(connectionString));

builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();