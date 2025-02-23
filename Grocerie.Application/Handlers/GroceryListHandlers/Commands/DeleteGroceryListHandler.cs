using Grocerie.Application.Commands.GroceryListCommands;
using Grocerie.Domain.Entities;
using Grocerie.Domain.Repositories;
using MediatR;

namespace Grocerie.Application.Handlers.GroceryListHandlers.Commands;

public class DeleteGroceryListHandler(IGenericRepository<GroceryList> repository) : IRequestHandler<DeleteGroceryListCommand, bool>
{
    public async Task<bool> Handle(DeleteGroceryListCommand request, CancellationToken cancellationToken)
    {
        var list = await repository.GetByIdAsync(request.Id);
        if(list == null) return false;
        
        repository.Delete(list);
        await repository.SaveChangesAsync();
        return true;
    }
}