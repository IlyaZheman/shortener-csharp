namespace Core.Configuration;

public static class AppExtensions
{
    public static IApplicationBuilder Configure(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        var apiGroup = app.MapGroup("/app");
        app.UseEndpoints(apiGroup);

        return app;
    }
}