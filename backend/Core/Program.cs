using Core.Configuration;
using Core.Database;
using Core.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddConfiguration(builder.Configuration);

var app = builder.Build();

app.Configure();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.MapPost("/urls", async (string longUrl, UrlService service) =>
{
    var slug = await service.CreateAsync(longUrl);
    return Results.Ok(new { slug });
});

app.MapGet("/{slug}", async (string slug, UrlService service) =>
{
    var url = await service.GetAsync(slug);

    if (url is null)
        return Results.NotFound();

    return Results.Redirect(url);
});

app.Run();