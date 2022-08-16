using POC.EF.SqlServer.API.Context;
using POC.EF.SqlServer.API.Extensions;
using POC.EF.SqlServer.API.Repositories;
using POC.EF.SqlServer.API.Repositories.Interfaces;
using POC.EF.SqlServer.API.Services;
using POC.EF.SqlServer.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddRefitServices();

builder.Services.AddCors(options => options.AddPolicy("all", policy => policy.WithOrigins("*")
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
