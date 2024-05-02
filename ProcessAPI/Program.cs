using ProcessAPI.DBConnections;
using ProcessAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Register Mongo as a scoped service

builder.Services.Configure<MongoDBSetting>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddScoped<IProcessRepo, ProcessRepo>();

// Setting up middleware pipeline for http request-response mapping.

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
