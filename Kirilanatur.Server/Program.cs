using Kirilanatur.Server.Database;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<KirilanaturDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options => {
    //TODO: Configure more strictly for production
    options.AddPolicy("AllowAllOrigins",
    policyBuilder => policyBuilder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
});

WebApplication app = builder.Build();

using(IServiceScope scope = app.Services.CreateScope()) {
    IServiceProvider services = scope.ServiceProvider;
    // var dbContext = services.GetRequiredService<KirilanaturDbContext>();
    // DatabaseHelpers.ClearTables(dbContext);
    DatabaseHelpers.Initialise(services);
}

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAllOrigins");
app.MapControllers();
app.MapFallbackToFile("/index.html");
app.Run();
