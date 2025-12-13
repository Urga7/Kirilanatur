using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Kirilanatur.Infrastructure.Endpoints;
using Kirilanatur.Setup;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpoints();

builder.Configuration.AddAzureKeyVault(
new Uri(builder.Configuration["KeyVault:VaultUri"]!),
new DefaultAzureCredential());

builder.SetupStripe();

const string corsPolicy = "CorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicy, corsPolicyBuilder =>
    {
        corsPolicyBuilder.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.MapOpenApi();
    app.MapScalarApiReference(options => 
    {
        options
        .WithTitle("Kirilanatur API")
        .WithTheme(ScalarTheme.Moon)
        .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });
}

app.UseCors(corsPolicy);
app.UseHttpsRedirection();
app.MapGet("secrets", async (IConfiguration configuration) =>
{
    var secretsClient = new SecretClient(
    new Uri(configuration["KeyVault:VaultUri"]!),
    new DefaultAzureCredential());
    
    var response = await secretsClient.GetSecretAsync("stripe-secret-key");
    return Results.Ok(response.Value);
});

app.UseAuthorization();
app.MapControllers();
app.MapEndpoints();
app.Run();
