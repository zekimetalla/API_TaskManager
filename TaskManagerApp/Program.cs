using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Data;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<IConnectionMultiplexer>(opt =>
    ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("RedisConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TaskDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(p => p.AddPolicy("AllowPorts", policy =>
{
    policy.WithOrigins("http://localhost:19006", "https://localhost:7220", "http://127.0.0.1:5500").AllowAnyMethod()
    .AllowAnyHeader()
    .WithMethods("OPTIONS").AllowCredentials();
}));

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "redis:6379"; // redis is the container name of the redis service. 6379 is the default port
    options.InstanceName = "SampleInstance";
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseCors("AllowPorts");
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();


app.MapControllers();

app.Run();