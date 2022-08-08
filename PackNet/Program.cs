using PackNet;

var builder = ConsoleApp.CreateBuilder(args);
builder.ConfigureServices(services =>
{
    Startup.AddServices(services);
});

var app = builder.Build();
app.AddAllCommandType();
app.Run();
