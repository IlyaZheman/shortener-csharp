using Core.Database;

namespace Core.Services;

public class UrlService(AppDbContext db)
{
    public async Task<string> CreateAsync(string longUrl)
    {
        var slug = Guid.NewGuid().ToString("N").Substring(0, 6);

        var entity = new ShortUrls
        {
            Slug = slug,
            LongUrl = longUrl
        };

        db.ShortUrls.Add(entity);
        await db.SaveChangesAsync();

        return slug;
    }

    public async Task<string?> GetAsync(string slug)
    {
        var url = await db.ShortUrls.FindAsync(slug);
        return url?.LongUrl;
    }
}