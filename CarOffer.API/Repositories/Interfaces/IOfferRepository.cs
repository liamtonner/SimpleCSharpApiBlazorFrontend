using CarOfferProject.Models;

namespace CarOfferProject.Repositories.Interfaces;

public interface IOfferRepository
{
    Task<IEnumerable<Offer>> GetAllAsync();
    Task<Offer?> GetByIdAsync(int id);
    Task UpdateAsync(Offer? offer);
    Task DeleteAsync(Offer? offer);
    Task AddToCarAsync(Car car, Offer offer);
}