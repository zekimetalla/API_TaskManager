using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TaskDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(p => p.AddPolicy("AllowPorts", policy =>
{
    policy.WithOrigins("http://localhost:5500", "https://localhost:7220", "http://127.0.0.1:5500").AllowAnyMethod()
    .AllowAnyHeader()
    .WithMethods("OPTIONS").AllowCredentials();
}));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}
//app cors
app.UseCors("AllowPorts");
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();


//app.UseCors(prodCorsPolicy);

app.MapControllers();

app.Run();