using Microsoft.EntityFrameworkCore;

namespace Core.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<ShortUrls> ShortUrls => Set<ShortUrls>();
}