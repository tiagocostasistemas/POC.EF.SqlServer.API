using POC.EF.SqlServer.API.Data.Context;
using POC.EF.SqlServer.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddRefitServices();

builder.Services.AddCors(
    options => options.AddPolicy("all", policy => policy.WithOrigins("*")
    .WithHeaders("*").WithMethods("*")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("all");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
