using Microsoft.EntityFrameworkCore;

using FluentValidation;

using TodoList.Data;
using TodoList.Service;
using TodoList.Domain.Entities;
using TodoList.Api.Mappings;
using TodoList.Api.RouteGroups;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TodoListContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("TodoListDatabase"),
        m => m.MigrationsAssembly("TodoList.Domain")
    );
});
builder.Services.AddScoped<ITodoItemsRepository, TodoItemsRepository>();
builder.Services.AddScoped<ITodoItemsService, TodoItemsService>();
builder.Services.AddAutoMapper(typeof(TodoItemProfile));
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowAnyOrigin();
        });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.AddTodoItemEndpoints();

app.Run();
