using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args); // Create the WebApplicationBuilder

// Add services to the container.
builder.Services.AddControllers();

// Add CORS services and configure CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        policyBuilder => policyBuilder.WithOrigins("http://localhost:3000") // Allow requests only from localhost:3000
                                      .AllowAnyMethod()                    // Allow any HTTP method
                                      .AllowAnyHeader());                   // Allow any HTTP header
});

// Build the application
var app = builder.Build();

// Use CORS policy in the application pipeline
app.UseCors("AllowLocalhost");

// Use routing
app.UseRouting();

// Map controllers (API endpoints)
app.MapControllers();

// Run the application
app.Run();
