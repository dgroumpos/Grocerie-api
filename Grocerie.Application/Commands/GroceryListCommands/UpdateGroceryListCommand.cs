using MediatR;

namespace Grocerie.Application.Commands.GroceryListCommands;

public record UpdateGroceryListCommand(Guid Id, string Title, string? Description) : IRequest<bool>;