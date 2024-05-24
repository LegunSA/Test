using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Data.Interfaces;
using TestTask.Mapping;
using TestTask.Service;
using TestTask.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DemoDBContext>(options
  => options.UseSqlServer(builder.Configuration.GetConnectionString("Test")));

builder.Services.AddScoped<IRepository, Reposiory>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IPatientService, PatientService>();

var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
  var forecast = Enumerable.Range(1, 5).Select(index =>
      new WeatherForecast
      (
          DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
          Random.Shared.Next(-20, 55),
          summaries[Random.Shared.Next(summaries.Length)]
      ))
      .ToArray();
  return forecast;
});

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider;

  var context = services.GetRequiredService<DemoDBContext>();
  context.Database.EnsureCreated();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
  public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
