using Kirilanatur.Server.Database;
using Kirilanatur.Server.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
    });
    
    options.OperationFilter<SecurityRequirementsOperationFilter>(); 
});

builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<KirilanaturUser>()
    .AddEntityFrameworkStores<KirilanaturDbContext>();

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
app.MapIdentityApi<KirilanaturUser>();
app.UseCors("AllowAllOrigins");
app.MapControllers();
app.MapFallbackToFile("/index.html");
app.Run();
