using Grocerie.Application.Commands.GroceryListCommands;
using Grocerie.Domain.Entities;
using Grocerie.Domain.Repositories;
using MediatR;

namespace Grocerie.Application.Handlers.GroceryListHandlers.Commands;

public class CreateGroceryListHandler(IGenericRepository<GroceryList> repository) : IRequestHandler<CreateGroceryListCommand, Guid>
{
    public async Task<Guid> Handle(CreateGroceryListCommand request, CancellationToken cancellationToken)
    {
        var list = new GroceryList {Id = Guid.NewGuid(), Title = request.Title, UserId = request.UserId};
        await repository.AddAsync(list);
        await repository.SaveChangesAsync();
        return list.Id;
    }
}