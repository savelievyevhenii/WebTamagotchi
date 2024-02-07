using Microsoft.AspNetCore.Identity;
using WebTamagotchi.Dal;
using Microsoft.EntityFrameworkCore;
using WebTamagotchi.Dal.Services;
using WebTamagotchi.Dal.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WebTamagotchiDbContext>(option => option.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionString"))).AddTransient<IUserService, UserService>();

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