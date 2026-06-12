var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

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

app.Run();
