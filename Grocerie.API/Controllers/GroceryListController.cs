using Grocerie.Application.Services;
using Grocerie.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Grocerie.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class GroceryListController(GroceryListService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllLists() => Ok(await service.GetAllListsAsync());

    [HttpPost]
    public async Task<IActionResult> AddList([FromBody] GroceryList list)
    {
        await service.AddListAsync(list);
        return Ok("List added successfully");
    }
}