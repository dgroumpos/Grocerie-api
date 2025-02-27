using Grocerie.Domain.Entities;
using MediatR;

namespace Grocerie.Application.Queries.GroceryListQueries;

public record GetAllGroceryListsQuery() : IRequest<IEnumerable<GroceryList>>;