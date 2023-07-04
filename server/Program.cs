using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

string cnnString = builder.Configuration.GetConnectionString("Default")!;
builder.Services.AddDbContext<TaskifyContext>(options =>
{
  options.UseMySql(cnnString, ServerVersion.AutoDetect(cnnString));
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();