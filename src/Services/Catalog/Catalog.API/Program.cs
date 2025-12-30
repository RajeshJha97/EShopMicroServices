using Marten;

var builder = WebApplication.CreateBuilder(args);

//Add Services To The Container
builder.Services.AddCarter();
builder.Services.AddMediatR(cfg => {

    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddMarten(opts => {

    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
    //opts.AutoCreateSchemaObjects= AutoCreate.CreateOrUpdate; //this will create/update schema at a runtime
}).UseLightweightSessions();

var app = builder.Build();

//Configure HTTP Request Pipeline
app.MapCarter();

app.Run();
