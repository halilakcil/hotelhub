using HealthChecks.UI.Client;
using System.ServiceProcess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHealthChecks()
  .AddSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=HotelHubDb;Trusted_Connection=true") // Your database connection string
  .AddDiskStorageHealthCheck(s => s.AddDrive("C:\\", 1024)) // 1024 MB (1 GB) free minimum
  .AddProcessAllocatedMemoryHealthCheck(512) // 512 MB max allocated memory
  .AddProcessHealthCheck("ProcessName", p => p.Length > 0) // check if process is running
  //.AddWindowsServiceHealthCheck("someservice", s => s.Status == ServiceControllerStatus.Running)
  .AddUrlGroup(new Uri("https://localhost:7018/weatherforecast"), "Example endpoint");

builder.Services.AddHealthChecksUI(s =>
{
    s.AddHealthCheckEndpoint("endpoint1", "https://localhost:7018/health");
}).AddInMemoryStorage();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHealthChecksUI();

app.MapHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.Run();
