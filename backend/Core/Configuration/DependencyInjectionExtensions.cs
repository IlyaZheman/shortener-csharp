using Microsoft.OpenApi;

namespace Core.Configuration;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddOpenApiSpec()
            .AddEndpoints(typeof(Program).Assembly);

        return services;
    }

    private static IServiceCollection AddOpenApiSpec(this IServiceCollection services)
    {
        services.AddOpenApi();

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "My API",
                Version = "v1",
                Contact = new OpenApiContact
                {
                    Name = "Ilya"
                }
            });
        });

        return services;
    }
}