

using CarOfferProject.Models;
using CarOfferProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarOfferProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OfferController(IOfferService offerService) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Offer>>> GetOffers()
    {
        var offers = await offerService.GetAllAsync();
        return Ok(offers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Offer>> GetOffer(int id)
    {
        var offer = await offerService.GetByIdAsync(id);
        if (offer == null) return NotFound();
        return Ok(offer);
    }

    [HttpPost("add-to-car/{carId}")]
    public async Task<IActionResult> AddOfferToCar(int carId, Offer offerDto)
    {
        var offer = new Offer
        {
            Price = offerDto.Price,
            PromotionalGift = offerDto.PromotionalGift,
            DealershipId = offerDto.DealershipId,
        };
        var result = await offerService.AddOfferToCarAsync(carId, offer);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOffer(int id, Offer offerToUpdate)
    {
        if (id != offerToUpdate.Id) return BadRequest("ID mismatch");

        var offer = await offerService.GetByIdAsync(id);
        if (offer == null) return NotFound();

        offer.Price = offerToUpdate.Price;
        offer.PromotionalGift = offerToUpdate.PromotionalGift;
        offer.DealershipId = offerToUpdate.DealershipId;

        await offerService.UpdateAsync(offer);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOffer(int id)
    {
        await offerService.DeleteAsync(id);
        return NoContent();
    }

}