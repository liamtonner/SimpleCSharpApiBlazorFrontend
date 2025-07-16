using CarOfferProject.Models;

namespace CarOfferProject.Services.Interfaces;

public interface IDealershipService
{
    Task<IEnumerable<Dealership>?> GetAllAsync();
    Task<Dealership?> GetByIdAsync(int id);
    Task AddAsync(Dealership dealership);
    Task UpdateAsync(Dealership dealership);
    Task DeleteAsync(int id);
}
