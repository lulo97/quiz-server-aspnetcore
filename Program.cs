/*
Create database using code first:
- Add Enitity Framework (Core, SQL Server, Design)

Generate controller by model:
- Install
    + Microsoft.VisualStudio.Web.CodeGeneration.Design
    + dotnet tool install -g dotnet-aspnet-codegenerator --version 7.0.1
- Run command: dotnet aspnet-codegenerator controller -name ControllerName -async -api -m ModelName -dc ApplicationDbContext -outDir Controllers
*/

using DotNetEnv;
using Backend.Data;
using Microsoft.EntityFrameworkCore;
using Backend;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure port
Env.Load(@"D:\TULAM\LinhTinh\QuizQuestAngularASP.NETCore\.env");
builder.WebHost.ConfigureKestrel(options => options.ListenLocalhost(Const.getPort()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.Run();
