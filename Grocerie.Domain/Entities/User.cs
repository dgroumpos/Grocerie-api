using Microsoft.AspNetCore.Identity;

namespace Grocerie.Domain.Entities;

public class User : IdentityUser<Guid>
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? LastLogin { get; set; }
}