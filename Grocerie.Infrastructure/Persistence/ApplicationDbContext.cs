using Grocerie.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Grocerie.Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions options) : IdentityDbContext<User>(options)
{
    public DbSet<GroceryList> GroceryLists { get; set; }
    public DbSet<GroceryItem> GroceryItems { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        //Configure User -> GroceryList (One-to-Many)
        builder.Entity<User>()
            .HasMany(u => u.GroceryLists)
            .WithOne(gl => gl.User)
            .HasForeignKey(gl => gl.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<GroceryList>()
            .HasMany(gl => gl.Items)
            .WithOne(gl => gl.GroceryList)
            .HasForeignKey(gl => gl.GroceryListId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<GroceryList>()
            .Property(gl => gl.UserId)
            .IsRequired();
        
        builder.Entity<GroceryItem>()
            .Property(gi => gi.Name)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Entity<GroceryList>()
            .Property(gl => gl.Title)
            .HasMaxLength(200)
            .IsRequired();
        
        builder.Entity<GroceryList>()
            .Property(gl => gl.CreatedAt)
            .HasDefaultValue(new DateTime(2024, 02, 23, 12, 0, 0));
    }
}