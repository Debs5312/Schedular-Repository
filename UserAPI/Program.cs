using Microsoft.EntityFrameworkCore;
using UserAPI.DBConnections;
using UserAPI.Repository;
using UserAPI.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Register Mongo as a scoped service
builder.Services.AddDbContext<UserDBContext>(options => 
{
    options.UseMongoDB(builder.Configuration.GetConnectionString("DBConn"), "schedularDB");
});
builder.Services.AddScoped<IUserRepo, UserRepo>();

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


// Setting up middleware pipeline for http request-response mapping.

var app = builder.Build();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

