using LibreriaApi.Datos;
using LibreriaApi2;
using LibreriaApi2.Repositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AplicationDbContext>(Option =>
{
    Option.UseSqlServer(builder.Configuration.GetConnectionString("DefaulConnection"));


});


//builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddScoped<Libreriarepositorio>();
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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("NuevaPolitica");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();