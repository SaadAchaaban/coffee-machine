using CoffeeMachine.Data;
using CoffeeMachine.Interfaces;
using CoffeeMachine.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// [ Saad Achaaban ] I have no doubt that this is not the correct method to follow for referencing my service
builder.Services.AddSingleton<ICoffeeMachine, CoffeeMachineStub>();

builder.Services.AddDbContext<ApplicationDbContext>( options => options.UseSqlite(
    builder.Configuration.GetConnectionString("localDb")
));

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
