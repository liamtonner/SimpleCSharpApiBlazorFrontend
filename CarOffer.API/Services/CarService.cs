using CarOfferProject.Data;
using CarOfferProject.Models;
using CarOfferProject.Repositories.Interfaces;
using CarOfferProject.Services.Interfaces;

namespace CarOfferProject.Services;

public class CarService(ICarRepository repo, CarContext context) : ICarService
{
    public async Task<IEnumerable<Car>> GetAllAsync() => await repo.GetAllAsync();

    public async Task<Car?> GetByIdAsync(int id) => await repo.GetByIdAsync(id);

    public async Task AddAsync(Car? car)
    {
        await repo.AddAsync(car);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var car = await repo.GetByIdAsync(id);
        if (car != null)
        {
            await repo.DeleteAsync(car);
            await context.SaveChangesAsync();
        }
    }
}