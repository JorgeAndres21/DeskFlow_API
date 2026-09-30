using DeskFlowApi;
using DeskFlowApi.Repositories;
using DeskFlowApi.Repositories.Interface;
using DeskFlowApi.Services;
using DeskFlowApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));

builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<ICategoriaServices, CategoriaServices>();

builder.Services.AddScoped<IChamadoRepository, ChamadosRepository>();
builder.Services.AddScoped<IChamadoServices, ChamadoServices>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(op =>
    {
        op.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

app.MapControllers();

app.Run();