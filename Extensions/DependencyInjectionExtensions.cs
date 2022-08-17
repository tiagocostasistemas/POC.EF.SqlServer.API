using POC.EF.SqlServer.API.Context;
using POC.EF.SqlServer.API.Repositories;
using POC.EF.SqlServer.API.Repositories.Interfaces;
using POC.EF.SqlServer.API.Services;
using POC.EF.SqlServer.API.Services.Interfaces;

namespace POC.EF.SqlServer.API.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddDataContext(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>();
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        return services;
    }

    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        return services;
    }
    
}
