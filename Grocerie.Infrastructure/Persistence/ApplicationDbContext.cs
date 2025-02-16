using Grocerie.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Grocerie.Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions options) : IdentityDbContext<User>(options)
{
    public DbSet<GroceryList> GroceryLists { get; set; }
    public DbSet<GroceryItem> GroceryItems { get; set; }
}