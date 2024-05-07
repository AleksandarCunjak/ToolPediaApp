using Autofac;
using Autofac.Extensions.DependencyInjection;
using ToolPedia.Api;
using ToolPedia.Api.Middleware;
using ToolPedia.Application;
using ToolPedia.Infrastructure;
using ToolPedia.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);

builder.Services.AddApiServices(configuration);
builder.Services.AddInfrastructureServices(configuration);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new ApplicationModule());
});

var app = builder.Build();

MigrationUtil.MigrateDatabase(app.Services);

if (builder.Configuration.GetValue("EnableSwagger", false))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
