using Microsoft.AspNetCore.Identity;

namespace Grocerie.Domain.Entities;

public class User : IdentityUser
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? LastLogin { get; set; }
    public List<GroceryList> GroceryLists { get; set; } = [];
}