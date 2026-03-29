using WalletManager.CrossCutting.Extensions;

var builder = WebApplication.CreateBuilder(args);

var enviroment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{enviroment}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

var applicationSettings = builder.Configuration.GetApplicationSettings(builder.Environment);

builder.Services
    .AddDatabase(applicationSettings.PostgresSettings)
    .AddApiSpecification()
    .AddControllers();

var app = builder.Build();

app.MapOpenApi();
app.UseSpecification();

app.UseHttpsRedirection()
    .UseAuthorization();

app.MapControllers();

await app.RunAsync();