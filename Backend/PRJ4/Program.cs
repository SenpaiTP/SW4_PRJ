using PRJ4.Repositories;
using PRJ4.Data;
using Microsoft.EntityFrameworkCore;
using PRJ4.Models;
using Microsoft.AspNetCore.Builder;
using PRJ4.Controllers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options=>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDBContext"))); // Add the DB context to the service container
builder.Services.AddScoped<IBrugerRepo,BrugerRepo>(); // Add the BrugerRepo to the service container
builder.Services.AddScoped<ITemplateRepo<Bruger>,BrugerRepo>(); // Add the BrugerRepo to the service container
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
