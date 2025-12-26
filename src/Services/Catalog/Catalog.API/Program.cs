var builder = WebApplication.CreateBuilder(args);

//Add Services To The Container

var app = builder.Build();

//Configure HTTP Request Pipeline

app.Run();
