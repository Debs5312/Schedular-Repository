using ProcessAPI.DBConnections;
using ProcessAPI.Repository;
using ProcessAPI.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Register Mongo as a scoped service

builder.Services.Configure<MongoDBSetting>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddScoped<IProcessRepo, ProcessRepo>();

// Register Automapper as service

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// Register CQRS Policy

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:5173");
    });
});

// Register AutoMapper service

builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Setting up middleware pipeline for http request-response mapping.

var app = builder.Build();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
