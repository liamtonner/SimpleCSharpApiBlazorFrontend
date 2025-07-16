
using CarOfferProject.Models;

namespace CarOfferProject.Repositories.Interfaces;

public interface IDealershipRepository
{
    Task<IEnumerable<Dealership>?> GetAllAsync();
    Task<Dealership?> GetByIdAsync(int id);
    Task AddAsync(Dealership dealership);
    Task DeleteAsync(Dealership dealership);
}
