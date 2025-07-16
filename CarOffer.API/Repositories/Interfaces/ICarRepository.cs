using CarOfferProject.Models;

namespace CarOfferProject.Repositories.Interfaces;

public interface ICarRepository
{
    Task<List<Car>> GetAllAsync();
    Task<Car?> GetByIdAsync(int id);
    Task AddAsync(Car? car);
    Task DeleteAsync(Car? car);
}