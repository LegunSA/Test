using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Data.Interfaces;
using TestTask.Mapping;
using TestTask.Service;
using TestTask.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
 .AddNewtonsoftJson(options =>
        options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (Environment.GetEnvironmentVariable("ENVIRONMENT") is not null)
{
  string dbHost = Environment.GetEnvironmentVariable("DB_Host")!;
  string dbName = Environment.GetEnvironmentVariable("DB_Name")!;
  string dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD")!;
  string connectionString = $"server={dbHost};database={dbName};trusted_connection=false;User Id=sa;Password={dbPassword};Persist Security Info=False;Encrypt=False";
  builder.Services.AddDbContext<DemoDBContext>(options
    => options.UseSqlServer(connectionString));
}
else
{
  builder.Services.AddDbContext<DemoDBContext>(options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("Test")));
}

builder.Services.AddScoped<IRepository, Reposiory>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IPatientService, PatientService>();

var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

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
