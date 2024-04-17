using Microsoft.Extensions.DependencyInjection;
using ScaleControl.Application.Services.Implementations;
using ScaleControl.Application.Services.Interfaces;
using ScaleControl.Infraestructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ScaleControlDbContext>(); // Registre o ScaleControlDbContext como Singleton
builder.Services.AddScoped<IScaleService, ScaleService>();

var app = builder.Build();

// Configurar o pipeline de solicitação HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();