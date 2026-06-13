var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

/*
app.Run(context =>
{
    context.Response.StatusCode = 200;
    context.Response.Headers.Server = "Beastz";
    context.Response.ContentType = "text/html";

    Console.WriteLine(context.Request.Path);

    if (context.Request.Method == "GET")
    {
        if (context.Request.Query.ContainsKey("name"))
        {
            Console.WriteLine(context.Request.Query["name"]);
        }
    }

    if (context.Request.Method == "POST")
    {
        StreamReader reader = new(context.Request.Body);
        string body = reader.ReadToEndAsync().Result;
        var query = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);
        Console.WriteLine(query["name"]);
    }
    return context.Response.WriteAsync("<h1>Health check passed</h1>");
});
*/

/*  
The nature of the Run method it dosen't forward the request to the next middleware, it will end the pipeline and return the response immediately. So if you have multiple Run methods, only the first one will be executed and the rest will be ignored. If you want to have multiple endpoints, you should use app.Map or app.Use instead of app.Run.
*/

/*
app.Run(async context =>
{
    context.Response.StatusCode = 200;
    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync("<h1>Health check passed</h1>");
});

app.Run(async context =>
{
    context.Response.StatusCode = 200;
    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync("<h1>Health check passed second endpoint</h1>");
});
*/

/*  
The nature of the Run method it dosen't forward the request to the next middleware, it will end the pipeline and return the response immediately. So if you have multiple Run methods, only the first one will be executed and the rest will be ignored. If you want to have multiple endpoints, you should use app.Map or app.Use instead of app.Run.
*/

/*
app.Run(async context =>
{
    context.Response.StatusCode = 200;
    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync("<h1>Health check passed</h1>");
});

app.Run(async context =>
{
    context.Response.StatusCode = 200;
    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync("<h1>Health check passed second endpoint</h1>");
});
*/

/*
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("<h1>Health check passed</h1>");
    await next(context);
});

app.UseWhen(context => context.Request.Path.StartsWithSegments("/health"), appBuilder =>
{
    appBuilder.Run(async context =>
    {
        await context.Response.WriteAsync("<h1>Health check passed second endpoint</h1>");
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync("<h1>Health check passed third endpoint</h1>");
});

*/

/* 
UseWhen is a middleware that conditionally executes based on the request. It takes a predicate function that evaluates the incoming request and determines whether to execute the middleware or not. If the predicate returns true, the middleware is executed; otherwise, it is skipped.
*/

app.Map("/health", context =>
{
    context.Response.StatusCode = 200;
    context.Response.ContentType = "text/html";
    return context.Response.WriteAsync("<h1>Health check passed</h1>");
});

app.Map("/status", context =>
{
    context.Response.StatusCode = 200;
    context.Response.ContentType = "text/html";
    return context.Response.WriteAsync("<h1>Status check passed</h1>");
});

app.Map("/message/{Name:alpha}", context =>
{
    context.Response.StatusCode = 200;
    context.Response.ContentType = "text/html";

    var Name = context.Request.RouteValues["Name"];
    return context.Response.WriteAsync("<h1>Message check passed " + Name + "</h1>");
});

app.MapFallback(context =>
{
    context.Response.StatusCode = 404;
    context.Response.ContentType = "text/html";
    return context.Response.WriteAsync("<h1>Not found</h1>");
});

app.Run();
