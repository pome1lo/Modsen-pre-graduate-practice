using BusinessLogicLayer.Services.DTOs.Profiles;
using DataAccessLayer.Data.Interfaces;
using DataAccessLayer.Data.Repositories;
using Microsoft.AspNetCore.HttpLogging;
using PresentationLayer;
using PresentationLayer.MiddlewareExtensions;


var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services, builder.Configuration);

static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
    services.AddScoped<ICategoryRepository, CategoryRepository>();
    services.AddScoped<IProductRepository, ProductRepository>();
    services.AddScoped<IOrderRepository, OrderRepository>();
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IOrderItemRepository, OrderItemRepository>();

    services.AddBusinessServices();

    services.AddAutoMapper(typeof(UserMappingProfile));

    services.AddDatabase(configuration);

    services.AddCors(options =>
    {
        options.AddPolicy("AllowAll",
            policy =>
            {
                policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
    });

    services.AddHttpLogging(options =>
    {
        options.CombineLogs = true;
        options.LoggingFields =
            HttpLoggingFields.RequestQuery
            | HttpLoggingFields.RequestMethod
            | HttpLoggingFields.RequestPath
            | HttpLoggingFields.RequestBody
            | HttpLoggingFields.ResponseStatusCode
            | HttpLoggingFields.ResponseBody
            | HttpLoggingFields.Duration;
    });
}

var app = builder.Build();

app.UseGlobalExceptionHandler();

app.UseHttpsRedirection();

app.Services.MigrateDatabase();

app.Run();