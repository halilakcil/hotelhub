using Autofac;
using Autofac.Extensions.DependencyInjection;
using Hotel.Business.DependencyResolvers.Autofac;
using Hotel.Core.DependencyResolvers;
using Hotel.Core.Extensions;
using Hotel.Core.Utilities.IoC;
using Hotel.Core.Utilities.Security.Encryption;
using Hotel.Core.Utilities.Security.JWT;
using Hotel.Entites.Maps;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHealthChecks().AddSqlServer(
    @"Server=(localdb)\MSSQLLocalDB;Database=HotelHubDb;Trusted_Connection=true",
    "SELECT 1;",
    $"Sql => {@"Server=(localdb)\MSSQLLocalDB;Database=HotelHubDb;Trusted_Connection=true".Split(";").First()}",
    HealthStatus.Degraded,
    timeout: TimeSpan.FromSeconds(30),
    tags: new[] { "db", "sql", "sqlServer", }
    );

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(c => c.AddProfile<ModelMapper>());
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());
    });
var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOption>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey),
    };
});
builder.Services.AddDependencyResolvers(new ICoreModule[] { new CoreModule(), });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureCustomExceptionMiddleware();
app.UseAuthentication();
app.UseAuthorization();

app.UseHealthChecks("/hc", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
{
    ResponseWriter = async (c, r) =>
    {
        c.Response.ContentType = "application/json";

        var result = JsonConvert.SerializeObject(new
        {
            status = r.Status.ToString(),
            components = r.Entries.Select(e => new { key = e.Key, value = e.Value })
        });

        await c.Response.WriteAsync(result);
    }
});

app.MapControllers();

app.Run();
