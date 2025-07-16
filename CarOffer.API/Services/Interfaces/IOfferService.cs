using CarOfferProject.Models;

namespace CarOfferProject.Services.Interfaces;

public interface IOfferService
{
    Task<IEnumerable<Offer>> GetAllAsync();
    Task<Offer?> GetByIdAsync(int id);
    Task UpdateAsync(Offer? offer);
    Task DeleteAsync(int id);
    Task<Offer> AddOfferToCarAsync(int carId, Offer offer);
}
