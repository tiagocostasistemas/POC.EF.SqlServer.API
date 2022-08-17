namespace POC.EF.SqlServer.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAllServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddAutoMapperServices();
        services.AddDataContext();
        services.AddRepositories();
        services.AddDomainServices();
        services.AddCorsServices();
        services.AddRefitServices();
        
        return services;
    }

    private static IServiceCollection AddCorsServices(this IServiceCollection services)
    {
        services.AddCors(options => options.AddPolicy("all", policy => policy.WithOrigins("*")
                .WithHeaders("*").WithMethods("*")));
        return services;
    }

    private static IServiceCollection AddAutoMapperServices(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        return services;
    }
}
