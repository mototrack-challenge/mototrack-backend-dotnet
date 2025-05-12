using System.Reflection;
using Microsoft.EntityFrameworkCore;
using mototrack_backend_dotnet.Application.Interfaces;
using mototrack_backend_dotnet.Application.Services;
using mototrack_backend_dotnet.Domain.Interfaces;
using mototrack_backend_dotnet.Infrastructure.AppData;
using mototrack_backend_dotnet.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationContext>(option => {
    option.UseOracle(builder.Configuration.GetConnectionString("Oracle"));
});

builder.Services.AddTransient<IOrdemServicoRepository, OrdemServicoRepository>();
builder.Services.AddTransient<IOrdemServicoApplicationService, OrdemServicoApplicationService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
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

app.Run();
