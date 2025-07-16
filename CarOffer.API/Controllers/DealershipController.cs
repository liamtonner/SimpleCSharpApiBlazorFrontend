
using CarOfferProject.Models;
using CarOfferProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarOfferProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DealershipController(IDealershipService dealershipService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Dealership>>> GetDealerships()
    {
        var dealerships = await dealershipService.GetAllAsync();
        return Ok(dealerships);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Dealership>> GetDealership(int id)
    {
        var d = await dealershipService.GetByIdAsync(id);
        if (d == null) return NotFound();
        return Ok(d);
    }

    [HttpPost]
    public async Task<IActionResult> AddDealership(Dealership dealershipDto)
    {
        var dealership = new Dealership
        {
            Name = dealershipDto.Name,
            Location = dealershipDto.Location
        };
        await dealershipService.AddAsync(dealership);
        return CreatedAtAction(nameof(GetDealership), new { id = dealership.Id }, dealership);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDealership(int id, Dealership dealershipToUpdate)
    {
        if (id != dealershipToUpdate.Id) return BadRequest("ID mismatch");

        var dealership = await dealershipService.GetByIdAsync(id);
        if (dealership == null) return NotFound();

        dealership.Name = dealershipToUpdate.Name;
        dealership.Location = dealershipToUpdate.Location;

        await dealershipService.UpdateAsync(dealership);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDealership(int id)
    {
        await dealershipService.DeleteAsync(id);
        return NoContent();
    }
}
