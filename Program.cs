using backend_practice.EntityFramework;
using backend_practice.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<CarDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("CarDb"));
});

// Dependency Injection Lifetime
builder.Services.AddScoped<ICarService, CarManager>();
builder.Services.AddScoped<IBusService, BusManager>();
builder.Services.AddScoped<IBoatService, BoatManager>();


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