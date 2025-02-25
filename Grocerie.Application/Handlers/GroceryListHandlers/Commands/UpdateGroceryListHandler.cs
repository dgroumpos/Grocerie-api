using Grocerie.Application.Commands.GroceryListCommands;
using Grocerie.Domain.Entities;
using Grocerie.Domain.Repositories;
using MediatR;

namespace Grocerie.Application.Handlers.GroceryListHandlers.Commands;

public class UpdateGroceryListHandler(IGenericRepository<GroceryList> repository)
    : IRequestHandler<UpdateGroceryListCommand, bool>
{
    public async Task<bool> Handle(UpdateGroceryListCommand request, CancellationToken cancellationToken)
    {
        var list = await repository.GetByIdAsync(request.Id);
        if (list == null) return false;
        
        list.Title = request.Title;
        list.Description = request.Description;

        await repository.SaveChangesAsync();
        return true;
    }
}