
using frogpay.api.rest.AutoMapper;
using frogpay.bootstrapper.Configurations.Auth;
using frogpay.bootstrapper.Configurations.AutoMapper;
using frogpay.bootstrapper.Configurations.Cors;
using frogpay.bootstrapper.Configurations.Injections;
using frogpay.bootstrapper.Configurations.Logger;
using frogpay.bootstrapper.Configurations.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;


var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var provider = services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Host.UseSerilog();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
services.AddAutoMapperConfiguration();
services.AddAutoMapperModelViewConfiguration();

AuthConfiguration.Register(services, configuration);
LoggerBuilder.ConfigureLogging();

services.AddProtectedControllers();
services.AddServices(configuration);
services.AddCors();
services.AddSwagger();
services.AddDatabaseConfiguration(configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCorsConfig();
app.UseAuthorization();
app.UseAuthentication();
app.UseRouting();
app.UseSwaggerConfig();
app.UseEndpointsConfig();
app.UseHttpsRedirection();

app.Run();