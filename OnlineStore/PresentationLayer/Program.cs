using DataAccessLayer.Data.Interfaces;
using DataAccessLayer.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/", () => "The Web API is working.");

app.Run();

