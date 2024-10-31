using PRJ4.Repositories;
using PRJ4.Data;
using Microsoft.EntityFrameworkCore;
using PRJ4.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var conn = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBrugerRepo,BrugerRepo>(); // Add the BrugerRepo to the service container
builder.Services.AddScoped<ITemplateRepo<Bruger>,BrugerRepo>(); // Add the BrugerRepo to the service container
builder.Services.AddScoped<IFIndtægtRepo,FindtægtRepo>();// Add the Findtægt to the service container
builder.Services.AddScoped<ITemplateRepo<Findtægt>,FindtægtRepo>();// Add the Findtægt to the service container
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
    });


var app = builder.Build();
Console.WriteLine(builder.Configuration.GetConnectionString("DefaultConnection"));

// using (var scope = app.Services.CreateScope())
// {
//     var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//     DBInitializer.Seed(context);
// }

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
