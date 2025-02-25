using Grocerie.Application.Queries.GroceryListQueries;
using Grocerie.Domain.Entities;
using Grocerie.Domain.Repositories;
using MediatR;

namespace Grocerie.Application.Handlers.GroceryListHandlers.Queries;

public class GetGroceryListByIdHandler(IGenericRepository<GroceryList> repository)
    : IRequestHandler<GetGroceryListByIdQuery, GroceryList?>
{
    public async Task<GroceryList?> Handle(GetGroceryListByIdQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetByIdAsync(request.Id);
    }
}