
using CarOfferProject.Models;
using CarOfferProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarOfferProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarController(ICarService carService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Car>>> GetCars()
    {
        var cars = await carService.GetAllAsync();
        return Ok(cars);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Car>> GetCar(int id)
    {
        var car = await carService.GetByIdAsync(id);
        if (car == null) return NotFound();
        return Ok(car);
    }

    [HttpPost]
    public async Task<IActionResult> AddCar(Car? car)
    {
        await carService.AddAsync(car);
        if (car != null) return CreatedAtAction(nameof(GetCar), new { id = car.Id }, car);
        return BadRequest("Car cannot be null");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCar(int id)
    {
        await carService.DeleteAsync(id);
        return NoContent();
    }
}