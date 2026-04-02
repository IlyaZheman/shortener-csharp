using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Database;

[Table("short_urls")]
public class ShortUrls
{
    [Key]
    [Column("slug")]
    public string Slug { get; set; } = default!;

    [Column("long_url")]
    public string LongUrl { get; set; } = default!;
}