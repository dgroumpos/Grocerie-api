using Grocerie.Domain.Entities;
using Grocerie.Domain.Repositories;

namespace Grocerie.Application.Services;

public class GroceryItemService(IGenericRepository<GroceryItem> repository)
{
    private readonly IGenericRepository<GroceryItem> _repository = repository;

    public async Task<IEnumerable<GroceryItem>> GetAllAsync() => await _repository.GetAllAsync();

    public async Task AddItemAsync(GroceryItem item)
    {
        await _repository.AddAsync(item);
        await _repository.SaveChangesAsync();
    }
}