using Ejercicio.Prueba.Biblioteca.Application;
using Ejercicio.Prueba.Biblioteca.Domain;
using Ejercicio.Prueba.Biblioteca.Infraestructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<EjercicioPruebaDbContext>();

builder.Services.AddTransient<IAutorRepository, AutorRepository>();
builder.Services.AddTransient<IAutorAppService, AutorAppService>();

builder.Services.AddTransient<IEditorialRepository, EditorialRepository>();
builder.Services.AddTransient<IEditorialAppService, EditorialAppService>();

builder.Services.AddTransient<ILibroRepository, LibroRepository>();
builder.Services.AddTransient<ILibroAppService, LibroAppService>();

builder.Services.AddScoped<IUnitOfWork>(provider => 
{
    var instance = provider.GetService<EjercicioPruebaDbContext>();
    return instance;
});

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
