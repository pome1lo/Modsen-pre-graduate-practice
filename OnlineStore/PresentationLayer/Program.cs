using PresentationLayer.MiddlewareExtensions;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseGlobalExceptionHandler();

app.UseHttpsRedirection();

app.MapGet("/", () => "The Web API is working.");

app.Run();
