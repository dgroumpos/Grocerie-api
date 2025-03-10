namespace Grocerie.Domain.Entities;

public class GroceryList
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<GroceryItem> Items { get; set; } = [];
    public string UserId { get; set; } //FK
    public User User { get; set; } //Navigation property
}