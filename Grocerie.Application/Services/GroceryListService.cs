using Grocerie.Domain.Entities;
using Grocerie.Domain.Repositories;

namespace Grocerie.Application.Services;

public class GroceryListService(IGenericRepository<GroceryList> repository)
{
    private readonly IGenericRepository<GroceryList> _repository = repository;
    
    public async Task<IEnumerable<GroceryList>> GetAllListsAsync() => await _repository.GetAllAsync();

    public async Task AddListAsync(GroceryList list)
    {
        await _repository.AddAsync(list);
        await _repository.SaveChangesAsync();
    }
}