using Kirilanatur.Server.Database;
using Kirilanatur.Server.Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);

builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<KirilanaturDbContext>()
    .AddApiEndpoints();

builder.Services.AddDbContext<KirilanaturDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options => {
    options.AddPolicy("AllowAllOrigins",
    policyBuilder => policyBuilder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
});

WebApplication app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
    // using IServiceScope scope = app.Services.CreateScope();
    // IServiceProvider services = scope.ServiceProvider;
    // var dbContext = services.GetRequiredService<KirilanaturDbContext>();
    // DatabaseHelpers.ClearTables(dbContext);
    // DatabaseHelpers.Initialise(services);
}

app.UseHttpsRedirection();
app.MapIdentityApi<User>();
app.UseCors("AllowAllOrigins");
app.MapControllers();
app.MapFallbackToFile("/index.html");
app.Run();
