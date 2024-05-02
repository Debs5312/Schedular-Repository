var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Setting up middleware pipeline for http request-response mapping.

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
