using CarOfferProject.Data;
using CarOfferProject.Models;
using CarOfferProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarOfferProject.Repositories;

public class DealershipRepository(CarContext context) : IDealershipRepository
{
    public async Task<IEnumerable<Dealership>?> GetAllAsync()
    {
        return await context.Dealerships.ToListAsync();
    }

    public async Task<Dealership?> GetByIdAsync(int id)
    {
        return await context.Dealerships.FindAsync(id);
    }


    public Task AddAsync(Dealership dealership)
    {
        context.Dealerships.Update(dealership);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Dealership dealership)
    {
        context.Dealerships.Remove(dealership);
        return Task.CompletedTask;
    }
}
