/*
Create database using code first:
- Add Enitity Framework (Core, SQL Server, Design)

Generate controller by model:
- Install
    + Microsoft.VisualStudio.Web.CodeGeneration.Design
    + dotnet tool install -g dotnet-aspnet-codegenerator --version 7.0.1
- Run command: dotnet aspnet-codegenerator controller -name ControllerName -async -api -m ModelName -dc ApplicationDbContext -outDir Controllers
*/

using Backend.Data;
using Backend.Models;
using DotNetEnv;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using static Backend.Utils.Const;

var builder = WebApplication.CreateBuilder(args);

// Add services controller, json
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add identity
builder.Services.AddIdentity<User, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure port
Env.Load(builder.Configuration.GetValue<string>("EnvPath"));
builder.WebHost.ConfigureKestrel(options => options.ListenLocalhost(Int32.Parse(BACKEND_PORT)));

// Cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.SameSite = SameSiteMode.None;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

//Login --> Create cookie to client
//Get current user id --> User.FindFirstValue(ClaimTypes.NameIdentifier)
//Requirement:
// Client: Every http request must have credential true ( { withCredentials: true } for Angular )
// Server: Allow credential to client address ( AllowCredentials() )
app.UseCors(x => x
    .SetIsOriginAllowed(origin => true) //Allow any origin can set credential 
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials());

app.Run();
