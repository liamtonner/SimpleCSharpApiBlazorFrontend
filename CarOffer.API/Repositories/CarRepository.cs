using CarOfferProject.Data;
using CarOfferProject.Models;
using CarOfferProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarOfferProject.Repositories;

public class CarRepository(CarContext context) : ICarRepository
{
    public async Task<List<Car>> GetAllAsync()
    {
        return await context.Cars
            .Include(c => c.Offers)!
            .ThenInclude(o => o.Dealership)
            .ToListAsync();
    }

    public async Task<Car?> GetByIdAsync(int id)
    {
     return await context.Cars.Include(c => c.Offers)!.ThenInclude(o => o.Dealership).FirstOrDefaultAsync(c => c.Id == id);
    }
    public async Task AddAsync(Car? car) => await context.Cars.AddAsync(car!);
    public Task DeleteAsync(Car? car)
    {
        context.Cars.Remove(car!);
        return Task.CompletedTask;
    }
    public void Delete(Car? car)
    {
        context.Cars.Remove(car!);
    }
}