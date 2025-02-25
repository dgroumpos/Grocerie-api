using MediatR;

namespace Grocerie.Application.Commands.GroceryListCommands;

public record CreateGroceryListCommand(string Title, Guid UserId) : IRequest<Guid>;