using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Data;
using PruebaTecnica.Mappings;
using PruebaTecnica.Repositories;
using PruebaTecnica.Repositories.impl;
using PruebaTecnica.Services;
using PruebaTecnica.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// conexion a la base de datos
builder.Services.AddDbContext<ContextDB>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("ConnectionDb"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("ConnectionDb"))
    );
});

// registramos servicios y repositorios
builder.Services.AddScoped<IUserRepository, UserRepositoryImpl>();
builder.Services.AddScoped<IUserService, UserServiceImpl>();

// configuracion del automapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// cors
builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
    });
});


builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
