using Domain.Common;

namespace Domain.Entities;
public class Book : BaseAuditableEntity
{
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public string? PictureUrl { get; set; }
    public decimal Price { get; set; }

}

