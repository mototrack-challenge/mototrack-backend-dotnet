using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
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

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MotoTrack API", Version = "v1" });

    // Mostra os nomes dos enums como strings (ex: Aberta, EmAndamento)
    c.UseInlineDefinitionsForEnums(); // Para Swagger v6+
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
