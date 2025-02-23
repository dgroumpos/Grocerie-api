using MediatR;

namespace Grocerie.Application.Commands.GroceryListCommands;

public record DeleteGroceryListCommand(Guid Id) : IRequest<bool>;