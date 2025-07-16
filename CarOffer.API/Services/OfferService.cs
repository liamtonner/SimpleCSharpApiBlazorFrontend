using CarOfferProject.Data;
using CarOfferProject.Models;
using CarOfferProject.Repositories.Interfaces;
using CarOfferProject.Services.Interfaces;

namespace CarOfferProject.Services;

public class OfferService(
    IOfferRepository repo,
    ICarRepository carRepo,
    IDealershipRepository dealerRepo,
    CarContext context)
    : IOfferService
{
    public async Task<IEnumerable<Offer>> GetAllAsync() => await repo.GetAllAsync();
    public async Task<Offer?> GetByIdAsync(int id) => await repo.GetByIdAsync(id);
    public async Task UpdateAsync(Offer? offer)
    {
        await repo.UpdateAsync(offer);
        await context.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var offer = await repo.GetByIdAsync(id);
        if (offer != null)
        {
            await repo.DeleteAsync(offer);
            await context.SaveChangesAsync();
        }
    }

    public async Task<Offer> AddOfferToCarAsync(int carId, Offer offer)
    {
        var car = await carRepo.GetByIdAsync(carId);
        if (car == null) throw new Exception("Car not found");

        var dealership = await dealerRepo.GetByIdAsync(offer.DealershipId);
        if (dealership == null) throw new Exception("Invalid DealershipId");

        offer.Dealership = dealership;
        await repo.AddToCarAsync(car, offer);
        await context.SaveChangesAsync();
        return offer;
    }
}