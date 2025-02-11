namespace Grocerie.Domain.Entities;

public class GroceryItem
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public int Quantity { get; set; }
    public UnitOfMeasure Unit { get; set; }
    public  Guid? GroceryListId { get; set; } //FK
    public  GroceryList? GroceryList { get; set; } //Navigation property
    
}