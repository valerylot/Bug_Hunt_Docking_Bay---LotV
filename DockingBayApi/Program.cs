using DockingBayApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IPilotService, PilotService>();
builder.Services.AddScoped<IShipService, ShipService>();

var app = builder.Build();

app.MapControllers();

app.Run();
