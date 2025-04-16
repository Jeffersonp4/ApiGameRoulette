using AplicationServices.Services;
using RepositoryLayer.Configuration;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

// Add Infraestucture Configuration

builder.Services.AddDepencyInjection(builder.Configuration);

builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped<IBet, BetService>();


builder.Services.AddControllers();

builder.Configuration.AddJsonFile("appsettings.Production.json", optional: true);


// Configure the HTTP request pipeline.
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodo",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

// configuracion de railway

var port = Environment.GetEnvironmentVariable("PORT") ?? "8081";
builder.WebHost.UseUrls($"http://*:{port}");

var app = builder.Build();

app.UseCors("PermitirTodo");


//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
