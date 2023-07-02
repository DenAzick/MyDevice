using Microsoft.EntityFrameworkCore;
using MyDevice.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddDbContext<DeviceAppContext>(options =>
//{
//    options.UseNpgsql(builder.Configuration.GetConnectionString("Server=device_db;Port=5432;Database=device_db;User Id=postgres;Password=postgres;"));
//});

builder.Services.AddDbContext<DeviceAppContext>();


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
