using CarOfferProject.Data;
using CarOfferProject.Models;
using CarOfferProject.Repositories.Interfaces;
using CarOfferProject.Services.Interfaces;

namespace CarOfferProject.Services;

public class DealershipService(IDealershipRepository repository, CarContext context) : IDealershipService
{
    public async Task<IEnumerable<Dealership>?> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<Dealership?> GetByIdAsync(int id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task AddAsync(Dealership dealership)
    {
        await repository.AddAsync(dealership);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Dealership dealership)
    {
        await repository.AddAsync(dealership);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var dealership = await repository.GetByIdAsync(id);
        if (dealership != null)
        {
            await repository.DeleteAsync(dealership);
            await context.SaveChangesAsync();
        }
    }
}

