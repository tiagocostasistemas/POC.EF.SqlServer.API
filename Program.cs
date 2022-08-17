using POC.EF.SqlServer.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAllServices();

var app = builder.Build();

app.UseAll();

app.MapControllers();

app.Run();
