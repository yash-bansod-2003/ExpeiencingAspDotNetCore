var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/health", (HttpContext context) =>
{
    context.Response.StatusCode = 200;
    context.Response.Headers.Server = "Beastz";
    context.Response.ContentType = "text/html";
    return context.Response.WriteAsync("<h1>Health check passed</h1>");
});

app.Run();
