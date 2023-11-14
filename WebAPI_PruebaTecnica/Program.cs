using Microsoft.EntityFrameworkCore;
using WebAPI_PruebaTecnica.Context;
using WebAPI_PruebaTecnica.Models;
using WebAPI_PruebaTecnica.Repositories;
using WebAPI_PruebaTecnica.Repositories.IRepositories;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddDbContext<DbcrudcoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL"));
});

builder.Services.AddScoped<IRepositoryBase<Cargo>,CargoRepository>();
builder.Services.AddScoped<IRepositoryBase<Empleado>, EmpleadoRepository>();



// Add services to the container.

builder.Services.AddControllers();


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

app.Run();
