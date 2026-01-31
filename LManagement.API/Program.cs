using LManagement.API.Configuration;
using LManagement.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Configure services using extension methods
builder.Services.ConfigureValidationBehavior();
builder.Services.ConfigureSwagger();
builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.ConfigureDependencyInjection();
builder.Services.ConfigureCors();

// Logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Information);

var app = builder.Build();

// Apply migrations
app.ApplyMigrations();

// Configure middleware pipeline
app.UseSwaggerConfiguration();
app.ConfigureExceptionHandler();
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();
