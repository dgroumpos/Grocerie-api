using Grocerie.Application.Services;
using Grocerie.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Grocerie.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GroceryListController(GroceryListService service) : ControllerBase
{
    private readonly GroceryListService _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAllLists() => Ok(await _service.GetAllListsAsync());

    [HttpPost]
    public async Task<IActionResult> AddList([FromBody] GroceryList list)
    {
        await _service.AddListAsync(list);
        return Ok("List added successfully");
    }
}