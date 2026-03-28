using WalletManager.CrossCutting.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApiSpecification()
    .AddControllers();

var app = builder.Build();

app.MapOpenApi();
app.UseSpecification();

app.UseHttpsRedirection()
    .UseAuthorization();

app.MapControllers();

await app.RunAsync();