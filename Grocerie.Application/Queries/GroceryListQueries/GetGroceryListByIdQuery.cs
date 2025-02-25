using Grocerie.Domain.Entities;
using MediatR;

namespace Grocerie.Application.Queries.GroceryListQueries;

public record GetGroceryListByIdQuery(Guid Id) : IRequest<GroceryList?>;