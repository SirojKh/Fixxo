using Backend.Contexts;
using Backend.Filters;
using Backend.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





builder.Services.AddDbContext<DataContext>(x => 
	x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));

builder.Services.AddScoped<DataContext>();



builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<MessageRepository>();
builder.Services.AddScoped<ApiKey>();


var app = builder.Build();
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
