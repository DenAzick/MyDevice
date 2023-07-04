using Microsoft.EntityFrameworkCore;
using MyDevice.Context;
using MyDevice.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddDbContext<DeviceAppContext>(options =>
//{
//    options.UseNpgsql(builder.Configuration.GetConnectionString("mydevice"));
//});

builder.Services.AddDbContext<DeviceAppContext>();


builder.Services.AddScoped<DeviceManager>();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
