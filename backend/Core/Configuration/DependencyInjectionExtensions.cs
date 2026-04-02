using Core.Database;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

namespace Core.Configuration;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOpenApiSpec();
        services.AddDependencies();

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

    private static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql("Host=localhost;" +
                              "Port=6432;" +
                              "Database=postgres;" +
                              "Username=postgres;" +
                              "Password=postgres")
        );

        services.AddScoped<UrlService>();

        return services;
    }
}