using Data.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using Services.Service;

var builder = WebApplication.CreateBuilder(args);


//Conexion con el Front
var MyAllowSpecificOrigins = "_myAlloeSpecificOrigins";

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000", "http://localhost:3001")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//BDContext
builder.Services.AddDbContext<Grupo13Context>(option =>
option.UseNpgsql(builder.Configuration.GetConnectionString("Conection")));


builder.Services.AddScoped<IContratoService,ContratoService>();
builder.Services.AddScoped<IEquipoService,EquipoService>();
builder.Services.AddScoped<IPaisService,PaisService>();
builder.Services.AddScoped<IPersonaService,PersonaService>();
builder.Services.AddScoped<IPruebaService,PruebaService>();
builder.Services.AddScoped<IPruebaEquipoService, PruebaEquipoService>();


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

app.Run();
