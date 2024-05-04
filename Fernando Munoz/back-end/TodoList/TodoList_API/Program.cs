using Microsoft.EntityFrameworkCore;
using TodoList_API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Acá se agrega el contexto de la base de datos y se define el nombre de la cadena de conexion
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Conexion"));
});
//--------------------------------------------------------------------------------------------

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "NuevaPolitica", policy =>
    {
        policy.SetIsOriginAllowed(_ => true)
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//}

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseCors("NuevaPolitica");

app.UseAuthorization();

app.MapControllers();

app.Run();
