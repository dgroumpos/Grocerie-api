using Grocerie.Application.Queries.GroceryListQueries;
using Grocerie.Domain.Entities;
using Grocerie.Domain.Repositories;
using MediatR;

namespace Grocerie.Application.Handlers.GroceryListHandlers.Queries;

public class GetAllGroceryListsHandler(IGenericRepository<GroceryList> repository)
    : IRequestHandler<GetAllGroceryListsQuery, IEnumerable<GroceryList>>
{
    public async Task<IEnumerable<GroceryList>> Handle(GetAllGroceryListsQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetAllAsync();
    }
}