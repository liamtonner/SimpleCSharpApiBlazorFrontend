using CarOfferProject.Data;
using CarOfferProject.Models;
using CarOfferProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarOfferProject.Repositories;

public class OfferRepository : IOfferRepository
{
    private readonly CarContext _context;
    public OfferRepository(CarContext context) => _context = context;

    public async Task<IEnumerable<Offer>> GetAllAsync() => await _context.Offers.Include(o => o.Dealership).ToListAsync();
    public async Task<Offer?> GetByIdAsync(int id) => await _context.Offers.Include(o => o.Dealership).FirstOrDefaultAsync(o => o.Id == id);
    public Task UpdateAsync(Offer? offer)
    {
        _context.Offers.Update(offer!);
        return Task.CompletedTask;
    }
    public Task DeleteAsync(Offer? offer)
    {
        _context.Offers.Remove(offer!);
        return Task.CompletedTask;
    }
    public Task AddToCarAsync(Car car, Offer offer)
    {
        car.Offers!.Add(offer);
        return Task.CompletedTask;
    }
}