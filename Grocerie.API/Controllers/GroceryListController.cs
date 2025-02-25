using System.Security.Claims;
using Grocerie.Application.Commands.GroceryListCommands;
using Grocerie.Application.Queries.GroceryListQueries;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Grocerie.API.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("api/[controller]")]
[ApiController]
public class GroceryListController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllLists()
    {
        var lists = await mediator.Send(new GetAllGroceryListsQuery());
        return Ok(lists);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetListById(GetGroceryListByIdQuery query)
    {
        var list = await mediator.Send(query);
        return list is not null ? Ok(list) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> AddList([FromBody] CreateGroceryListCommand command)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
            return Unauthorized("User not authenticated.");
        
        var newCommand = new CreateGroceryListCommand(command.Title, Guid.Parse(userId));
        
        var id = await mediator.Send(newCommand);
        // var id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetListById), new { id }, id);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateList(Guid id, [FromBody] UpdateGroceryListCommand command)
    {
        if (id != command.Id)
            return BadRequest("Ids do not match");

        var success = await mediator.Send(command);
        return success ? Ok("List updated successfully") : NotFound("List not found");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteList(Guid id)
    {
        var success = await mediator.Send(new DeleteGroceryListCommand(id));
        return success ? Ok("List deleted successfully") : NotFound("List not found");
    }
}