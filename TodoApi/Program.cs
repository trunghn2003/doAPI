using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using Microsoft.Extensions.DependencyInjection;
using TodoApi.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TodoApiContext") ?? throw new InvalidOperationException("Connection string 'TodoApiContext' not found.")));

builder.Services.AddControllers();
builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();