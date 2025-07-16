using CarOfferProject.Models;

namespace CarOfferProject.Services.Interfaces;

public interface ICarService
{
    Task<IEnumerable<Car>> GetAllAsync();
    Task<Car?> GetByIdAsync(int id);
    Task AddAsync(Car? car);
    Task DeleteAsync(int id);
}