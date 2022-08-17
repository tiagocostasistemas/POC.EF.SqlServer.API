using POC.EF.SqlServer.API.Services.Interfaces;
using Refit;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace POC.EF.SqlServer.API.Extensions;

public static class HttpClientExtensions
{
    public static IServiceCollection AddRefitServices(this IServiceCollection services)
    {
        var settings = new RefitSettings(
            new SystemTextJsonContentSerializer(
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                }));

        services.AddRefitClient<IViaCepService>(settings)
            .ConfigureHttpClient(x =>
            {
                x.BaseAddress = new Uri("https://viacep.com.br/ws");
            });
        //.AddTransientHttpErrorPolicy(x =>
        //    x.WaitAndRetryAsync(4, attempt => TimeSpan.FromSeconds(2 * attempt)));

        return services;
    }
}